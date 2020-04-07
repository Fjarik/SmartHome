import { FunctionComponent, useState } from "react";
import { getBasicMeals } from "../../../src/graphql/types/getBasicMeals";
import { getMealsBasic } from "../../../src/graphql/queries";
import CenterLoading from "../../Loading/CenterLoading";
import { Button, Container, TableContainer, Table, Paper, TableHead, TableRow, TableCell, TableBody, Grid } from "@material-ui/core";
import { useQuery } from "react-apollo";
import useDate from "../../../lib/useDate";
import AddMeal from "./AddMeal";

const MealPage: FunctionComponent = () => {
    const { data, loading, error, refetch } = useQuery<getBasicMeals>(getMealsBasic, { ssr: false, });
    const [isAddModalOpen, setIsAddModalOpen] = useState<boolean>(false);
    const d = useDate();

    const handleAddModalClose = () => {
        setIsAddModalOpen(false);
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
            <Grid container justify="space-between" style={{ marginBottom: "1rem" }}>
                <Grid item>
                    <Button onClick={() => refetch()}>Refetch</Button>
                </Grid>
                <Grid item>
                    {d().format("YYYY-MM-DD")}
                </Grid>
                <Grid item>
                    <Button variant="contained" color="secondary" onClick={() => setIsAddModalOpen(true)}>
                        Přidat nové jídlo
                    </Button>
                    <AddMeal isOpen={isAddModalOpen} handleClose={handleAddModalClose} />
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
                                <TableCell>{d(i.date).fromNow()}</TableCell>
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
