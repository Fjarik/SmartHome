import { FunctionComponent, useState, ChangeEvent, useEffect } from "react";
import { Modal, makeStyles, Theme, createStyles, Select, MenuItem, Table, TableCell, TableHead, TableRow, TableBody, Checkbox, TableContainer, Grid, Button, FormControlLabel, FormControl, InputLabel, ListSubheader, FormHelperText } from "@material-ui/core";
import { useQuery, useMutation, useApolloClient } from "react-apollo";
import { getBasicFoods } from "../../../src/graphql/types/getBasicFoods";
import { getFoodsBasic } from "../../../src/graphql/queries";
import { DateTime } from "luxon";
import { KeyboardDatePicker } from "@material-ui/pickers";
import CenterLoading from "../../Loading/CenterLoading";
import { FoodTypeEnum, MealTypeEnum } from "../../../src/graphql/graphql-global-types";
import { createMeal, createMealVariables } from "../../../src/graphql/types/createMeal";
import { createMealMutation } from "../../../src/graphql/mutations";

class Day {
    ActualDate: DateTime;
    Checked: boolean = false;

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


interface IAddMealProps {
    isOpen: boolean;
    handleClose: () => void;
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
const AddMeal: FunctionComponent<IAddMealProps> = ({ isOpen, handleClose }) => {
    const dayCount = 5;

    const c = useStyles();
    const [selectedFood, setSelectedFood] = useState<string>("");
    const [soupId, setSoupId] = useState<number>(0);
    const [sideId, setSideId] = useState<number>(0);
    const [selectedDate, setSelectedDate] = useState<DateTime>();
    const [recomendedSides, setRecomendedSides] = useState<number[]>([]);
    const [showError, setShowError] = useState<boolean>(false);
    const [days, setDays] = useState<Day[]>([]);

    const { loading, data, error } = useQuery<getBasicFoods>(getFoodsBasic);
    const client = useApolloClient();

    useEffect(() => {
        if (error) {
            console.log(error);
        }
        if (loading) {
            return;
        }
        const date = DateTime.local();
        onDateChange(date);
        return () => {
        };
    }, [loading]);

    const onCheckBoxChange = (checked: boolean, index: number): void => {
        const day = days[index];
        day.Checked = checked;

        const newDays = days;
        newDays[index] = day;

        // console.log(newDays);

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
        setSelectedDate(date);
    };

    const onSoupSelect = (event: ChangeEvent<{ value: number | null }>): void => {
        setSoupId(event?.target?.value ?? 0);
    };

    const onSideSelect = (event: ChangeEvent<{ value: number | null }>): void => {
        setSideId(event?.target?.value ?? 0);
    };

    const createMealAsync = async (variables: createMealVariables): Promise<string> => {
        const { data: { createMeal: { id } } } = await client.mutate<createMeal, createMealVariables>({
            mutation: createMealMutation,
            variables: variables
        });
        return id;
    };

    const submit = async () => {
        if (!selectedFood) {
            setShowError(true);
            return;
        }
        const date = selectedDate.toISODate();

        const side = sideId === 0 ? null : sideId.toString();

        // Main meal
        const mainMealId = await createMealAsync({
            foodId: selectedFood,
            date: date,
            type: MealTypeEnum.NORMAL,
            sideDishId: side
        });

        console.log(mainMealId);

    };

    if (loading) {
        return <Modal
            open={isOpen}
            onClose={handleClose}>
            <div className={c.paper}>
                <CenterLoading />
            </div>
        </Modal>;
    }

    const { foods, sidedishes } = data;
    const mainMeals = foods.filter(x => x.type === FoodTypeEnum.MAIN_MEAL).sort((a, b) => a.name.localeCompare(b.name));
    const soups = foods.filter(x => x.type === FoodTypeEnum.SOUP).sort((a, b) => a.name.localeCompare(b.name));

    const onFoodSelect = (event: ChangeEvent<{ value: string }>) => {
        const foodId = event?.target?.value;
        setSelectedFood(foodId);
        setShowError(false);

        const selFood = foods.find(x => x.id === foodId);
        if (selFood) {
            // console.log(selFood);
            setRecomendedSides(selFood.sideIds);
        }
    };

    return (
        <Modal
            open={isOpen}
            onClose={handleClose}>
            <div className={c.paper}>
                <h2>Nastavit nové jídlo</h2>
                <Grid container direction="column" alignItems="center" justify="space-between" spacing={2} >
                    <Grid item>
                        <KeyboardDatePicker
                            // clearable={false}
                            disableToolbar
                            autoOk={true}
                            variant="inline"
                            label="Vyberte datum"
                            format="dd.MM.yyyy"
                            value={selectedDate}
                            onChange={onDateChange} />
                    </Grid>
                    <Grid item style={{ alignSelf: "stretch" }}>
                        <Grid container spacing={2}>
                            <Grid item xs={12} sm={4}>
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
                            <Grid item xs={12} sm={4}>
                                <FormControl className={c.formControl} error={showError}>
                                    <InputLabel id="lbl2">Vyberte jídlo</InputLabel>
                                    <Select
                                        labelId="lbl2"
                                        value={selectedFood}
                                        onChange={onFoodSelect}>
                                        {
                                            mainMeals.map((i) =>
                                                <MenuItem key={i.id} value={i.id}>{i.name}</MenuItem>
                                            )
                                        }
                                    </Select>
                                    {
                                        showError &&
                                        <FormHelperText>Musíte vybrat jídlo</FormHelperText>
                                    }
                                </FormControl>
                            </Grid>
                            <Grid item xs={12} sm={4}>
                                <FormControl className={c.formControl}>
                                    <InputLabel id="lbl2">Vyberte přílohu</InputLabel>
                                    <Select
                                        labelId="lbl1"
                                        value={sideId}
                                        onChange={onSideSelect}>
                                        <ListSubheader>Doporučené</ListSubheader>
                                        <MenuItem value={0}>Žádná</MenuItem>
                                        {
                                            sidedishes.filter(x => recomendedSides.includes(parseInt(x.id))).map((i) =>
                                                <MenuItem key={i.id} value={i.id}>{i.name}</MenuItem>
                                            )
                                        }
                                        <ListSubheader>Ostatní</ListSubheader>
                                        {
                                            sidedishes.filter(x => !recomendedSides.includes(parseInt(x.id))).map((i) =>
                                                <MenuItem key={i.id} value={i.id}>{i.name}</MenuItem>
                                            )
                                        }
                                    </Select>
                                </FormControl>
                            </Grid>
                        </Grid>
                    </Grid>
                    <Grid item>
                        {/* <TableContainer> */}
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
                            </TableBody>
                        </Table>
                        {/* </TableContainer> */}
                    </Grid>
                    <Grid item style={{ alignSelf: "flex-end" }}>
                        <Button color="primary" variant="contained" onClick={submit} >
                            Potvrdit
                        </Button>
                    </Grid>
                </Grid>
            </div>
        </Modal>
    );
};

export default AddMeal;
