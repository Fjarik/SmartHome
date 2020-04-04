import { FunctionComponent } from "react";
import { Grid, Typography, Container, Card, CardContent, CardActions, Button, Link } from "@material-ui/core";
import customUrls from "../../utils/customUrls";

const Dashboard: FunctionComponent = () => {
    const { app: { projectsUrls: { calendarUrl } } } = customUrls;

    return (<>
        <Container>
            <Grid container justify="center" alignItems="center" >
                <Grid item>
                </Grid>
                <Grid item>
                    <Card>
                        <CardContent>
                            <Typography variant="h5">
                                Kalendář
                            </Typography>
                        </CardContent>
                        <CardActions>
                            <Link href={calendarUrl} >
                                <Button>Přejít</Button>
                            </Link>
                        </CardActions>
                    </Card>
                </Grid>
            </Grid>
        </Container>
    </>
    );
};

export default Dashboard;
