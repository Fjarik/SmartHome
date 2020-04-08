import { FunctionComponent, useState, ChangeEvent } from "react";
import { Checkbox } from "@material-ui/core";

interface CheckboxProps {
    checked: boolean;
    id: number;
    onChange: (checked: boolean, id: number) => void;
}

const CustomCheckbox: FunctionComponent<CheckboxProps> = ({ checked, id, onChange }) => {
    const [isChecked, setChecked] = useState<boolean>(checked);

    const handleOnChange = (event: ChangeEvent<HTMLInputElement>, newState: boolean): void => {
        setChecked(newState);
        onChange(newState, id);
    };

    return (
        <Checkbox
            checked={isChecked}
            onChange={handleOnChange} />
    );
};

export default CustomCheckbox;
