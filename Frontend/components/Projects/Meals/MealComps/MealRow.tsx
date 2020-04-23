import { FunctionComponent, MouseEvent, useState } from "react";
import { Grid, makeStyles, Theme, createStyles, Typography, IconButton, Menu, MenuItem, ListItemIcon, ListItemText } from "@material-ui/core";
import { getBasicMeals_meals } from "../../../../src/graphql/types/getBasicMeals";
import { getTypeString, getTimeString } from "../../../../lib/enumHelpers";
import MoreVertIcon from "@material-ui/icons/MoreVert";
import DeleteIcon from "@material-ui/icons/Delete";

const useStyles = makeStyles((theme: Theme) =>
    createStyles({
        container: {
            paddingTop: "0.5rem",
            paddingBottom: "0.5rem",
            "&:hover": {
                backgroundColor: theme.palette.action.hover,
            },
        },
        time: {
            textAlign: "center",
            borderRightWidth: 3,
            borderRightColor: "#48DA63",
            borderRightStyle: "solid",
        },
        timeText: {
            paddingTop: "0.5rem",
            paddingBottom: "0.5rem",
        },
        moreBtn: {
            textAlign: "end",
        }
    })
);

interface IMealRowProps {
    meal: getBasicMeals_meals;
    onDelete: (id: string, incRelated: boolean) => void;
}

const MealRow: FunctionComponent<IMealRowProps> = ({ meal, onDelete }) => {
    const c = useStyles();
    const [anchorMenu, setAnchorMenu] = useState<HTMLElement | null>(null);

    const { id, type, time, food: { name }, isRemoveable } = meal;

    const typeString = getTypeString(type);
    const timeString = getTimeString(time);

    const handleMoreClick = (event: MouseEvent<HTMLButtonElement>): void => {
        setAnchorMenu(event.currentTarget);
    };

    const handleClose = (): void => {
        setAnchorMenu(null);
    };

    const handleDelete = (): void => {
        onDelete(id, true);
        handleClose();
    };

    return (
        <Grid container item direction="row" justify="space-between" alignItems="center" className={c.container} >
            <Grid item xs={2} md={1} className={c.time}>
                <Typography variant="body1" className={c.timeText}>
                    {timeString}
                </Typography>
            </Grid>
            <Grid item xs={5} md={7}>
                <Typography variant="body1">
                    {name}
                </Typography>
            </Grid>
            <Grid item xs={3} md={2} >
                <Typography variant="body1">
                    {typeString}
                </Typography>
            </Grid>
            <Grid item xs={1} className={c.moreBtn}>
                <IconButton onClick={handleMoreClick}>
                    <MoreVertIcon />
                </IconButton>
                <Menu
                    anchorEl={anchorMenu}
                    keepMounted
                    open={Boolean(anchorMenu)}
                    onClose={handleClose}
                >
                    <MenuItem
                        disabled={!isRemoveable}
                        onClick={handleDelete}>
                        <ListItemIcon>
                            <DeleteIcon />
                        </ListItemIcon>
                        <ListItemText primary="Odstranit" />
                    </MenuItem>
                </Menu>
            </Grid>
        </Grid>
    );
};

export default MealRow;
