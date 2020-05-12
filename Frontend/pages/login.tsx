import { NextPage } from "next";
import Layout from "components/Layouts/Layout";
import LoginPageComponent from "components/Login/LoginPageComponent";

const LoginPage: NextPage = () => {
    return (
        <Layout title="Přihlášení">
            <LoginPageComponent />
        </Layout>
    );
};

export default LoginPage;
