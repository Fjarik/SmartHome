import { FunctionComponent, useState } from "react";
import { getBasicMeals, getBasicMeals_meals } from "../../../src/graphql/types/getBasicMeals";
import { getMealsBasic } from "../../../src/graphql/queries";
import CenterLoading from "../../Loading/CenterLoading";
import { Container, TableContainer, Table, Paper, TableHead, TableRow, TableCell, TableBody, Grid, Button } from "@material-ui/core";
import { useQuery } from "react-apollo";
import { DateTime } from "luxon";
import NewMealsButton from "./AddMeals/NewMealsButton";
import customUrls from "../../../utils/customUrls";
import { useRouter } from "next/router";
import { MealTypeEnum } from "../../../src/graphql/graphql-global-types";
import MealOtherButton from "./Other/MealOther";
import { groupBy, toArray } from "lodash";

const MealPage: FunctionComponent = () => {
    const { data, loading, error } = useQuery<getBasicMeals>(getMealsBasic, { ssr: false });
    const { app: { projectsUrls: { meals: { foodsIndex } } } } = customUrls;
    const router = useRouter();

    const handleShowFoods = (): void => {
        router.push(foodsIndex);
    };

    const getTypeString = (type: MealTypeEnum): string => {
        switch (type) {
            case MealTypeEnum.FOOD_BOX:
                return "Krabička";
            case MealTypeEnum.GRANDMA:
                return "Babička :)";
            case MealTypeEnum.NORMAL:
                return "Normální jídlo";
            case MealTypeEnum.OTHER:
                return "Ostatní";
            case MealTypeEnum.RESTAURANT:
                return "Restaurace";
            default:
                return "Chyba";
        }
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
            <TableContainer component={Paper}>
                <Table>
                    <TableHead>
                        <TableRow>
                            <TableCell>ID</TableCell>
                            <TableCell>Jídlo</TableCell>
                            <TableCell>Typ</TableCell>
                            <TableCell>Akce</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {
                            //@ts-ignore
                            toArray(groups).map((element, i) =>
                                <>
                                    <TableRow key={i}>
                                        <TableCell>{element[0].date}</TableCell>
                                        <TableCell />
                                        <TableCell />
                                        <TableCell />
                                    </TableRow>
                                    {
                                        element.map((i) => {
                                            const d = DateTime.fromISO(i.date);
                                            const dateString = d.toRelativeCalendar({ locale: "cz" })
                                                + " ("
                                                + d.toLocaleString({ locale: "cz" })
                                                + ")";
                                            return <TableRow key={i.id}>
                                                <TableCell>{i.id}</TableCell>
                                                {/* <TableCell>{dateString}</TableCell> */}
                                                <TableCell>{i.food.name}</TableCell>
                                                <TableCell>{getTypeString(i.type)}</TableCell>
                                                <TableCell><MealOtherButton id={i.id} /></TableCell>
                                            </TableRow>;
                                        })
                                    }
                                </>
                            )

                        }
                    </TableBody>
                </Table>
            </TableContainer>

        </Container>
    );
};

export default MealPage;
