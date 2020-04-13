import React, { FunctionComponent, useState, useRef } from "react";
import ArrowDropDownIcon from "@material-ui/icons/ArrowDropDown";
import { ButtonGroup, Button, Popper, Grow, ClickAwayListener, MenuList, MenuItem, Paper } from "@material-ui/core";
import customUrls from "../../../../utils/customUrls";
import { useRouter } from "next/router";
import { MealTimeEnum } from "../../../../src/graphql/graphql-global-types";

const { app: { projectsUrls: { meals: { getAddMeal } } } } = customUrls;

const options = [
    {
        text: "Přidat snídani",
        disabled: false,
        url: getAddMeal(MealTimeEnum.BREAKFAST),
    },
    {
        text: "Přidat večeři",
        disabled: false,
        url: getAddMeal(MealTimeEnum.DINNER),
    }
];

const NewMealsButton: FunctionComponent = () => {
    const [open, setOpen] = useState<boolean>(false);
    const anchorRef = useRef<HTMLDivElement>(null);
    const router = useRouter();

    const handleMainClick = () => {
        router.push(getAddMeal(MealTimeEnum.LUNCH));
    };

    const handleMenuItemClick = (url: string) => {
        router.push(url);
        setOpen(false);
    };

    const handleToggle = () => {
        setOpen((prev) => !prev);
    };

    const handleClose = (event: React.MouseEvent<Document, MouseEvent>) => {
        if (anchorRef.current && anchorRef.current.contains(event.target as HTMLElement)) {
            return;
        }
        setOpen(false);
    };

    return (
        <>
            <ButtonGroup variant="contained" ref={anchorRef} color="secondary">
                <Button onClick={handleMainClick}>Přidat oběd</Button>
                <Button
                    color="secondary"
                    size="small"
                    onClick={handleToggle}
                >
                    <ArrowDropDownIcon />
                </Button>
            </ButtonGroup>
            <Popper open={open} anchorEl={anchorRef.current} role={undefined} transition disablePortal>
                {({ TransitionProps, placement }) =>
                    <Grow
                        {...TransitionProps}
                        style={{ transformOrigin: placement === "bottom" ? "center top" : "center bottom" }}>
                        <Paper>
                            <ClickAwayListener onClickAway={handleClose}>
                                <MenuList>
                                    {options.map((opt, i) =>
                                        <MenuItem
                                            key={i}
                                            disabled={opt.disabled}
                                            onClick={() => handleMenuItemClick(opt.url)}
                                        >
                                            {opt.text}
                                        </MenuItem>
                                    )}
                                </MenuList>
                            </ClickAwayListener>
                        </Paper>
                    </Grow>
                }
            </Popper>
        </>
    );
};

export default NewMealsButton;