import { FunctionComponent, ReactNode, useState, ChangeEvent } from "react";
import { Paper, Tabs, Tab, Container, Typography, makeStyles, Theme, createStyles } from "@material-ui/core";
import AddLunch from "./AddLunch";
import { MealTimeEnum } from "../../../../src/graphql/graphql-global-types";

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

    const handleChange = (event: ChangeEvent<{}>, newValue: MealTimeEnum) => {
        setValue(newValue);
    };

    return (
        <Container>
            <Typography variant="h4" gutterBottom>
                Přidat jídlo
            </Typography>
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
            <TabPanel value={value} index={MealTimeEnum.BREAKFAST}>
                Test 0
            </TabPanel>
            <TabPanel value={value} index={MealTimeEnum.LUNCH}>
                <AddLunch />
            </TabPanel>
            <TabPanel value={value} index={MealTimeEnum.DINNER}>
                Test 2
            </TabPanel>
        </Container>
    );
};

export default AddMeals;
