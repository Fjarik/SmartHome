import App from "next/app";
import HeadComponent from "../components/Layouts/HeadComponent";
import { AuthContext, getDbUser } from "../src/graphql/auth";
import { ApolloProvider } from "react-apollo";
import fetch from "node-fetch";
import { ThemeProvider, CssBaseline } from "@material-ui/core";
import { getTheme } from "../components/Themes/MainTheme";
import { withApollo } from "../lib/apollo";
import { SnackbarProvider } from "notistack";
import { MuiPickersUtilsProvider } from "@material-ui/pickers";
import LuxonAdapter from "@date-io/luxon";
import { ApolloClient } from "apollo-client";
import { NormalizedCacheObject } from "apollo-cache-inmemory";
import { getLogged_logged, getLogged } from "../src/graphql/types/getLogged";
import { getLoggedUser } from "../src/graphql/queries";

interface AppProps {
    apolloClient: ApolloClient<NormalizedCacheObject>,
}
interface AppChildProps {
    user: getLogged_logged | null,
    [key: string]: any,
}

class DomacnostApp extends App<AppProps> {
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
        const { user } = pageProps as AppChildProps;
        const theme = getTheme();
        return <HeadComponent>
            <ThemeProvider theme={theme}>
                <SnackbarProvider maxSnack={3} >
                    <ApolloProvider client={apolloClient} >
                        <AuthContext.Provider user={user}>
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

DomacnostApp.getInitialProps = async (context) => {

    // @ts-ignore
    const { ctx: { apolloClient } } = context;
    const client = apolloClient as ApolloClient<any>;
    try {

        const res = await getDbUser(client);
        return {
            pageProps: {
                user: res
            }
        };

    } catch{
        return {
            pageProps: {
            }
        };
    }

};

export default withApollo(DomacnostApp);