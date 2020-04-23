import { FunctionComponent, ReactNode, useState, ChangeEvent } from "react";
import { Paper, Tabs, Tab, Container, Typography, makeStyles, Theme, createStyles, Grid, Switch } from "@material-ui/core";
import AddLunch from "./AddLunch";
import { MealTimeEnum } from "../../../../src/graphql/graphql-global-types";
import { KeyboardDatePicker } from "@material-ui/pickers";
import { DateTime } from "luxon";

interface ITabPanelProps {
    children?: ReactNode,
    index: MealTimeEnum,
    value: MealTimeEnum,
}

const useStyles = makeStyles((theme: Theme) =>
    createStyles({
        componentDiv: {
            marginTop: "2rem",
        },

    }),
);

const TabPanel: FunctionComponent<ITabPanelProps> = ({ children, index, value }) => {
    const c = useStyles();

    return index === value &&
        <div className={c.componentDiv}>
            {children}
        </div>;
};

interface IAddMealsProps {
    time?: MealTimeEnum;
}

const AddMeals: FunctionComponent<IAddMealsProps> = ({ time = MealTimeEnum.LUNCH }) => {
    const [value, setValue] = useState<MealTimeEnum>(time);
    const [selectedDate, setSelectedDate] = useState<DateTime>();
    const [isBox, setIsBox] = useState<boolean>(false);

    const handleChange = (event: ChangeEvent<{}>, newValue: MealTimeEnum) => {
        setValue(newValue);
    };

    const onDateChange = (date: DateTime): void => {
        setSelectedDate(date);
    };

    const onBoxChange = (event: ChangeEvent<HTMLInputElement>): void => {
        setIsBox(event.target.checked);
    };

    return (
        <Container>
            <Grid container direction="column" alignItems="center" justify="space-between" spacing={2}>
                <Grid item>
                    <Typography variant="h4">
                        Přidat jídlo
                    </Typography>
                </Grid>
                <Grid item>
                    <KeyboardDatePicker
                        disableToolbar
                        autoOk={true}
                        variant="inline"
                        label="Vyberte datum"
                        format="dd.MM.yyyy"
                        value={selectedDate}
                        onChange={onDateChange} />
                </Grid>
                {value === MealTimeEnum.LUNCH &&
                    <Grid item>
                        <Typography component="div">
                            <Grid container component="label" alignItems="center" spacing={1}>
                                <Grid item>
                                    Normální jídlo
                                </Grid>
                                <Grid item>
                                    <Switch
                                        checked={isBox}
                                        onChange={onBoxChange}
                                    />
                                </Grid>
                                <Grid item>
                                    Krabička
                                </Grid>
                            </Grid>
                        </Typography>
                    </Grid>
                }
                <Grid item style={{ alignSelf: "stretch" }}>
                    <Paper square>
                        <Tabs
                            value={value}
                            indicatorColor="primary"
                            textColor="primary"
                            onChange={handleChange}
                            centered
                        >
                            <Tab label="Snídaně" value={MealTimeEnum.BREAKFAST} />
                            <Tab label="Oběd" value={MealTimeEnum.LUNCH} />
                            <Tab label="Večeře" value={MealTimeEnum.DINNER} />
                        </Tabs>
                    </Paper>
                </Grid>
                <Grid item style={{ alignSelf: "stretch" }}>
                    <TabPanel value={value} index={MealTimeEnum.BREAKFAST}>
                        ToDo
                    </TabPanel>
                    <TabPanel value={value} index={MealTimeEnum.LUNCH}>
                        <AddLunch selectedDate={selectedDate} isBox={isBox} />
                    </TabPanel>
                    <TabPanel value={value} index={MealTimeEnum.DINNER}>
                        ToDo
                    </TabPanel>
                </Grid>
            </Grid>
        </Container>
    );
};

export default AddMeals;
