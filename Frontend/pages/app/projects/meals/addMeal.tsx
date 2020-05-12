import { NextPage } from "next";
import Layout from "components/Layouts/Layout";
import withUser from "lib/withUser";
import AddMeals from "components/Projects/Meals/AddMeals/AddMeals";
import { useRouter } from "next/router";
import { MealTimeEnum } from "src/graphql/graphql-global-types";

const addMeal: NextPage = () => {
    const { query: { time } } = useRouter();

    return (
        <Layout title="Přidat jídlo">
            <AddMeals time={MealTimeEnum["" + time]} />
        </Layout>
    );
};

export default withUser(addMeal);
