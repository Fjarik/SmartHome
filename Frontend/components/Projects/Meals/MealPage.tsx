import { FunctionComponent } from "react";
import { getBasicMeals } from "../../../src/graphql/types/getBasicMeals";
import { getMealsBasic } from "../../../src/graphql/queries";
import CenterLoading from "../../Loading/CenterLoading";
import { Container, Grid, Button } from "@material-ui/core";
import { useQuery } from "react-apollo";
import NewMealsButton from "./AddMeals/NewMealsButton";
import customUrls from "../../../utils/customUrls";
import { useRouter } from "next/router";
import { groupBy, toArray } from "lodash";
import MealsTable from "./MealComps/MealsTable";

const MealPage: FunctionComponent = () => {
    const { data, loading, error } = useQuery<getBasicMeals>(getMealsBasic, { ssr: false });
    const { app: { projectsUrls: { meals: { foodsIndex } } } } = customUrls;
    const router = useRouter();

    const handleShowFoods = (): void => {
        router.push(foodsIndex);
    };

    if (loading || !data) {
        return <CenterLoading text="Načítání" />;
    }

    if (error) {
        return <p>{error}</p>;
    }

    const { meals } = data;

    const groups = groupBy(meals, x => x.date);

    return (
        <Container>
            <Grid container justify="space-between" alignItems="center" style={{ marginBottom: "1rem" }}>
                <Grid item>
                    <Button onClick={handleShowFoods}>
                        <span>Zobrazit všechna jídla</span>
                    </Button>
                </Grid>
                <Grid item>
                    <NewMealsButton />
                </Grid>
            </Grid>
            <MealsTable meals={toArray(groups)} />
        </Container>
    );
};

export default MealPage;
