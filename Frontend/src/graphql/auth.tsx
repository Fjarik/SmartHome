import React, { createContext, FunctionComponent, useState, useEffect } from "react";
import { login, loginVariables } from "./types/login";
import { loginMutation, logoutMutation, refreshTokenMutation } from "./mutations";
import { getLogged_logged, getLogged } from "./types/getLogged";
import { getLoggedUser } from "./queries";
import Cookies from "universal-cookie";
import Router from "next/router";
import { UserTokenCookieKey, TokenInfoKey, UserKey } from "../Global/Keys";
import { logout, logoutVariables } from "./types/logout";
import { useApolloClient } from "react-apollo";
import customUrls from "../../utils/customUrls";
import { useSnackbar } from "notistack";
import { refreshTokenVariables, refreshToken } from "./types/refreshToken";

export interface IAuthToken {
    /**
    * Access token
    */
    accessToken: string;
    /**
     * Expiration of token
     */
    expiration: any;
    /**
     * Refresh token
     */
    refreshToken: string;
}

export const getToken = (): string | null => new Cookies().get(UserTokenCookieKey);
export const setTokenCookie = (token: string | null) => {
    const cookies = new Cookies();

    if (token) {
        cookies.set(UserTokenCookieKey, token, { path: "/", maxAge: 60 * 60 * 24 * 365, sameSite: "strict" });
    } else {
        cookies.set(UserTokenCookieKey, "", { path: "/", maxAge: -1, sameSite: "strict" });
        // cookies.remove(UserTokenCookieKey);
    }
};

export const getTokenInfo = (): IAuthToken | null => {
    if (!window) {
        return null;
    }
    var json = window.localStorage.getItem(TokenInfoKey);
    if (!json) {
        return null;
    }
    return JSON.parse(json) as IAuthToken;
};

export const setTokenInfo = (token: IAuthToken): void => {
    if (!window) {
        return;
    }
    if (!token) {
        window.localStorage.removeItem(TokenInfoKey);
        return;
    }
    const { expiration, refreshToken } = token;
    const toJson: IAuthToken = {
        accessToken: null,
        expiration,
        refreshToken
    };
    window.localStorage.setItem(TokenInfoKey, JSON.stringify(toJson));
};

export interface IAuthContext {
    token: string | null;
    user: getLogged_logged | null;
    login: (googleToken: string) => Promise<IAuthToken | null>;
    refreshTokenAsync: () => Promise<IAuthToken | null>;
    logout: () => Promise<void>;
}

const defaultContext: IAuthContext = {
    token: null,
    user: null,
    login: () => null,
    refreshTokenAsync: () => null,
    logout: () => null,
};

export const ReactAuthContext = createContext<IAuthContext>(defaultContext);

const AuthContextProvider: FunctionComponent<{}> = ({ children }) => {

    const [currentUser, setCurrentUser] = useState<getLogged_logged | null>(defaultContext.user);
    const [currentToken, setCurrentToken] = useState<string | null>(getToken());
    const client = useApolloClient();
    const { enqueueSnackbar } = useSnackbar();
    const { account: { loginUrl } } = customUrls;

    const clearAll = (): void => {
        setToken(null);
        setUser(null);
        setCurrentToken(null);
        setTokenInfo(null);
    };

    const login = async (googleToken: string): Promise<IAuthToken | null> => {
        const { data: { login: { authToken, id, firstname, lastname, createdAt } }, errors, } = await client.mutate<login, loginVariables>({
            mutation: loginMutation,
            variables: { googleToken }
        });
        if (errors?.length > 0) {
            console.log(errors);
            return null;
        }
        const { accessToken } = authToken;

        setToken(accessToken);
        setUser({
            __typename: "UserType",
            id,
            firstname,
            lastname,
            createdAt,
        });

        setTokenInfo(authToken);

        return authToken;
    };

    const refreshTokenAsync = async (): Promise<IAuthToken | null> => {
        const rToken = getTokenInfo();
        if (!rToken || !rToken.refreshToken) {
            return null;
        }

        const { data, errors } = await client.mutate<refreshToken, refreshTokenVariables>({
            mutation: refreshTokenMutation,
            variables: {
                refreshToken: rToken.refreshToken
            }
        });

        if (errors) {
            console.error(errors);
            return null;
        }

        const { refreshToken } = data;

        setToken(refreshToken.accessToken);
        setTokenInfo(refreshToken);

        return refreshToken;
    };

    const logout = async (): Promise<void> => {
        try {
            const { data: { logout: res } } = await client.mutate<logout, logoutVariables>({
                mutation: logoutMutation
            });
            if (!res) {
                console.log("Logout returned: ", res);
            }
        } catch (error) {
            console.log("Error when logging out: ", error);
        }

        clearAll();
        if (window) {
            window.localStorage.setItem("logout", Date.now().toString());
            window.location.pathname = loginUrl;
        } else {
            Router.push(loginUrl);
        }
        enqueueSnackbar("Odhlášení proběhlo úspěšně", { variant: "success" });
    };

    const setToken = (token: string | null): void => {
        if (token) {
            setCurrentToken(token);
        } else {
            setCurrentToken(null);
        }
        setTokenCookie(token);
    };

    const getDbUser = async (): Promise<getLogged_logged | null> => {
        const { data: { logged }, errors } = await client.query<getLogged>({ query: getLoggedUser });
        if (errors?.length > 0) {
            console.log(errors);
            return null;
        }
        return logged;
    };

    const getLocalUser = (): getLogged_logged | null => {
        if (window) {
            const uString = window.localStorage.getItem("user");
            return JSON.parse(uString) as getLogged_logged;
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
            setUser(user);
        } catch (e) {
            setToken(null);
        }
    };

    const setUser = (user: getLogged_logged): void => {
        if (!window) {
            return;
        }
        if (!user) {
            window.localStorage.removeItem(UserKey);
            setCurrentUser(null);
            return;
        }
        window.localStorage.setItem(UserKey, JSON.stringify(user));
        setCurrentUser(user);
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

    // useEffect(() => {
    //     if (currentToken) {
    //         checkSession();
    //     }

    //     return () => {
    //     };
    // }, [currentToken]);

    return (
        <ReactAuthContext.Provider value={{
            user: currentUser,
            token: currentToken,
            login,
            refreshTokenAsync,
            logout,
        }}>
            {children}
        </ReactAuthContext.Provider>
    );
};

export const AuthContext = {
    Provider: AuthContextProvider,
    Consumer: ReactAuthContext.Consumer,
};
