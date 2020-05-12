import { FunctionComponent, useState, Fragment } from "react";
import { getBasicMeals_meals } from "src/graphql/types/getBasicMeals";
import { Grid, makeStyles, Theme, createStyles } from "@material-ui/core";
import MealRow from "./MealRow";
import MealHeader from "./MealHeader";
import { groupBy, toArray } from "lodash";
import { DateTime } from "luxon";
import { useApolloClient } from "react-apollo";
import { removeMeal, removeMealVariables } from "src/graphql/types/removeMeal";
import { removeMealMutation } from "src/graphql/mutations";
import { useSnackbar } from "notistack";

const useStyles = makeStyles((theme: Theme) =>
    createStyles({
        container: {
            backgroundColor: theme.palette.background.paper,
        },
    })
);

interface IMealsTableProps {
    meals: getBasicMeals_meals[];
}

const MealsTable: FunctionComponent<IMealsTableProps> = ({ meals }) => {
    const { fromISO, local } = DateTime;
    //.filter(x => fromISO(x.date) > local().minus({ days: 2 }))
    const [data, setData] = useState<getBasicMeals_meals[]>(meals);
    const c = useStyles();
    const client = useApolloClient();
    const { enqueueSnackbar } = useSnackbar();

    const sorted = data.sort((a, b) => {
        const one = fromISO(a.date);
        const two = fromISO(b.date);
        if (one === two) {
            return 0;
        }
        if (one > two) {
            return 1;
        }
        return -1;
    });

    const groups = groupBy(sorted, x => x.date);
    const groupped = toArray(groups);

    const handleDelete = async (id: string, incRelated: boolean): Promise<void> => {
        const original = data;
        setData([
            ...data.filter(x => x.id !== id)
        ]);

        const { data: { removeMeal }, errors } = await client.mutate<removeMeal, removeMealVariables>({
            mutation: removeMealMutation,
            variables: {
                id: id,
                incRelated: incRelated
            }
        });

        if (errors || !removeMeal) {
            console.error(errors);
            enqueueSnackbar("Vyskytla se chyba při odstraňování");
            setData([
                ...original
            ]);
            return;
        }
    };

    return (
        <Grid container direction="column" justify="flex-start" alignItems="stretch" className={c.container}>
            {
                groupped.map((elements, i) =>
                    <Fragment key={i}>
                        <MealHeader originalDate={elements[0].date} />
                        {
                            elements.map((elm, j) =>
                                <MealRow key={j} meal={elm} onDelete={handleDelete} />
                            )
                        }
                    </Fragment>
                )
            }
        </Grid>
    );
};

export default MealsTable;
