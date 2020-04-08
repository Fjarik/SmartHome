import { FunctionComponent, useState, ChangeEvent, useEffect } from "react";
import { Modal, makeStyles, Theme, createStyles, Select, MenuItem, Table, TableCell, TableHead, TableRow, TableBody, Checkbox, TableContainer, Grid, Button, FormControlLabel, FormControl, InputLabel } from "@material-ui/core";
import { useQuery } from "react-apollo";
import { getBasicFoods } from "../../../src/graphql/types/getBasicFoods";
import { getFoodsBasic } from "../../../src/graphql/queries";
import { DateTime } from "luxon";
import { KeyboardDatePicker } from "@material-ui/pickers";
import CustomCheckbox from "./AddMeals/CheckboxCom";
import CenterLoading from "../../Loading/CenterLoading";

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
            minWidth: 200,
        }
    }),
);
const AddMeal: FunctionComponent<IAddMealProps> = ({ isOpen, handleClose }) => {
    const dayCount = 5;

    const c = useStyles();
    const [selectedFood, setSelectedFood] = useState<string>("");
    const [selectedDate, setSelectedDate] = useState<DateTime>();
    const [availableDays, setAvailableDays] = useState<DateTime[]>([]);
    const [selectedDays, setSelectedDays] = useState<boolean[]>(new Array(dayCount).fill(true, 0, 2).fill(false, 2));

    const { loading, data, error } = useQuery<getBasicFoods>(getFoodsBasic);

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

    const onCheckBoxChange = (checked: boolean, id: number): void => {
        let a = selectedDays;
        a[id] = checked;

        setSelectedDays(a);
        // console.log(selectedDays);
        // console.log("Change", { checked, id });
    };

    const onDateChange = (date: DateTime): void => {
        const days = [...Array(dayCount)].map((i, index) => {
            return date.plus({ days: index + 1 });
        });

        setAvailableDays(days);
        setSelectedDate(date);
    };

    const onFoodSelect = (event: ChangeEvent<{ value: string }>) => {
        setSelectedFood(event?.target?.value);
    };

    if (loading) {
        return <CenterLoading />;
    }

    const { foods } = data;

    return (
        <Modal
            open={isOpen}
            onClose={handleClose}>
            <div className={c.paper}>
                <h2>Nastavit nové jídlo</h2>
                <Grid container direction="column" alignItems="center" justify="space-between" spacing={2} >
                    <Grid item>
                        <KeyboardDatePicker
                            clearable={true}
                            label="Vyberte datum"
                            format="dd.MM.yyyy"
                            value={selectedDate}
                            onChange={onDateChange} />
                    </Grid>
                    <Grid item>
                        <FormControl className={c.formControl}>
                            <InputLabel id="demo-simple-select-label">Vyberte jídlo</InputLabel>
                            <Select
                                labelId="demo-simple-select-label"
                                value={selectedFood}
                                autoWidth
                                onChange={onFoodSelect}>
                                {
                                    foods.map((i) =>
                                        <MenuItem key={i.id} value={i.id}>{i.name}</MenuItem>
                                    )
                                }
                            </Select>
                        </FormControl>
                    </Grid>
                    <Grid item>

                        {/* <TableContainer> */}
                        <Table>
                            <TableHead>
                                <TableRow>
                                    <TableCell></TableCell>
                                    {
                                        availableDays.map((elem, index) => {
                                            const date = elem.setLocale("cs-CZ");
                                            const day = date.toFormat("ccc");
                                            const d = date.toLocaleString({ day: "numeric", month: "numeric" });
                                            return <TableCell key={index} align="center">
                                                {day}
                                                <br />
                                                {d}
                                            </TableCell>;
                                        })
                                    }
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {
                                    ["Krabička"].map((i, index) =>
                                        <TableRow key={index}>
                                            <TableCell key="99">{i}</TableCell>
                                            {
                                                selectedDays.map((checked, index) =>
                                                    <TableCell key={index}>
                                                        <CustomCheckbox id={index} onChange={onCheckBoxChange} checked={checked} />
                                                    </TableCell>
                                                )
                                            }


                                            {/* {getCells()} */}
                                        </TableRow>
                                    )
                                }
                            </TableBody>
                        </Table>
                        {/* </TableContainer> */}
                    </Grid>
                    <Grid item style={{ alignSelf: "flex-end" }}>
                        <Button color="primary" variant="contained">
                            Potvrdit
                        </Button>
                    </Grid>
                </Grid>
            </div>
        </Modal>
    );
};

export default AddMeal;
