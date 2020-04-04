import { FunctionComponent, useEffect, useContext, useState } from "react";
import { ReactAuthContext } from "../../src/graphql/auth";
import Router from "next/router";
import { Grid, makeStyles, Theme, createStyles, useTheme, Paper, Typography, CircularProgress } from "@material-ui/core";
import { GoogleLogin, GoogleLoginResponse } from "react-google-login";
import Link from "next/link";

const useStyles = makeStyles((theme: Theme) =>
    createStyles({
        mainGrid: {
            marginTop: "15rem",
        },
        mainForm: {
            padding: "4rem",
            textAlign: "center",
        },
    }));

const LoginPageComponent: FunctionComponent = () => {
    const { login, user } = useContext(ReactAuthContext);
    const [loading, setLoading] = useState<boolean>(false);
    const [autoLogin, setAutoLogin] = useState<boolean>(false);
    const theme = useTheme();
    const c = useStyles(theme);

    useEffect(() => {
        if (user) {
            Router.push("/");
        }
    }, []);

    const googleLoginSuccess = async ({ accessToken }: GoogleLoginResponse) => {
        await handleLogin(accessToken);
    };

    const handleLogin = async (googleToken: string) => {
        if (!googleToken) {
            console.log("Prázdné vstupní údaje");
            return;
        }
        setLoading(true);
        try {
            await login(googleToken);
            if (window) {
                window.location.pathname = "/app";
            } else {
                Router.push("/app");
            }
        } catch (e) {
            if (e && e.graphQLErrors && e.graphQLErrors[0]) {
                console.log(e.graphQLErrors[0].message);
            } else {
                console.error("handle login error", e);
            }
            setLoading(false);
        }
    };

    const onExternalLoginFail = async (error: any) => {
        console.log(error);
    };

    if (loading) {
        return (
            <Grid container justify="center" alignItems="center" className={c.mainGrid} >
                <Grid item style={{ textAlign: "center" }}>
                    <CircularProgress color="secondary" />
                    <Typography variant="h6" color="primary" style={{ marginTop: "0.5rem" }}>
                        Probíhá přihlašování
                    </Typography>
                </Grid>
            </Grid>
        );
    }

    return (
        <>
            <Grid container justify="center" alignItems="center" className={c.mainGrid} >
                <Grid item>
                    <Paper elevation={3}>
                        <div className={c.mainForm}>
                            <Typography variant="h4" color="primary" style={{ marginBottom: "2rem" }}>
                                Přihlášení
                            </Typography>
                            <GoogleLogin clientId="1080634695580-t83muhrjtdvnk0jf12kuerh30l2pclpu.apps.googleusercontent.com"
                                buttonText="Přihlásit se přes Google"
                                onSuccess={googleLoginSuccess}
                                onFailure={onExternalLoginFail}
                                cookiePolicy={"single_host_origin"}
                            />
                            <div style={{ display: "flex", marginTop: "2rem" }}>
                                <Typography variant="body2" style={{ marginRight: "0.25em" }}>
                                    Nemáte účet?
                                </Typography>
                                <Link href="/login">
                                    <Typography variant="body2" color="secondary">
                                        Použijte tlačítko výše.
                                    </Typography>
                                </Link>
                            </div>
                        </div>
                    </Paper>
                </Grid>
            </Grid>
        </>
    );

};
export default LoginPageComponent;