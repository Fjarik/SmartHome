import App from "next/app";
import HeadComponent from "../components/Layouts/HeadComponent";
import { AuthContext } from "../src/graphql/auth";
import { ApolloProvider } from "react-apollo";
import client from "../src/graphql/client";
import fetch from "node-fetch";
import { ThemeProvider, CssBaseline } from "@material-ui/core";
import { getTheme } from "../components/Themes/MainTheme";

// eslint-disable-next-line no-unused-vars
class DomacnostApp extends App<{}> {
    componentDidMount() {
        // Remove the server-side injected CSS.
        const jssStyles = document.querySelector('#jss-server-side');
        if (jssStyles) {
            jssStyles.parentElement!.removeChild(jssStyles);
        }
    }

    render() {
        // @ts-ignore
        global.fetch = fetch;
        const { Component, pageProps } = this.props;
        const theme = getTheme();
        return <>
            <HeadComponent>
                <AuthContext.Provider>
                    <ApolloProvider client={client}>
                        <ThemeProvider theme={theme}>
                            <CssBaseline />
                            <Component {...pageProps} />
                        </ThemeProvider>
                    </ApolloProvider>
                </AuthContext.Provider>
            </HeadComponent>
        </>;
    }
}

export default DomacnostApp;