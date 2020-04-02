import ApolloClient from "apollo-boost";
import { lastContextValue, getToken } from "./auth";
import { ServerError } from "apollo-link-http-common";

const apiUri = "https://domov.azurewebsites.net/graphql";

const client = new ApolloClient({
    uri: apiUri,
    fetch: require("node-fetch"),
    request: async (operation) => {
        const token = getToken();
        if (token) {
            operation.setContext({
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            });
        }
    },
    onError({ networkError, response, forward, operation, ...other }) {
        if ((networkError && (networkError as ServerError).statusCode === 401) ||
            (response && response.errors && (response.errors[0].message as any).statusCode === 401)) {
            if (operation.operationName !== "logout") {
                lastContextValue.logout();
            }
        }
        console.error("GraphQL onError handle", { networkError, response, operation, ...other });
        forward(operation);
    },
    clientState: {
        defaults: {},
    },
});

export default client;
