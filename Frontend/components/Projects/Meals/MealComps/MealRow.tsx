import { FunctionComponent } from "react";
import { Grid, makeStyles, Theme, createStyles, Typography } from "@material-ui/core";
import { getBasicMeals_meals } from "../../../../src/graphql/types/getBasicMeals";
import { getTypeString, getTimeString } from "../../../../lib/enumHelpers";

const useStyles = makeStyles((theme: Theme) =>
    createStyles({
        container: {
            paddingTop: "0.5rem",
            paddingBottom: "0.5rem",
            "&:hover": {
                backgroundColor: theme.palette.action.hover,
            },
        },
        time: {
            textAlign: "center",
            borderRightWidth: 3,
            borderRightColor: "#48DA63",
            borderRightStyle: "solid",
        },
        timeText: {
            paddingTop: "0.5rem",
            paddingBottom: "0.5rem",
        },
    })
);

interface IMealRowProps {
    meal: getBasicMeals_meals;
}

const MealRow: FunctionComponent<IMealRowProps> = ({ meal }) => {
    const c = useStyles();

    const { type, time, food: { name } } = meal;

    const typeString = getTypeString(type);
    const timeString = getTimeString(time);

    return (
        <Grid container direction="row" justify="space-between" alignItems="center" className={c.container} >
            <Grid item xs={2} sm={1} className={c.time}>
                <Typography variant="body1" className={c.timeText}>
                    {timeString}
                </Typography>
            </Grid>
            <Grid item xs={5} sm={6}>
                <Typography variant="body1">
                    {name}
                </Typography>
            </Grid>
            <Grid item xs={3} sm={2} >
                <Typography variant="body1">
                    {typeString}
                </Typography>
            </Grid>
            <Grid item xs={1} sm={2}></Grid>
        </Grid>
    );
};

export default MealRow;
