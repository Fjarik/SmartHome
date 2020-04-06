import { FunctionComponent } from "react";
import { getBasicMeals } from "../../../src/graphql/types/getBasicMeals";
import { getMealsBasic } from "../../../src/graphql/queries";
import CenterLoading from "../../Loading/CenterLoading";
import { Button } from "@material-ui/core";
import { useQuery } from "react-apollo";

const MealPage: FunctionComponent = () => {
    const { data, loading, error, refetch } = useQuery<getBasicMeals>(getMealsBasic, { ssr: false, });

    if (loading || !data) {
        return <CenterLoading text="Načítání" />;
    }

    if (error) {
        return <p>{error}</p>;
    }

    const { meals } = data;

    return (
        <div>
            <Button onClick={() => refetch()}>Refetch</Button>
            {meals.map((i, index) => {
                return <p key={index}>{i.id}</p>;
            })}
        </div>
    );
};

export default MealPage;
