import React, { createContext, FunctionComponent, useState, useEffect } from "react"
import { login } from "./types/login";
import { loginMutation } from "./mutations";
import { getLogged_logged, getLogged } from "./types/getLogged";
import { getLoggedUser } from "./queries";
import client from "./client";
import Cookies from "universal-cookie";
import Router from "next/router";
import { UserTokenCookieKey } from "../Global/Keys";

export const isLoggedIn = () => {
    return !!lastToken;
};

export let lastToken: string | null = new Cookies().get(UserTokenCookieKey);

export interface IAuthContext {
    token: null | string;
    user: getLogged_logged | undefined;
    isLoggedIn: boolean;
    login: (googleToken: string) => Promise<string> | undefined;
    logout: () => Promise<void> | undefined;
}

const defaultContext: IAuthContext = {
    token: null,
    user: undefined,
    isLoggedIn: false,
    login: () => undefined,
    logout: () => undefined,
}

export let lastContextValue: IAuthContext = defaultContext;

export const ReactAuthContext = createContext<IAuthContext>(defaultContext);

const AuthContextProvider: FunctionComponent<{} | IAuthContext> = (props) => {

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
        setToken(null);
        try {
            if (window) {
                window.localStorage.setItem("logout", Date.now().toString());
                window.location.reload();
            } else {
                Router.push("/login");
            }
            // tslint:disable-next-line:no-empty
        } catch {

        }
    };

    const getToken = (): string | null => {
        // tslint:disable-next-line:no-shadowed-variable
        const cookies = new Cookies();
        const token: string | null = cookies.get(UserTokenCookieKey);
        return token;
    };

    const setToken = (token: string | undefined | null) => {
        // tslint:disable-next-line:no-shadowed-variable
        const cookies = new Cookies();
        if (token) {
            lastToken = token;
            setState({
                ...state,
                token,
                isLoggedIn: true,
            });

            cookies.set(UserTokenCookieKey, token, { path: "/", maxAge: 60 * 60 * 24 });
        } else {
            lastToken = null;
            setState({
                ...state,
                token: null,
                isLoggedIn: false,
            });
            cookies.remove(UserTokenCookieKey);
        }
    };

    const getSessionUser = async (): Promise<getLogged_logged> => {
        const { data: { logged }, errors } = await client.query<getLogged>({ query: getLoggedUser });
        if (errors?.length > 0) {
            console.log(errors);
            return null;
        }
        setState({
            ...state,
            user: logged
        })
        return logged;
    };

    const seeIfSessionIsValid = async () => {
        try {
            await getSessionUser();
        } catch (e) {
            setToken(undefined);
        }
    };

    const [state, setState] = useState<IAuthContext>({
        ...props,
        user: defaultContext.user,
        logout,
        login,
        token: lastToken,
        isLoggedIn: !!lastToken,
    });

    useEffect(() => {
        const token = getToken();
        if (token) {
            setToken(token);
            seeIfSessionIsValid();
        }
        // see if session is valid and update user info every 15 mins
        setInterval(seeIfSessionIsValid, 15 * 60 * 1000);
        // tslint:disable-next-line:no-empty
        return () => {
        };
    }, []);

    lastContextValue = state;
    return (
        <ReactAuthContext.Provider value={state}>
            {props.children}
        </ReactAuthContext.Provider>
    );
};

export const AuthContext = {
    Provider: AuthContextProvider,
    Consumer: ReactAuthContext.Consumer,
};
