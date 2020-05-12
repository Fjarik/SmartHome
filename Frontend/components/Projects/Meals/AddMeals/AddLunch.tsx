import { FunctionComponent, useState, ChangeEvent, useEffect } from "react";
import { makeStyles, Theme, createStyles, Select, MenuItem, Table, TableCell, TableHead, TableRow, TableBody, Checkbox, TableContainer, Grid, Button, FormControl, InputLabel, ListSubheader, FormHelperText, Container } from "@material-ui/core";
import { useQuery, useApolloClient } from "react-apollo";
import { getBasicFoods } from "src/graphql/types/getBasicFoods";
import { getFoodsBasic } from "src/graphql/queries";
import { DateTime } from "luxon";
import CenterLoading from "../../../Loading/CenterLoading";
import { FoodTypeEnum, MealTypeEnum, MealTimeEnum } from "src/graphql/graphql-global-types";
import { createMeal, createMealVariables } from "src/graphql/types/createMeal";
import { createMealMutation } from "src/graphql/mutations";
import { useSnackbar } from "notistack";
import { useRouter } from "next/router";
import customUrls from "utils/customUrls";

class Day {
    ActualDate: DateTime;
    Checked: boolean = false;
    soup: boolean = false;

    private get localDate(): DateTime {
        return this.ActualDate.setLocale("cs-CZ");
    }
    get DayName(): string {
        return this.localDate.toFormat("ccc");
    }
    get WholeDay(): string {
        return this.localDate.toLocaleString({ day: "numeric", month: "numeric" });
    }

    constructor(date: DateTime, checked: boolean = false) {
        this.ActualDate = date;
        this.Checked = checked;
    }
}

const useStyles = makeStyles((theme: Theme) =>
    createStyles({
        paper: {
            position: "absolute",
            // width: 700,
            backgroundColor: theme.palette.background.paper,
            border: "2px solid #000",
            boxShadow: theme.shadows[5],
            padding: theme.spacing(2, 4, 3),
            top: "50%",
            left: "50%",
            transform: "translate(-50%, -50%)",
        },
        formControl: {
            width: "100%",
            // minWidth: 238,
        }
    }),
);

interface AddLunchProps {
    selectedDate: DateTime;
    isBox: boolean;
}

const AddLunch: FunctionComponent<AddLunchProps> = ({ selectedDate, isBox }) => {
    const dayCount = 5;

    const c = useStyles();
    const { enqueueSnackbar } = useSnackbar();
    const [selectedFood, setSelectedFood] = useState<number>(0);
    const [soupId, setSoupId] = useState<number>(0);
    const [sideId, setSideId] = useState<number>(0);
    const [recomendedSides, setRecomendedSides] = useState<number[]>([]);
    const [days, setDays] = useState<Day[]>([]);
    const { loading, data, error } = useQuery<getBasicFoods>(getFoodsBasic);
    const client = useApolloClient();
    const router = useRouter();
    const { app: { projectsUrls: { meals: { mealsIndex } } } } = customUrls;

    useEffect(() => {
        if (error) {
            console.log(error);
        }
        if (loading) {
            return;
        }
        return () => {
        };
    }, [loading]);

    useEffect(() => {
        const date = selectedDate ?? DateTime.local();

        onDateChange(date);
        return () => {

        };
    }, [selectedDate]);

    const onCheckBoxChange = (checked: boolean, index: number): void => {
        const day = days[index];
        day.Checked = checked;

        const newDays = days;
        newDays[index] = day;

        // console.log(newDays);

        setDays([...newDays]);
    };

    const onCheckBoxSoupChange = (checked: boolean, index: number): void => {
        const day = days[index];
        day.soup = checked;

        const newDays = days;
        newDays[index] = day;
        setDays([...newDays]);
    };

    const onDateChange = (date: DateTime): void => {
        const days = [...Array(dayCount)].map((i, index) => {
            return date.plus({ days: index + 1 });
        });

        // Monday - 1
        // Sunday - 7
        const weekDay = date.weekday;

        const isSaturday = weekDay === 6;
        const isSunday = weekDay === 7;

        const isWeekend = isSaturday || isSunday;

        const wholeDays = days.map((val) => {
            let isChecked = false;
            const wDay = val.weekday;
            if (isWeekend) {
                // Saturday -> Monday ON 
                if (isSaturday && wDay === 1) {
                    isChecked = true;
                }
                // Sunday -> Tuesday ON 
                if (isSunday && wDay === 2) {
                    isChecked = true;
                }
            } else {
                // Friday only one day
                if (weekDay !== 5) {
                    // Box for the next day
                    isChecked = weekDay + 1 === wDay;
                }
            }

            return new Day(val, isChecked);
        });

        setDays(wholeDays);
    };

    const onSoupSelect = (event: ChangeEvent<{ value: number | null }>): void => {
        setSoupId(event?.target?.value ?? 0);
    };

    const onSideSelect = (event: ChangeEvent<{ value: number | null }>): void => {
        setSideId(event?.target?.value ?? 0);
    };

    const createMealAsync = async (variables: createMealVariables): Promise<string> => {
        const { data: { createMeal: { id } }, errors: cErrors } = await client.mutate<createMeal, createMealVariables>({
            mutation: createMealMutation,
            variables: variables
        });
        if (cErrors) {
            cErrors.forEach(console.log);
        }
        return id;
    };

    const handleSubmit = async (): Promise<void> => {
        if (!selectedFood && !soupId) {
            enqueueSnackbar("Musíte vybrat polévku nebo hlavní jídlo", { variant: "error" });
            return;
        }
        const date = selectedDate.toISODate();

        const soup = soupId === 0 ? null : soupId.toString();
        const food = selectedFood === 0 ? null : selectedFood.toString();
        const side = sideId === 0 ? null : sideId.toString();

        // Main meal
        const mainMealId = await createMealAsync({
            foodId: food,
            date: date,
            type: isBox ? MealTypeEnum.FOOD_BOX : MealTypeEnum.NORMAL,
            time: MealTimeEnum.LUNCH,
            sideDishId: side,
            soupId: soup,
        });

        console.log(mainMealId);

        if (!mainMealId) {
            enqueueSnackbar("Nezdařilo se vytvořit hlavní jídlo", { variant: "error" });
            return;
        }

        days.filter(x => x.Checked || x.soup).forEach(async (x) => {
            const res = await createMealAsync({
                foodId: food,
                date: x.ActualDate.toISODate(),
                type: MealTypeEnum.FOOD_BOX,
                time: MealTimeEnum.LUNCH,
                sideDishId: side,
                soupId: soup,
                originalMealId: mainMealId
            });
            console.log(res);

            if (!res) {
                enqueueSnackbar("Nezdařilo se vytvořit krabičku", { variant: "error" });
                return;
            }
        });

        enqueueSnackbar("Jídla úspěšně vytvořena", { variant: "success" });
        router.push(mealsIndex);
    };

    const handleCancel = (): void => {
        router.push(mealsIndex);
    };

    if (loading) {
        return <CenterLoading />;
    }

    if (error) {
        return <p>{error}</p>;
    }

    const { foods } = data;
    const sorted = foods.sort((a, b) => a.name.localeCompare(b.name));
    const mainMeals = sorted.filter(x => x.type === FoodTypeEnum.MAIN_MEAL);
    const soups = sorted.filter(x => x.type === FoodTypeEnum.SOUP);
    const sides = sorted.filter(x => x.type === FoodTypeEnum.SIDE_DISH);

    const onFoodSelect = (event: ChangeEvent<{ value: number | null }>) => {
        const foodId = event?.target?.value ?? 0;
        setSelectedFood(foodId);

        const selFood = foods.find(x => x.id === foodId.toString());
        if (selFood) {
            setRecomendedSides(selFood.sideIds);
        }
    };

    return (
        <Container>
            <Grid container direction="column" alignItems="center" justify="space-between" spacing={2} >
                <Grid item style={{ alignSelf: "stretch" }}>
                    <Grid container justify="center" spacing={2}>
                        <Grid item xs={12} sm={6} md={4}>
                            <FormControl className={c.formControl}>
                                <InputLabel id="lbl1">Vyberte polévku</InputLabel>
                                <Select
                                    labelId="lbl1"
                                    value={soupId}
                                    onChange={onSoupSelect}>
                                    <MenuItem value={0}>Žádná</MenuItem>
                                    {
                                        soups.map((i) =>
                                            <MenuItem key={i.id} value={i.id}>{i.name}</MenuItem>
                                        )
                                    }
                                </Select>
                            </FormControl>
                        </Grid>
                        <Grid item xs={12} sm={6} md={4}>
                            <FormControl className={c.formControl}>
                                {/* TODO: Implement food selector */}
                                <InputLabel id="lbl2">Vyberte hlavní chod</InputLabel>
                                <Select
                                    labelId="lbl2"
                                    value={selectedFood}
                                    onChange={onFoodSelect}>
                                    <MenuItem value={0}>Žádný</MenuItem>
                                    {
                                        mainMeals.map((i) =>
                                            <MenuItem key={i.id} value={i.id}>{i.name}</MenuItem>
                                        )
                                    }
                                </Select>
                            </FormControl>
                        </Grid>
                        <Grid item xs={12} sm={6} md={4}>
                            <FormControl className={c.formControl}>
                                <InputLabel id="lbl3">Vyberte přílohu</InputLabel>
                                <Select
                                    labelId="lbl3"
                                    value={sideId}
                                    onChange={onSideSelect}>
                                    <ListSubheader>Doporučené</ListSubheader>
                                    <MenuItem value={0}>Žádná</MenuItem>
                                    {
                                        sides.filter(x => recomendedSides.includes(parseInt(x.id))).map((i) =>
                                            <MenuItem key={i.id} value={i.id}>{i.name}</MenuItem>
                                        )
                                    }
                                    <ListSubheader>Ostatní</ListSubheader>
                                    {
                                        sides.filter(x => !recomendedSides.includes(parseInt(x.id))).map((i) =>
                                            <MenuItem key={i.id} value={i.id}>{i.name}</MenuItem>
                                        )
                                    }
                                </Select>
                            </FormControl>
                        </Grid>
                    </Grid>
                </Grid>
                <Grid item>
                    {
                        (selectedFood > 0 || soupId > 0) &&
                        (
                            <TableContainer>
                                <Table>
                                    <TableHead>
                                        <TableRow>
                                            <TableCell></TableCell>
                                            {
                                                days.map((elem, index) =>
                                                    <TableCell key={index} align="center">
                                                        {elem.DayName}
                                                        <br />
                                                        {elem.WholeDay}
                                                    </TableCell>
                                                )
                                            }
                                        </TableRow>
                                    </TableHead>
                                    <TableBody>
                                        {
                                            selectedFood > 0 &&
                                            (
                                                <TableRow>
                                                    <TableCell>Krabička</TableCell>
                                                    {
                                                        days.map((elem, index) =>
                                                            <TableCell key={index}>
                                                                <Checkbox
                                                                    checked={elem.Checked}
                                                                    onChange={(event, checked: boolean) => onCheckBoxChange(checked, index)} />
                                                            </TableCell>
                                                        )
                                                    }
                                                </TableRow>
                                            )
                                        }
                                        {
                                            soupId > 0 &&
                                            (
                                                <TableRow>
                                                    <TableCell>Polévka</TableCell>
                                                    {
                                                        days.map((elem, index) =>
                                                            <TableCell key={index}>
                                                                <Checkbox
                                                                    checked={elem.soup}
                                                                    onChange={(event, checked: boolean) => onCheckBoxSoupChange(checked, index)} />
                                                            </TableCell>
                                                        )
                                                    }
                                                </TableRow>
                                            )
                                        }
                                    </TableBody>
                                </Table>
                            </TableContainer>
                        )
                    }
                </Grid>
                <Grid item style={{ alignSelf: "flex-end" }}>
                    <Grid container spacing={2}>
                        <Grid item>
                            <Button color="secondary" variant="contained" onClick={handleCancel} >
                                Zrušit
                            </Button>
                        </Grid>
                        <Grid item>
                            <Button color="primary" variant="contained" onClick={handleSubmit} >
                                Potvrdit
                            </Button>
                        </Grid>
                    </Grid>
                </Grid>
            </Grid>
        </Container>
    );
};

export default AddLunch;
