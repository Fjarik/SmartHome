import { FunctionComponent, useEffect, useContext, useState } from "react";
import { ReactAuthContext } from "../../src/graphql/auth";
import Router from "next/router";
import SocialButton from "./SocialButton";
import { Button, Grid } from "@material-ui/core";

const LoginPageComponent: FunctionComponent = () => {
    const { login, isLoggedIn } = useContext(ReactAuthContext);
    const [loading, setLoading] = useState<boolean>(false);
    const [autoLogin, setAutoLogin] = useState<boolean>(false);

    useEffect(() => {
        if (isLoggedIn) {
            Router.push("/");
        }
    }, []);

    const googleLoginSuccess = async ({ _token }: any) => {
        const token: string = _token.accessToken;
        await handleLogin(token);
    };

    const handleLogin = async (googleToken: string) => {
        if (!googleToken) {
            console.log("Prázdné vstupní údaje");
            return;
        }
        setLoading(true);
        try {
            await login(googleToken);
            // Router.push("/");
            if (window) {
                window.location.reload();
            }
        } catch (e) {
            if (e && e.graphQLErrors && e.graphQLErrors[0]) {
                console.log(e.graphQLErrors[0].message);
            } else {
                console.error("handle login error", e);
            }
        }
        setLoading(false);
    };

    const onExternalLoginFail = async (error: any) => {
        console.log(error);
    };


    if (loading) {
        return <>
            <p>Probíhá přihlašování</p>
        </>;
    }

    return (
        <>
            <Grid container justify="center" alignItems="center" >
                <Grid item>
                    <SocialButton appId="1080634695580-t83muhrjtdvnk0jf12kuerh30l2pclpu.apps.googleusercontent.com"
                        provider="google"
                        onLoginSuccess={googleLoginSuccess}
                        onLoginFailure={onExternalLoginFail}
                        autoLogin={autoLogin}
                    >
                        <Button
                            variant="contained"
                            color="primary"
                            size="large">
                            Přihlásit se přes Google
                </Button>
                    </SocialButton>
                </Grid>
            </Grid>
        </>
    );

};
export default LoginPageComponent;