import { FunctionComponent, useState } from "react";
import { getBasicMeals } from "../../../src/graphql/types/getBasicMeals";
import { getMealsBasic } from "../../../src/graphql/queries";
import CenterLoading from "../../Loading/CenterLoading";
import { Container, TableContainer, Table, Paper, TableHead, TableRow, TableCell, TableBody, Grid, Button } from "@material-ui/core";
import { useQuery } from "react-apollo";
import { DateTime } from "luxon";
import NewMealsButton from "./AddMeals/NewMealsButton";
import customUrls from "../../../utils/customUrls";
import { useRouter } from "next/router";

const MealPage: FunctionComponent = () => {
    const { data, loading, error } = useQuery<getBasicMeals>(getMealsBasic, { ssr: false });
    const { app: { projectsUrls: { meals: { foodsIndex } } } } = customUrls;
    const router = useRouter();

    const handleShowFoods = () => {
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
            <TableContainer component={Paper}>
                <Table>
                    <TableHead>
                        <TableRow>
                            <TableCell>ID</TableCell>
                            <TableCell>Datum</TableCell>
                            <TableCell>Typ</TableCell>
                            <TableCell>Jídlo</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {meals.map((i) => {
                            const d = DateTime.fromISO(i.date);
                            const dateString = d.toRelative({ locale: "cz" })
                                + " ("
                                + d.toLocaleString({ locale: "cz" })
                                + ")";
                            return <TableRow key={i.id}>
                                <TableCell>{i.id}</TableCell>
                                <TableCell>{dateString}</TableCell>
                                <TableCell>{i.type}</TableCell>
                                <TableCell>{i.food.name}</TableCell>
                            </TableRow>;
                        })}
                    </TableBody>
                </Table>
            </TableContainer>

        </Container>
    );
};

export default MealPage;
