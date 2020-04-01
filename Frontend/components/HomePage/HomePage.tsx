import { FunctionComponent, useContext } from "react";
import Link from "next/link";
import { ReactAuthContext } from "../../src/graphql/auth";
import { Grid, Button, makeStyles, createStyles, Theme, Typography, useTheme } from "@material-ui/core";

const useStyles = makeStyles((theme: Theme) =>
    createStyles({
        menuButton: {
            borderRadius: 25,
        },
        mainText: {
            textAlign: "center",
        },
        mainGrid: {
            marginTop: "15rem",
        },
    }));

const HomePage: FunctionComponent<{}> = () => {
    const { isLoggedIn: isLog, user } = useContext(ReactAuthContext);

    const theme = useTheme();
    const c = useStyles(theme);

    const isLoggedIn = (): boolean => isLog && !!user;

    const getLink = () => {
        return isLoggedIn() ? "/app" : "/login";
    };

    return (<>
        <Grid container justify="center" alignItems="center" className={c.mainGrid}>
            <Grid item className={c.mainText}>
                <Typography variant="h2" gutterBottom>
                    Platforma pro ovládání domácnosti
                </Typography>
                <Typography variant="h5" gutterBottom>
                    Spravujte byt či dům jednoduše a pohodlě na dálku ze svého počítače.
                </Typography>
                <br />
                <Link href={getLink()}>
                    <Button variant="contained"
                        className={c.menuButton}
                        size="large"
                        color="secondary">
                        Přejít do aplikace
                    </Button>
                </Link>
            </Grid>
        </Grid>
    </>
    );

}

export default HomePage;