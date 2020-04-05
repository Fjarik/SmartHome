import { FunctionComponent, useContext } from "react";
import Link from "next/link";
import { ReactAuthContext } from "../../src/graphql/auth";
import { Grid, Button, makeStyles, Theme, Typography } from "@material-ui/core";
import customUrls from "../../utils/customUrls";

const useStyles = makeStyles((theme: Theme) =>
    ({
        menuButton: {
            borderRadius: 25,
        },
        mainText: {
            textAlign: "center",
        },
        mainGrid: {
            [theme.breakpoints.up("md")]: {
                marginTop: "15rem",
            }
        },
    }));

const HomePage: FunctionComponent<{}> = () => {
    const { user } = useContext(ReactAuthContext);
    const isLoggedIn = () => !!user;

    const c = useStyles();

    const { app: { appUrl }, account: { loginUrl } } = customUrls;

    const getLink = () => {
        return isLoggedIn() ? appUrl : loginUrl;
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
                        {isLoggedIn() ? "Přejít do aplikace" : "Vyzkoušet aplikaci"}
                    </Button>
                </Link>
            </Grid>
        </Grid>
    </>
    );

};

export default HomePage;