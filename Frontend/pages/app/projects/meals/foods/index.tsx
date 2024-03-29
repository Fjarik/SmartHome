import { NextPage } from "next";
import Layout from "components/Layouts/Layout";
import FoodPage from "components/Projects/Meals/FoodPage";
import withUser from "lib/withUser";

const FoodsPage: NextPage = () => {
    return (
        <Layout title="Jídla">
            <FoodPage />
        </Layout>
    );
};

export default withUser(FoodsPage);
