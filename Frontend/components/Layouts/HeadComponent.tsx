import { FunctionComponent, useEffect } from "react";
import Head from "next/head";
import Router from "next/router";

const HeadComponent: FunctionComponent = ({ children }) => {
    const syncLogout = (event: StorageEvent) => {
        if (event.key === 'logout') {
            console.log('logged out from storage!')
            if (window) {
                window.location.reload();
            }
            Router.push('/login')
        }
    };

    useEffect(() => {
        window.addEventListener('storage', syncLogout);
        return () => {
            if (window) {
                window.removeEventListener('storage', syncLogout);
                window.localStorage.removeItem('logout')
            }
        }
    }, []);

    return <>
        <Head>
            <meta name="viewport" content="initial-scale=1.0, width=device-width" />
            <meta charSet="utf-8" />
            <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap" />
            <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons" />
            <link rel="shortcut icon" href="/static/images/favicon/favicon.ico" />
        </Head>
        {children}
    </>;
};

export default HeadComponent;
