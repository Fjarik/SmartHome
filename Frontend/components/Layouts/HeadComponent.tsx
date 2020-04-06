import { FunctionComponent, useEffect } from "react";
import Head from "next/head";
import Router from "next/router";
import customUrls from "../../utils/customUrls";

const HeadComponent: FunctionComponent = ({ children }) => {
    const { account: { loginUrl } } = customUrls;

    const syncLogout = (event: StorageEvent) => {
        if (event.key === "logout") {
            console.log("Logged out");
            if (window) {
                window.location.reload();
            }
            Router.push(loginUrl);
        }
    };

    useEffect(() => {
        window.addEventListener("storage", syncLogout);
        return () => {
            if (window) {
                window.removeEventListener("storage", syncLogout);
                window.localStorage.removeItem("logout");
            }
        };
    }, []);

    return <>
        <Head>
            <meta name="viewport" content="initial-scale=1.0, width=device-width" />
            <meta charSet="utf-8" />
            <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap" />
            <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons" />
            <link rel="shortcut icon" href="/images/logos/MainColor.ico" />
        </Head>
        {children}
    </>;
};

export default HeadComponent;
