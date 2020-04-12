import { FunctionComponent } from "react";
import { Grid, Typography, Container, Card, CardContent, CardActions, Button, Link, CardHeader, makeStyles, Theme, createStyles } from "@material-ui/core";
import EventNoteIcon from "@material-ui/icons/EventNote";
import RestaurantIcon from "@material-ui/icons/Restaurant";
import customUrls from "../../utils/customUrls";

const useStyles = makeStyles((theme: Theme) => createStyles({
    customCard: {
        height: "100%",
        display: "flex",
        flexDirection: "column",
        justifyContent: "space-between",
    }
}));

const Dashboard: FunctionComponent = () => {
    const c = useStyles();
    const { app: { projectsUrls: { calendarUrl, meals: { mealsIndex } } } } = customUrls;

    const apps = [
        {
            title: "Kalendář",
            avatar: <EventNoteIcon />,
            subheader: "Všechny plánované události",
            content: "Přehledný kalendář pro celou vaši domácnost.",
            url: calendarUrl
        },
        {
            title: "Jídelníček",
            avatar: <RestaurantIcon />,
            subheader: "Aktuálné plánovaná jídla",
            content: "Vytvořte si, nebo si nechejte vygenerovat jídelníček pro celou rodinu.",
            url: mealsIndex
        }
    ];

    return (
        <Container>
            <Grid container justify="space-around" alignItems="stretch" spacing={2} >
                {apps.map((i, index) => (
                    <Grid item key={index} xs={12} sm={6} md={4} xl={3}>
                        <Card className={c.customCard}>
                            <CardHeader title={i.title}
                                avatar={i.avatar}
                                subheader={i.subheader}
                            />
                            <CardContent>
                                <Typography variant="body1">
                                    {i.content}
                                </Typography>
                            </CardContent>
                            <CardActions>
                                <Link href={i.url} >
                                    <Button>Přejít do aplikace</Button>
                                </Link>
                            </CardActions>
                        </Card>
                    </Grid>
                ))}
            </Grid>
        </Container>
    );
};

export default Dashboard;
