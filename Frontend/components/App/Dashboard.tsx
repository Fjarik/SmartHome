import { FunctionComponent } from "react";
import { Grid, Paper, Typography, Container, Divider, Card, CardContent, CardActions, Button } from "@material-ui/core";

const Dashboard: FunctionComponent = () => {
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
                            <Button>Přejít</Button>
                        </CardActions>
                    </Card>
                </Grid>
            </Grid>
        </Container>
    </>
    );
};

export default Dashboard;
