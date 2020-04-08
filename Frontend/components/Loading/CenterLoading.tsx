import { FunctionComponent } from "react";
import { Grid, CircularProgress, Typography, makeStyles, Theme, createStyles } from "@material-ui/core";


const useStyles = makeStyles((theme: Theme) =>
    createStyles({
        mainGrid: {
            marginTop: "15rem",
            justifyContent: "center",
            alignItems: "center"
        },
        gridItem: {
            textAlign: "center",
        },
        mainText: {
            marginTop: "0.5rem",
        }
    }));

interface LoadingProps {
    text?: string
}

const CenterLoading: FunctionComponent<LoadingProps> = ({ text = "Probíhá načítání" }) => {

    const c = useStyles();

    return (
        <Grid container className={c.mainGrid} >
            <Grid item className={c.gridItem}>
                <CircularProgress color="secondary" />
                <Typography variant="h6" color="primary" className={c.mainText}>
                    {text}
                </Typography>
            </Grid>
        </Grid>
    );
};

export default CenterLoading;
