import { FunctionComponent } from "react";
import { Grid, Typography, makeStyles, Theme, createStyles, IconButton } from "@material-ui/core";
import { getRelativeDateString } from "../../../../lib/dateUtils";
import AddIcon from "@material-ui/icons/Add";

const useStyles = makeStyles((theme: Theme) =>
    createStyles({
        date: {
            marginLeft: "0.75rem",
        },
        container: {
            paddingTop: "0.5rem",
            paddingBottom: "0.5rem",
            backgroundColor: theme.palette.type === "light" ? theme.palette.grey[200] : theme.palette.grey.A700
        },
        add: {
            marginRight: "0.55rem",
        },
    })
);

interface IMealHeaderProps {
    originalDate: string;
}

const MealHeader: FunctionComponent<IMealHeaderProps> = ({ originalDate }) => {
    const c = useStyles();

    return (
        <Grid container item direction="row" justify="space-between" alignItems="center" className={c.container}>
            <Grid item className={c.date}>
                <Typography variant="h6">
                    {
                        getRelativeDateString(originalDate)
                    }
                </Typography>
            </Grid>
            <Grid item className={c.add}>
                <IconButton size="small">
                    <AddIcon />
                </IconButton>
            </Grid>
        </Grid>
    );
};

export default MealHeader;
