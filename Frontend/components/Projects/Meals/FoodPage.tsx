import { FunctionComponent, useState } from "react";
import { getAllFoods } from "../../../src/graphql/queries";
import CenterLoading from "../../Loading/CenterLoading";
import { Container, TableContainer, Table, Paper, TableHead, TableRow, TableCell, TableBody, Grid, ButtonGroup, Typography } from "@material-ui/core";
import { useQuery } from "react-apollo";
import { allFoods, allFoods_foods } from "../../../src/graphql/types/allFoods";
import { FoodTypeEnum } from "../../../src/graphql/graphql-global-types";
import FoodTable from "./Foods/FoodTable";

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

    const { foods } = data;

    const sorted = foods.sort((a, b) => a.name.localeCompare(b.name));
    const soups = sorted.filter(x => x.type === FoodTypeEnum.SOUP);
    const main = sorted.filter(x => x.type === FoodTypeEnum.MAIN_MEAL);
    const sides = sorted.filter(x => x.type === FoodTypeEnum.SIDE_DISH);
    const deserts = sorted.filter(x => x.type === FoodTypeEnum.DESERT);

    return (
        <Container>
            <Grid container justify="space-between" style={{ marginBottom: "1rem" }}>
                <Grid item>
                </Grid>
                <Grid item>
                </Grid>
            </Grid>
            <Grid container justify="center" spacing={2}>
                <Grid item xs={12}>
                    <FoodTable data={main} title="Hlavní jídla" showSides={true} sides={sides} />
                </Grid>
                <Grid item xs={12} md={6}>
                    <FoodTable data={soups} title="Polévky" />
                </Grid>
                <Grid item xs={12} md={6}>
                    <FoodTable data={sides} title="Přílohy" />
                </Grid>
                <Grid item xs={12} md={6}>
                    <FoodTable data={deserts} title="Dezerty" />
                </Grid>
            </Grid>

        </Container>
    );
};

export default FoodPage;
