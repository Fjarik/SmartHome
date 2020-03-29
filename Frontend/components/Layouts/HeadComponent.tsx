import { FunctionComponent } from "react";
import Head from "next/head";

const HeadComponent: FunctionComponent = ({ children }) => {

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
