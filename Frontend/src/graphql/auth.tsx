import React, { createContext, FunctionComponent, useState, useEffect } from "react";
import { login } from "./types/login";
import { loginMutation, logoutMutation } from "./mutations";
import { getLogged_logged, getLogged } from "./types/getLogged";
import { getLoggedUser } from "./queries";
import client from "./client";
import Cookies from "universal-cookie";
import Router from "next/router";
import { UserTokenCookieKey } from "../Global/Keys";
import { logout } from "./types/logout";

export const getToken = (): string | null => new Cookies().get(UserTokenCookieKey);

export interface IAuthContext {
    token: null | string;
    user: getLogged_logged | undefined;
    login: (googleToken: string) => Promise<string> | undefined;
    logout: () => Promise<void> | undefined;
}

const defaultContext: IAuthContext = {
    token: null,
    user: undefined,
    login: () => undefined,
    logout: () => undefined,
};

export const ReactAuthContext = createContext<IAuthContext>(defaultContext);

const AuthContextProvider: FunctionComponent<{} | IAuthContext> = (props) => {

    const [currentUser, setCurrentUser] = useState<getLogged_logged>(defaultContext.user);
    const [currentToken, setCurrentToken] = useState<string>(getToken());

    const login = async (googleToken: string): Promise<string> => {
        const { data: { login: { authToken } }, errors, } = await client.mutate<login>({
            mutation: loginMutation,
            variables: { googleToken }
        });
        if (errors?.length > 0) {
            console.log(errors);
            return null;
        }
        setToken(authToken);
        return authToken;
    };

    const logout = async () => {
        const { data: { logout: res } } = await client.mutate<logout>({
            mutation: logoutMutation
        });
        if (!res) {
            console.log("Logout returned: ", res);
        }
        setToken(null);
        try {
            if (window) {
                window.localStorage.setItem("logout", Date.now().toString());
                window.localStorage.removeItem("user");
                window.location.reload();
            } else {
                Router.push("/login");
            }
            // eslint-disable-next-line no-empty
        } catch {

        }
    };

    const setToken = (token: string | null) => {
        const cookies = new Cookies();
        if (token) {
            setCurrentToken(token);

            cookies.set(UserTokenCookieKey, token, { path: "/", maxAge: 60 * 60 * 24, sameSite: "strict" });
        } else {
            setCurrentToken(null);
            cookies.remove(UserTokenCookieKey);
        }
    };

    const getDbUser = async (): Promise<getLogged_logged> => {
        const { data: { logged }, errors } = await client.query<getLogged>({ query: getLoggedUser });
        if (errors?.length > 0) {
            console.log(errors);
            return null;
        }
        return logged;
    };

    const getLocalUser = (): getLogged_logged => {
        if (window) {
            var u = window.localStorage.getItem("user");
            return JSON.parse(u) as getLogged_logged;
        }
        return null;
    };

    const checkSession = async (): Promise<void> => {
        try {
            const user = await getDbUser();
            if (!user) {
                await logout();
                return;
            }
            if (user && window) {
                window.localStorage.setItem("user", JSON.stringify(user));
                setCurrentUser(user);
            }
        } catch (e) {
            setToken(null);
        }
    };

    useEffect(() => {
        if (currentToken) {
            const logged = getLocalUser();
            setCurrentUser(logged);
            if (!logged) {
                checkSession();
            }
        }
        return () => {
        };
    }, []);

    useEffect(() => {
        if (currentToken) {
            checkSession();
        }

        return () => {
        };
    }, [currentToken]);


    return (
        <ReactAuthContext.Provider value={{
            user: currentUser,
            token: currentToken,
            login,
            logout,
        }}>
            {props.children}
        </ReactAuthContext.Provider>
    );
};

export const AuthContext = {
    Provider: AuthContextProvider,
    Consumer: ReactAuthContext.Consumer,
};
