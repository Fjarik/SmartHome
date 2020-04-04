import { NextPage } from "next";
import Dashboard from "../../components/App/Dashboard";
import Layout from "../../components/Layouts/Layout";

const Index: NextPage = () => {
    return (
        <Layout title="Aplikace">
            <Dashboard />
        </Layout>
    );
};

export default Index;
