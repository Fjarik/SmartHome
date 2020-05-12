import React, { createContext, FunctionComponent, useState, useEffect } from "react";
import { login, loginVariables } from "src/graphql/types/login";
import { loginMutation, logoutMutation } from "src/graphql/mutations";
import { getLogged } from "src/graphql/types/getLogged";
import { getLoggedUser } from "src/graphql/queries";
import Router from "next/router";
import { logout, logoutVariables } from "src/graphql/types/logout";
import { useApolloClient } from "react-apollo";
import customUrls from "utils/customUrls";
import { useSnackbar } from "notistack";
import { ApolloClient } from "apollo-client";
import { clearTokenCookie, setRefreshToken, setLocalUser, getLocalUser, getRefreshToken } from "./authService";
import { IUser } from "src/IUser";

export interface IAuthContext {
    user: IUser | null;
    login: (googleToken: string) => Promise<void>;
    logout: () => Promise<void>;
    loading: boolean;
}

const defaultContext: IAuthContext = {
    user: null,
    login: () => null,
    logout: () => null,
    loading: false,
};

export const ReactAuthContext = createContext<IAuthContext>(defaultContext);

const AuthContextProvider: FunctionComponent<{}> = ({ children }) => {

    const [currentUser, setCurrentUser] = useState<IUser | null>(defaultContext.user);
    const [isLoading, setIsLoading] = useState<boolean>(true);
    const client = useApolloClient();
    const { enqueueSnackbar } = useSnackbar();
    const { account: { loginUrl } } = customUrls;

    const clearAll = (): void => {
        clearTokenCookie();
        setCurrentUser(null);
        setRefreshToken(null);
    };

    const login = async (googleToken: string): Promise<void> => {
        const { data: { login: { authToken, ...user } }, errors, } = await client.mutate<login, loginVariables>({
            mutation: loginMutation,
            variables: { googleToken }
        });
        if (errors?.length > 0) {
            console.log(errors);
            return;
        }
        setCurrentUser(user);

        const { refreshToken } = authToken;

        setRefreshToken(refreshToken);

        return;
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

    const getDbUser = async (client: ApolloClient<any>): Promise<IUser | null> => {
        const { data: { logged }, errors } = await client.query<getLogged>({ query: getLoggedUser });
        if (errors?.length > 0) {
            console.log(errors);
            return null;
        }
        return logged;
    };

    const checkSession = async (): Promise<void> => {
        try {
            const user = await getDbUser(client);
            if (!user) {
                await logout();
                return;
            }
            setCurrentUser(user);
        } catch (e) {
            console.error(e);
        }
    };

    useEffect(() => {
        if (getRefreshToken()) {
            const logged = getLocalUser();
            setCurrentUser(logged);

            if (!logged) {
                checkSession();
            }
        }
        setIsLoading(false);
        return () => {
        };
    }, []);

    useEffect(() => {
        setLocalUser(currentUser);

        return () => {

        };
    }, [currentUser]);

    return (
        <ReactAuthContext.Provider value={{
            user: currentUser,
            login,
            logout,
            loading: isLoading,
        }}>
            {children}
        </ReactAuthContext.Provider>
    );
};

export const AuthContext = {
    Provider: AuthContextProvider,
    Consumer: ReactAuthContext.Consumer,
};
