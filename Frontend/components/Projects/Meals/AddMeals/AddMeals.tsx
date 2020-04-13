import { FunctionComponent, ReactNode, useState, ChangeEvent } from "react";
import { Paper, Tabs, Tab, Container, Typography, makeStyles, Theme, createStyles, Grid } from "@material-ui/core";
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

    const handleChange = (event: ChangeEvent<{}>, newValue: MealTimeEnum) => {
        setValue(newValue);
    };

    const onDateChange = (date: DateTime): void => {
        setSelectedDate(date);
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
                        <AddLunch selectedDate={selectedDate} />
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
