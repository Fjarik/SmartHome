import { NextPage } from "next";
import Layout from "../../../../components/Layouts/Layout";
import withUser from "../../../../lib/withUser";

const index: NextPage = () => {
    return (
        <Layout title="Kalendář">

        </Layout>
    );
};

export default withUser(index);
