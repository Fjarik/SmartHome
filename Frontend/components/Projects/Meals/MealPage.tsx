import { FunctionComponent } from "react";
import { getBasicMeals, getBasicMealsVariables } from "../../../src/graphql/types/getBasicMeals";
import { getMealsBasic } from "../../../src/graphql/queries";
import CenterLoading from "../../Loading/CenterLoading";
import { Container, Grid, Button } from "@material-ui/core";
import { useQuery } from "react-apollo";
import NewMealsButton from "./AddMeals/NewMealsButton";
import customUrls from "../../../utils/customUrls";
import { useRouter } from "next/router";
import MealsTable from "./MealComps/MealsTable";

const MealPage: FunctionComponent = () => {
    const { data, loading, error } = useQuery<getBasicMeals, getBasicMealsVariables>(getMealsBasic, {
        variables: {
            date: "2020-4-24",
            daysAfter: 4,
            daysBefore: 1
        },
        ssr: false
    });
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
            <MealsTable meals={meals} />
        </Container>
    );
};

export default MealPage;
