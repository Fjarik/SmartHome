import { FunctionComponent, useState } from "react";
import { getAllFoods } from "../../../src/graphql/queries";
import CenterLoading from "../../Loading/CenterLoading";
import { Container, TableContainer, Table, Paper, TableHead, TableRow, TableCell, TableBody, Grid, ButtonGroup, Typography } from "@material-ui/core";
import { useQuery } from "react-apollo";
import { allFoods, allFoods_foods } from "../../../src/graphql/types/allFoods";
import { FoodTypeEnum } from "../../../src/graphql/graphql-global-types";

const FoodPage: FunctionComponent = () => {
    const { data, loading, error } = useQuery<allFoods>(getAllFoods);

    const getTable = (foods: allFoods_foods[], title: string) => {
        return <>
            <Typography variant="h5">
                {title}
            </Typography>
            <TableContainer component={Paper}>
                <Table size="small">
                    <TableHead>
                        <TableRow>
                            <TableCell>ID</TableCell>
                            <TableCell>Název</TableCell>
                            <TableCell></TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {foods.map((i) => {
                            return (
                                <TableRow key={i.id}>
                                    <TableCell>{i.id}</TableCell>
                                    <TableCell>{i.name}</TableCell>
                                    <TableCell>

                                    </TableCell>
                                </TableRow>
                            );
                        })}
                    </TableBody>
                </Table>
            </TableContainer>
        </>;
    };

    if (loading || !data) {
        return <CenterLoading text="Načítání" />;
    }

    if (error) {
        return <p>{error}</p>;
    }

    const { foods, sidedishes } = data;

    const sorted = foods.sort((a, b) => a.name.localeCompare(b.name));
    const soups = sorted.filter(x => x.type === FoodTypeEnum.SOUP);
    const main = sorted.filter(x => x.type === FoodTypeEnum.MAIN_MEAL);
    const deserts = sorted.filter(x => x.type === FoodTypeEnum.DESERT);

    return (
        <Container>
            <Grid container justify="space-between" style={{ marginBottom: "1rem" }}>
                <Grid item>
                </Grid>
                <Grid item>
                </Grid>
            </Grid>
            <Grid container spacing={2}>
                <Grid item>
                    {getTable(soups, "Polévky")}
                </Grid>
                <Grid item>
                    {getTable(main, "Hlavní jídla")}
                </Grid>
                <Grid item>
                    {getTable(deserts, "Dezerty")}
                </Grid>
                <Grid item>
                </Grid>
            </Grid>

        </Container>
    );
};

export default FoodPage;
