import Cookies from "universal-cookie";
import { TokenInfoKey, UserKey } from "../../src/Global/Keys";
import { refreshTokenVariables, refreshToken } from "../../src/graphql/types/refreshToken";
import { ApolloClient } from "apollo-client";
import { refreshTokenMutation } from "../../src/graphql/mutations";
import { IUser } from "../../src/IUser";

export const clearTokenCookie = () => {
    const cookies = new Cookies();

    cookies.set("Authorization", "", { path: "/", maxAge: -1, sameSite: "strict" });
    // cookies.remove(UserTokenCookieKey);
};

export const getRefreshToken = (): string | null => {
    if (!!window && typeof (window) !== "undefined") {
        const rToken = window.localStorage.getItem(TokenInfoKey);
        if (!rToken) {
            return null;
        }
        return rToken;
    }
    return null;
};

export const setRefreshToken = (refreshToken: string): void => {
    if (!window) {
        return;
    }
    if (!refreshToken) {
        window.localStorage.removeItem(TokenInfoKey);
        return;
    }
    window.localStorage.setItem(TokenInfoKey, refreshToken);
};

export const refreshTokenAsync = async (client: ApolloClient<any>): Promise<string | null> => {
    const rToken = getRefreshToken();
    if (!rToken) {
        return null;
    }

    const { data, errors } = await client.mutate<refreshToken, refreshTokenVariables>({
        mutation: refreshTokenMutation,
        variables: {
            refreshToken: rToken
        }
    });

    if (errors) {
        console.error(errors);
        return null;
    }

    const { refreshToken: { refreshToken } } = data;

    setRefreshToken(refreshToken);
    return refreshToken;
};

export const setLocalUser = (user: IUser): void => {
    if (!window || !window.localStorage) {
        console.error("Could not set local user while in SSR");
        return;
    }

    if (!user) {
        window.localStorage.removeItem(UserKey);
        return;
    }
    window.localStorage.setItem(UserKey, JSON.stringify(user));
};

export const getLocalUser = (): IUser | null => {
    if (!window || !window.localStorage) {
        console.error("Could not load local user while in SSR");
        return null;
    }

    const uString = window.localStorage.getItem(UserKey);
    if (!uString) {
        return null;
    }

    return JSON.parse(uString) as IUser;
};
