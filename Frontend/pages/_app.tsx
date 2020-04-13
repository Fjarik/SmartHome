import App from "next/app";
import HeadComponent from "../components/Layouts/HeadComponent";
import { AuthContext } from "../src/graphql/auth";
import { ApolloProvider } from "react-apollo";
// import client from "../src/graphql/client";
import fetch from "node-fetch";
import { ThemeProvider, CssBaseline } from "@material-ui/core";
import { getTheme } from "../components/Themes/MainTheme";
import { withApollo } from "../lib/apollo";
import { SnackbarProvider } from "notistack";
import { MuiPickersUtilsProvider } from "@material-ui/pickers";
import LuxonAdapter from "@date-io/luxon";

// eslint-disable-next-line no-unused-vars
class DomacnostApp extends App<any> {
    componentDidMount() {
        // Remove the server-side injected CSS.
        const jssStyles = document.querySelector("#jss-server-side");
        if (jssStyles) {
            jssStyles.parentElement!.removeChild(jssStyles);
        }
    }

    render() {
        // @ts-ignore
        global.fetch = fetch;
        const { Component, pageProps, apolloClient } = this.props;
        const theme = getTheme();
        return <HeadComponent>
            <ThemeProvider theme={theme}>
                <SnackbarProvider maxSnack={3} >
                    <ApolloProvider client={apolloClient} >
                        <AuthContext.Provider>
                            <MuiPickersUtilsProvider utils={LuxonAdapter} locale="cz">
                                <CssBaseline />
                                <Component {...pageProps} />
                            </MuiPickersUtilsProvider>
                        </AuthContext.Provider>
                    </ApolloProvider>
                </SnackbarProvider>
            </ThemeProvider>
        </HeadComponent>;
    }
}

export default withApollo(DomacnostApp);