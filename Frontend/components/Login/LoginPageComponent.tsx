import { FunctionComponent, useEffect, useContext, useState } from "react";
import { ReactAuthContext } from "../../src/graphql/auth";
import Router from "next/router";
import { Grid, makeStyles, Theme, createStyles, Paper, Typography } from "@material-ui/core";
import { GoogleLogin, GoogleLoginResponse } from "react-google-login";
import Link from "next/link";
import CenterLoading from "../Loading/CenterLoading";
import customUrls from "../../utils/customUrls";
import { useSnackbar } from "notistack";

const useStyles = makeStyles((theme: Theme) =>
    createStyles({
        mainGrid: {
            marginTop: "15rem",
            justifyContent: "center",
            alignItems: "center"
        },
        mainForm: {
            padding: "4rem",
            textAlign: "center",
        },
    }));

const LoginPageComponent: FunctionComponent = () => {
    const { login, token } = useContext(ReactAuthContext);
    const [loading, setLoading] = useState<boolean>(false);
    const [autoLogin, setAutoLogin] = useState<boolean>(false);
    const { enqueueSnackbar } = useSnackbar();
    const { app: { appUrl }, account: { loginUrl } } = customUrls;

    const c = useStyles();

    useEffect(() => {
        if (token) {
            enqueueSnackbar("Již jste přihlášen/a", { variant: "warning" });
            Router.push(appUrl);
        }
        return () => { };
    }, []);

    const googleLoginSuccess = async ({ accessToken }: GoogleLoginResponse) => {
        await handleLogin(accessToken);
    };

    const handleLogin = async (googleToken: string) => {
        if (!googleToken) {
            enqueueSnackbar("Google nevrátil data", { variant: "error" });
            console.log("Prázdné vstupní údaje");
            return;
        }
        setLoading(true);
        try {
            await login(googleToken);
            enqueueSnackbar("Přihlášení proběhlo úspěšně", { variant: "success" });
            if (window) {
                window.location.pathname = appUrl;
            } else {
                Router.push(appUrl);
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
            <CenterLoading text={"Probíhá přihlašování"} />
        );
    }

    return (
        <Grid container className={c.mainGrid} >
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
                            <Link href={loginUrl}>
                                <Typography variant="body2" color="secondary">
                                    Použijte tlačítko výše.
                                </Typography>
                            </Link>
                        </div>
                    </div>
                </Paper>
            </Grid>
        </Grid>
    );

};
export default LoginPageComponent;