import { FunctionComponent } from "react";
import { Modal, makeStyles, Theme, createStyles } from "@material-ui/core";

interface IAddMealProps {
    isOpen: boolean;
    handleClose: () => void;
}

const useStyles = makeStyles((theme: Theme) =>
    createStyles({
        paper: {
            position: "absolute",
            width: 400,
            backgroundColor: theme.palette.background.paper,
            border: "2px solid #000",
            boxShadow: theme.shadows[5],
            padding: theme.spacing(2, 4, 3),
            top: "50%",
            left: "50%",
            transform: "translate(-50%, -50%)",
        },
    }),
);
const AddMeal: FunctionComponent<IAddMealProps> = ({ isOpen, handleClose }) => {
    const c = useStyles();

    return (
        <Modal
            open={isOpen}
            onClose={handleClose}>
            <div className={c.paper}>
                <h2>Nastavit nové jídlo</h2>
                <p>
                    Den, jídlo, typ, kuchař
                    <br />
                    Duis mollis, est non commodo luctus, nisi erat porttitor ligula.
                </p>
            </div>
        </Modal>
    );
};

export default AddMeal;
