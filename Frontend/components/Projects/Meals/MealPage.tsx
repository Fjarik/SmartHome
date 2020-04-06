import { FunctionComponent } from "react";
import { getBasicMeals } from "../../../src/graphql/types/getBasicMeals";
import { getMealsBasic } from "../../../src/graphql/queries";
import CenterLoading from "../../Loading/CenterLoading";
import { Button, Container, TableContainer, Table, Paper, TableHead, TableRow, TableCell, TableBody, Grid } from "@material-ui/core";
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
        <Container>
            <Grid container justify="space-between" style={{ marginBottom: "1rem" }}>
                <Grid item>
                    <Button onClick={() => refetch()}>Refetch</Button>
                </Grid>
                <Grid item>
                    <Button variant="contained" color="secondary">
                        Přidat nové jídlo
                    </Button>
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
                        {meals.map((i) => (
                            <TableRow key={i.id}>
                                <TableCell>{i.id}</TableCell>
                                <TableCell>{i.date}</TableCell>
                                <TableCell>{i.type}</TableCell>
                                <TableCell>{i.food.name}</TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>

        </Container>
    );
};

export default MealPage;
