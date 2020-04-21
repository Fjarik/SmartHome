import { FunctionComponent, useState } from "react";
import { Button, Menu, MenuItem, ListItemIcon, Typography, Divider } from "@material-ui/core";
import AccountCircle from "@material-ui/icons/AccountCircle";
import PersonIcon from "@material-ui/icons/Person";
import SettingsIcon from "@material-ui/icons/Settings";
import PowerSettingsNewIcon from "@material-ui/icons/PowerSettingsNew";
import { getLogged_logged } from "../../../../src/graphql/types/getLogged";
import { useRouter } from "next/router";
import customUrls from "../../../../utils/customUrls";

interface IAuthMenuProps {
    user: getLogged_logged;
    logout: () => Promise<void>;
}

const AuthMenu: FunctionComponent<IAuthMenuProps> = ({ user, logout }) => {
    const [anchorAuthMenu, setAnchorAuthMenu] = useState<null | HTMLElement>(null);
    const open = Boolean(anchorAuthMenu);
    const router = useRouter();
    const { account: { accountUrl, settingsUrl } } = customUrls;

    const handleAuthMenu = (event: React.MouseEvent<HTMLElement>) => {
        setAnchorAuthMenu(event.currentTarget);
    };

    const handleClose = (): void => {
        setAnchorAuthMenu(null);
    };

    const redirect = (url: string): void => {
        router.push(url);
    };

    return (
        <>
            <Button
                color="inherit"
                size="large"
                onClick={handleAuthMenu}
                startIcon={<AccountCircle />}>
                {user?.firstname} {user?.lastname}
            </Button>
            <Menu
                anchorEl={anchorAuthMenu}
                keepMounted
                open={open}
                onClose={handleClose}
            >
                <MenuItem onClick={() => redirect(accountUrl)}>
                    <ListItemIcon>
                        <PersonIcon fontSize="small" />
                    </ListItemIcon>
                    <Typography variant="inherit">
                        Profil
                    </Typography>
                </MenuItem>
                <MenuItem onClick={() => redirect(settingsUrl)} >
                    <ListItemIcon>
                        <SettingsIcon fontSize="small" />
                    </ListItemIcon>
                    <Typography variant="inherit">
                        Nastavení
                    </Typography>
                </MenuItem>
                <Divider />
                <MenuItem onClick={async () => await logout()}>
                    <ListItemIcon>
                        <PowerSettingsNewIcon fontSize="small" />
                    </ListItemIcon>
                    <Typography variant="inherit">
                        Odhlásit se
                    </Typography>
                </MenuItem>
            </Menu>
        </>
    );
};

export default AuthMenu;
