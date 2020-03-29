import App from "next/app";
import HeadComponent from "../components/Layouts/HeadComponent";
import { AuthContext } from "../src/graphql/auth";
import { ApolloProvider } from "react-apollo";
import client from "../src/graphql/client";
import fetch from "node-fetch";

// eslint-disable-next-line no-unused-vars
class DomacnostApp extends App<{}> {
    render() {
        // @ts-ignore
        global.fetch = fetch;
        const { Component, pageProps } = this.props;
        return <>
            <HeadComponent>
                <AuthContext.Provider>
                    <ApolloProvider client={client}>
                        <Component {...pageProps} />
                    </ApolloProvider>
                </AuthContext.Provider>
            </HeadComponent>
        </>;
    }
}

export default DomacnostApp;