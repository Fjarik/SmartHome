import { FunctionComponent, useState, useRef } from "react";
import { Button, Popper, Grow, Paper, ClickAwayListener, MenuList, MenuItem, ButtonGroup } from "@material-ui/core";

interface IMealOtherButtonProps {
    id: string,
}

const MealOtherButton: FunctionComponent<IMealOtherButtonProps> = ({ id }) => {
    const [isOpen, setIsOpen] = useState<boolean>(false);
    const anchorRef = useRef<HTMLDivElement>(null);

    const handleToggle = (): void => {
        setIsOpen((prev) => !prev);
    };

    const handleClose = (event: React.MouseEvent<Document, MouseEvent>): void => {
        if (anchorRef.current && anchorRef.current.contains(event.target as HTMLElement)) {
            return;
        }
        setIsOpen(false);
    };

    return (
        <>
            <ButtonGroup
                ref={anchorRef}
            >
                <Button
                    onClick={handleToggle}
                >
                    ...
            </Button>
            </ButtonGroup>
            <Popper open={isOpen} anchorEl={anchorRef.current} role={undefined} transition disablePortal>
                {
                    ({ TransitionProps, placement }) =>
                        <Grow
                            {...TransitionProps}
                            style={{ transformOrigin: placement === "bottom" ? "center top" : "center bottom" }}
                        >
                            <Paper>
                                <ClickAwayListener onClickAway={handleClose}>
                                    <MenuList>
                                        <MenuItem>
                                            Odstranit
                                        </MenuItem>
                                    </MenuList>
                                </ClickAwayListener>
                            </Paper>
                        </Grow>
                }
            </Popper>
        </>
    );
};

export default MealOtherButton;
