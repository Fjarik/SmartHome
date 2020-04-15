import { FunctionComponent } from "react";
import { allFoods_foods } from "../../../../src/graphql/types/allFoods";
import MaterialTable, { Column, Localization } from "material-table";
import { Chip, Grid, Select, MenuItem, Input, Checkbox, ListItemText, InputLabel, FormControl } from "@material-ui/core";

interface FoodTableProps {
    data: allFoods_foods[];
    title: string;
    showSides?: boolean;
    sides?: allFoods_foods[];
}

const FoodTable: FunctionComponent<FoodTableProps> = ({ data, title, showSides = false, sides = [] }) => {

    const defaultColumns: Column<allFoods_foods>[] = [
        {
            title: "#",
            field: "id",
            type: "numeric",
            editable: "never",
            // @ts-ignore
            width: 70,
        },
        {
            title: "Název",
            field: "name"
        },
        {
            title: "Kategorie",
            field: "aaa"
        },
    ];

    const getSideColumn = (): Column<allFoods_foods> => {
        return {
            title: "Přílohy",
            field: "sideIds",
            // eslint-disable-next-line react/display-name
            render: (food) => (
                <Grid container spacing={1}>
                    {getChips(food)}
                </Grid>
            ),
            // eslint-disable-next-line react/display-name
            editComponent: ({ value, onChange }) => {
                const values = value as number[] || [];

                return (
                    <FormControl style={{ minWidth: 150 }}>
                        <InputLabel id="lbl1">Vyberte přílohy</InputLabel>
                        <Select
                            multiple
                            labelId="lbl1"
                            value={values}
                            renderValue={(selecteItems: number[]) => {
                                const items = sides.filter(x => selecteItems.includes(parseInt(x.id))).map(x => x.name);
                                return items.join(", ");
                            }}
                            onChange={(e) => onChange(e.target.value)}
                            input={<Input />}
                        >
                            {
                                sides.map((s) => {
                                    const id = parseInt(s.id);
                                    return (
                                        <MenuItem key={id} value={id}>
                                            <Checkbox checked={values.includes(id)} />
                                            <ListItemText primary={s.name} />
                                        </MenuItem>
                                    );
                                })
                            }
                        </Select>
                    </FormControl>
                );
            },
        };
    };

    const getChips = (food: allFoods_foods) => food.sideIds.map((x, i) => {
        const side = sides.find(s => s.id === x.toString());
        const primary = i % 2 === 0;
        return (
            <Grid key={i} item>
                <Chip label={side.name} size="small" color={primary ? "primary" : "secondary"} />
            </Grid>
        );
    });

    const columns: Column<allFoods_foods>[] = (showSides && sides.length > 0) ?
        [
            ...defaultColumns,
            getSideColumn()
        ]
        : defaultColumns;

    const locs: Localization = {
        header: {
            actions: "Akce"
        },
        toolbar: {
            searchPlaceholder: "Vyhledat",
            searchTooltip: "Vyhledat",
        }
    };

    const onAdd = async (newData: allFoods_foods): Promise<any> => {
        console.log(newData);
    };

    const onDelete = async (oldData: allFoods_foods): Promise<any> => {
        console.log(oldData);
    };

    const onUpdate = async (newData: allFoods_foods, oldData?: allFoods_foods): Promise<any> => {
        console.log("Old: ", oldData);
        console.log("New: ", newData);
    };


    if (data.length < 1) {
        // TODO
    }

    return (
        <MaterialTable
            title={title}
            columns={columns}
            data={data}
            localization={locs}
            editable={{
                isEditable: (data) => true,
                isDeletable: (data) => true,
                onRowAdd: onAdd,
                onRowDelete: onDelete,
                onRowUpdate: onUpdate,
            }}
            options={{
                search: true,
                actionsColumnIndex: -1,
                draggable: false,
            }}
        />
    );
};

export default FoodTable;
