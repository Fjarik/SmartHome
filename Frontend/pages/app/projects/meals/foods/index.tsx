import { NextPage } from "next";
import Layout from "../../../../../components/Layouts/Layout";
import FoodPage from "../../../../../components/Projects/Meals/FoodPage";

const FoodsPage: NextPage = () => {
    return (
        <Layout title="Jídla">
            <FoodPage />
        </Layout>
    );
};

export default FoodsPage;
