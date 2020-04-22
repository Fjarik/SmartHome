import { FunctionComponent, useState, Fragment } from "react";
import { getBasicMeals_meals } from "../../../../src/graphql/types/getBasicMeals";
import { Grid, makeStyles, Theme, createStyles, Typography } from "@material-ui/core";
import MealRow from "./MealRow";
import MealHeader from "./MealHeader";

const useStyles = makeStyles((theme: Theme) =>
    createStyles({
        container: {
            backgroundColor: theme.palette.background.paper,
        },
        mealRow: {
            "&:not(:last-child)": {
                marginBottom: "-8px",
            }
        },
    })
);

interface IMealsTableProps {
    meals: Array<getBasicMeals_meals[]>;
}

const MealsTable: FunctionComponent<IMealsTableProps> = ({ meals }) => {
    const [data, setData] = useState<Array<getBasicMeals_meals[]>>(meals);
    const c = useStyles();

    return (
        <Grid container direction="column" justify="flex-start" alignItems="stretch" className={c.container}>
            {
                data.map((elements, i) =>
                    <Fragment key={i}>
                        <Grid item style={{ padding: 0 }}>
                            <MealHeader originalDate={elements[0].date} />
                        </Grid>
                        {
                            elements.map((elm, j) =>
                                <Grid item key={j} className={c.mealRow} >
                                    <MealRow meal={elm} />
                                </Grid>
                            )
                        }
                    </Fragment>
                )
            }
        </Grid>
    );
};

export default MealsTable;
