import { NextPage } from "next";
import Layout from "../../../../components/Layouts/Layout";
import MealPage from "../../../../components/Projects/Meals/MealPage";

const index: NextPage = () => {
    return (
        <Layout title="Jídelníček">
            <MealPage />
        </Layout>
    );
};

export default index;
