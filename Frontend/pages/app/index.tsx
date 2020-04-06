import { NextPage } from "next";
import Dashboard from "../../components/App/Dashboard";
import Layout from "../../components/Layouts/Layout";
import withUser from "../../lib/withUser";

const Index: NextPage = () => {
    return (
        <Layout title="Aplikace">
            <Dashboard />
        </Layout>
    );
};

export default withUser(Index);
