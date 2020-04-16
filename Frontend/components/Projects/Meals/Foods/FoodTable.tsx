import { FunctionComponent, useState } from "react";
import { allFoods_foods, allFoods_categories } from "../../../../src/graphql/types/allFoods";
import MaterialTable, { Column, Localization } from "material-table";
import { Chip, Grid, Select, MenuItem, Input, Checkbox, ListItemText, InputLabel, FormControl } from "@material-ui/core";
import { createFoodVariables, createFood } from "../../../../src/graphql/types/createFood";
import { FoodTypeEnum } from "../../../../src/graphql/graphql-global-types";
import { useApolloClient } from "react-apollo";
import { createFoodMutation, removeFoodMutation } from "../../../../src/graphql/mutations";
import { useRouter } from "next/router";
import { removeFood, removeFoodVariables } from "../../../../src/graphql/types/removeFood";

interface FoodTableProps {
    inputData: allFoods_foods[];
    categories: allFoods_categories[];
    title: string;
    type: FoodTypeEnum;
    showSides?: boolean;
    sides?: allFoods_foods[];
}

const FoodTable: FunctionComponent<FoodTableProps> = ({ inputData, type, categories, title, showSides = false, sides = [] }) => {
    const { mutate } = useApolloClient();
    const router = useRouter();
    const [data, setData] = useState<allFoods_foods[]>(inputData);

    const getChips = (food: allFoods_foods) => food.sideIds.map((x, i) => {
        const side = sides.find(s => s.id === x.toString());
        const primary = i % 2 === 0;
        return (
            <Grid key={i} item>
                <Chip label={side.name} size="small" color={primary ? "primary" : "secondary"} />
            </Grid>
        );
    });

    const getCategoryChips = (food: allFoods_foods) => food.categoryIds.map((x, i) => {
        const cat = categories.find(s => s.id === x.toString());
        const primary = x % 2 === 0;
        return (
            <Grid key={i} item>
                <Chip label={cat.name} size="small" color={primary ? "primary" : "secondary"} />
            </Grid>
        );
    });

    const getCategoryColumn = (): Column<allFoods_foods> => {
        return {
            title: "Kategorie",
            field: "categoryIds",
            // eslint-disable-next-line react/display-name
            render: (food) => (
                <Grid container spacing={1}>
                    {getCategoryChips(food)}
                </Grid>
            ),
            // eslint-disable-next-line react/display-name
            editComponent: ({ value, onChange }) => {
                const values = value as number[] || [];

                return (
                    <FormControl style={{ minWidth: 150 }}>
                        <InputLabel id="lbl2">Vyberte kategorii</InputLabel>
                        <Select
                            multiple
                            labelId="lbl2"
                            value={values}
                            renderValue={(selecteItems: number[]) => {
                                const items = categories.filter(x => selecteItems.includes(parseInt(x.id))).map(x => x.name);
                                return items.join(", ");
                            }}
                            onChange={(e) => onChange(e.target.value)}
                            input={<Input />}
                        >
                            {
                                categories.map((s) => {
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
        getCategoryColumn(),
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

    const checkSides = () => {
        if (type === FoodTypeEnum.SIDE_DISH) {
            router.reload();
        }
    };

    const onAdd = async (newData: allFoods_foods): Promise<any> => {

        const vars: createFoodVariables = {
            name: newData.name,
            type: type,
            categoryIds: newData?.categoryIds?.map(x => x.toString()) ?? [],
            sideIds: newData?.sideIds?.map(x => x.toString()) ?? [],
        };

        const { data: { createFood }, errors } = await mutate<createFood, createFoodVariables>({
            mutation: createFoodMutation,
            variables: vars
        });

        if (errors) {
            console.log(errors);
        }
        if (createFood) {
            setData([
                ...data,
                createFood
            ]);
            checkSides();
        }
    };

    const onDelete = async ({ id }: allFoods_foods): Promise<any> => {
        const { data: { removeFood: success }, errors } = await mutate<removeFood, removeFoodVariables>({
            mutation: removeFoodMutation,
            variables: { id: id }
        });

        if (success) {
            setData([
                ...data.filter(x => x.id !== id),
            ]);
            checkSides();
        }
    };

    const onUpdate = async (newData: allFoods_foods, oldData?: allFoods_foods): Promise<any> => {
        console.log("Old: ", oldData);
        console.log("New: ", newData);
        checkSides();
    };


    if (data.length < 1) {
        // TODO
    }

    if (data.filter(x => x.type !== type).length > 0) {
        // TODO - error
    }

    return (
        <MaterialTable
            title={title}
            columns={columns}
            data={data}
            // style={{ height: "100%" }}
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
