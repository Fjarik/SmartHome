import { FunctionComponent } from "react";
import Head from "next/head";

interface IProps {
    title?: string;
}
const Layout: FunctionComponent<IProps> = ({ children, title = "Stránka" }) => {

    return <div>
        <Head>
            <title>Domácnost - {title}</title>
        </Head>
        <main >
            {children}
        </main>
    </div>;
};

export default Layout;