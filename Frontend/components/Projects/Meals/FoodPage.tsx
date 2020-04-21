import { FunctionComponent } from "react";
import { getAllFoods } from "../../../src/graphql/queries";
import CenterLoading from "../../Loading/CenterLoading";
import { Container, Grid, Button } from "@material-ui/core";
import { useQuery } from "react-apollo";
import { allFoods } from "../../../src/graphql/types/allFoods";
import { FoodTypeEnum } from "../../../src/graphql/graphql-global-types";
import FoodTable from "./Foods/FoodTable";
import { useRouter } from "next/router";
import customUrls from "../../../utils/customUrls";

const FoodPage: FunctionComponent = () => {
    const { data, loading, error } = useQuery<allFoods>(getAllFoods);
    const { app: { projectsUrls: { meals: { mealsIndex, addMeal } } } } = customUrls;
    const router = useRouter();

    const handleMealIndex = (): void => {
        router.push(mealsIndex);
    };

    const handleAddMeal = (): void => {
        router.push(addMeal);
    };

    if (loading || !data) {
        return <CenterLoading text="Načítání" />;
    }

    if (error) {
        return <p>{error}</p>;
    }

    const { foods, categories } = data;

    const sorted = foods.sort((a, b) => a.name.localeCompare(b.name));
    const soups = sorted.filter(x => x.type === FoodTypeEnum.SOUP);
    const main = sorted.filter(x => x.type === FoodTypeEnum.MAIN_MEAL);
    const sides = sorted.filter(x => x.type === FoodTypeEnum.SIDE_DISH);
    const deserts = sorted.filter(x => x.type === FoodTypeEnum.DESERT);

    return (
        <Container>
            <Grid container justify="space-between" style={{ marginBottom: "1rem" }}>
                <Grid item>
                    <Button onClick={handleMealIndex}>
                        Zpět na výpis
                    </Button>
                </Grid>
                <Grid item>
                    <Button color="primary"
                        onClick={handleAddMeal}>
                        Nastavit obědy
                    </Button>
                </Grid>
            </Grid>
            <Grid container justify="center" spacing={2}>
                <Grid item xs={12}>
                    <FoodTable inputData={main} type={FoodTypeEnum.MAIN_MEAL} categories={categories} title="Hlavní jídla" showSides={true} sides={sides} />
                </Grid>
                <Grid item xs={12} md={6}>
                    <FoodTable inputData={soups} type={FoodTypeEnum.SOUP} categories={categories} title="Polévky" />
                </Grid>
                <Grid item xs={12} md={6}>
                    <FoodTable inputData={sides} type={FoodTypeEnum.SIDE_DISH} categories={categories} title="Přílohy" />
                </Grid>
                <Grid item xs={12} md={6}>
                    <FoodTable inputData={deserts} type={FoodTypeEnum.DESERT} categories={categories} title="Dezerty" />
                </Grid>
            </Grid>
        </Container>
    );
};

export default FoodPage;
