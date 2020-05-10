import Head from "next/head";
import { ApolloClient } from "apollo-client";
import { InMemoryCache, NormalizedCacheObject } from "apollo-cache-inmemory";
import { HttpLink } from "apollo-link-http";
import { setContext } from "apollo-link-context";
import fetch from "isomorphic-unfetch";
import { onError } from "apollo-link-error";
import { ApolloLink, fromPromise } from "apollo-link";
import { refreshTokenAsync, setRefreshToken } from "./auth/authService";
import { NextPage } from "next";
import Observable from "zen-observable-ts";
import { AppContextType } from "next/dist/next-server/lib/utils";

const endpoint = "https://domov.azurewebsites.net/graphql";
// const endpoint = "http://localhost:20436/graphql";
// https://domov.azurewebsites.net/

interface PageProps {
    apolloClient: ApolloClient<NormalizedCacheObject>,
    apolloState: any,
}

/**
 * Creates and provides the apolloContext
 * to a next.js PageTree. Use it by wrapping
 * your PageComponent via HOC pattern.
 */
export const withApollo = (PageComponent: any, { ssr = true } = {}) => {
    const WithApollo: NextPage<PageProps> = ({ apolloClient, apolloState, ...pageProps }) => {

        const client = apolloClient || initApolloClient(apolloState);

        return <PageComponent {...pageProps} apolloClient={client} />;
    };

    if (process.env.NODE_ENV !== "production") {
        // Find correct display name
        const displayName =
            PageComponent.displayName || PageComponent.name || "Component";

        // Warn if old way of installing apollo is used
        if (displayName === "App") {
            console.warn("This withApollo HOC only works with PageComponents.");
        }

        // Set correct display name for devtools
        WithApollo.displayName = `withApollo(${displayName})`;
    }

    if (ssr || PageComponent.getInitialProps) {
        WithApollo.getInitialProps = async (ctx: any) => {
            const {
                AppTree,
                ctx: { res, req }
            } = ctx as AppContextType;

            // Run all GraphQL queries in the component tree
            // and extract the resulting data
            const apolloClient = (ctx.ctx.apolloClient = initApolloClient({}));

            const pageProps = PageComponent.getInitialProps
                ? await PageComponent.getInitialProps(ctx)
                : {};

            // Only on the server
            if (typeof window === "undefined") {
                // When redirecting, the response is finished.
                // No point in continuing to render
                if (res && res.finished) {
                    return {};
                }

                if (ssr) {
                    try {
                        // Run all GraphQL queries
                        const { getDataFromTree } = await import("@apollo/react-ssr");
                        await getDataFromTree(
                            <AppTree
                                pageProps={{
                                    ...pageProps,
                                    apolloClient
                                }}
                                apolloClient={apolloClient}
                            />
                        );
                    } catch (error) {
                        // Prevent Apollo Client GraphQL errors from crashing SSR.
                        // Handle them in components via the data.error prop:
                        // https://www.apollographql.com/docs/react/api/react-apollo.html#graphql-query-data-error
                        console.error("Error while running `getDataFromTree`", error);
                    }
                }

                // getDataFromTree does not call componentWillUnmount
                // head side effect therefore need to be cleared manually
                Head.rewind();
            }

            // Extract query data from the Apollo store
            const apolloState = apolloClient.cache.extract();

            return {
                ...pageProps,
                apolloState
            };
        };
    }

    return WithApollo;
};

let apolloClient: ApolloClient<NormalizedCacheObject> | null = null;

/**
 * Always creates a new apollo client on the server
 * Creates or reuses apollo client in the browser.
 */
const initApolloClient = (initState: any) => {
    // Make sure to create a new client for every server-side request so that data
    // isn't shared between connections (which would be bad)
    if (typeof window === "undefined") {
        return createApolloClient(initState);
    }

    // Reuse client on the client-side
    if (!apolloClient) {
        // setAccessToken(cookie.parse(document.cookie).test);
        apolloClient = createApolloClient(initState);
    }

    return apolloClient;
};

/**
 * Creates and configures the ApolloClient
 */
const createApolloClient = (initState: any): ApolloClient<NormalizedCacheObject> => {
    let isRefreshing = false;
    let pendingRequest = [];

    const resolvePendingRequests = (): void => {
        pendingRequest.map(c => c());
        pendingRequest = [];
    };

    const httpLink = new HttpLink({
        uri: endpoint,
        credentials: "include",
        fetch
    });

    const authLink = setContext((_request, { headers }) => {
        return {
            fetchOptions: {
                credentials: "include"
            },
            headers: {
                ...headers,
                cookie: headers && headers.cookie,
            },
        };
    });

    const errorLink = onError(({ graphQLErrors, response, networkError, forward, operation, ...other }) => {
        let expired = false;
        if (graphQLErrors) {
            graphQLErrors.map(({ message, locations, path }) => {
                if (message === "Token is expired") {
                    // console.info("Token is expired");
                    expired = true;
                } else if (message.includes("You are not logged")) {
                    setRefreshToken(null);
                } else {
                    console.error(`[GraphQL error]: Message: ${message}, Location: ${locations}, Path: ${path}`);
                }
            });
        }

        if (expired) {
            let forward$: Observable<any>;

            if (isRefreshing) {
                forward$ = fromPromise(
                    new Promise(r => {
                        pendingRequest.push(() => r());
                    })
                );
            } else {
                isRefreshing = true;
                forward$ = fromPromise(
                    refreshTokenAsync(apolloClient)
                        .then(res => {
                            operation.setContext(({ headers }) => {
                                return {
                                    fetchOptions: {
                                        credentials: "include"
                                    },
                                    headers: {
                                        cookie: headers && headers.cookie,
                                        ...headers,
                                    }
                                };
                            });
                            resolvePendingRequests();
                            return res;
                        })
                        .catch(error => {
                            pendingRequest = [];
                            console.error(error);
                            return;
                        })
                        .finally(() => {
                            isRefreshing = false;
                        })
                ).filter(x => Boolean(x));

            }

            return forward$.flatMap(() => forward(operation));
        }

        console.error("GraphQL onError handle", { networkError, graphQLErrors, operation, ...other });
        // forward(operation);
    });

    return new ApolloClient({
        ssrMode: typeof window === "undefined", // Disables forceFetch on the server (so queries are only run once)
        link: ApolloLink.from([authLink, errorLink, httpLink]),
        cache: new InMemoryCache().restore(initState),
    });
};