import { FunctionComponent, useContext, useState, useEffect } from "react";
import Link from "next/link";
import { ReactAuthContext } from "../../src/graphql/auth";
import { Grid, Button, makeStyles, createStyles, Theme, Toolbar, Menu, MenuItem, useTheme, Typography, Divider, ListItemIcon, IconButton } from "@material-ui/core";
import AccountCircle from '@material-ui/icons/AccountCircle';
import PersonIcon from '@material-ui/icons/Person';
import SettingsIcon from '@material-ui/icons/Settings';
import PowerSettingsNewIcon from '@material-ui/icons/PowerSettingsNew';
import Brightness7Icon from '@material-ui/icons/Brightness7';
import Brightness4Icon from '@material-ui/icons/Brightness4';
import { switchTheme, getThemeString } from "../Themes/MainTheme";
import { useRouter } from "next/router";

const useStyles = makeStyles((theme: Theme) =>
    createStyles({
        headerMain: {
            position: "relative",
            display: "flex",
            flexDirection: "row",
            alignItems: "center",
            zIndex: 3,
            height: "100px",
            backgroundColor: "transparent",
            justifyContent: "center"
        },
        headerContainer: {
            position: "relative",
            width: "100%",
            height: "100%",
            maxWidth: "1200px",
            display: "flex",
            flexDirection: "row",
            justifyContent: "space-between",
            alignItems: "center"
        },
        logoContainer: {
            display: "flex",
            cursor: "pointer",
        },
        logoImg: {
            height: "70px",
            width: "70px",
        },
        logoText: {
            marginBottom: "0px",
            marginTop: "auto",
            fontSize: "xx-large",
            color: theme.palette.primary.main,
        },
        menuButton: {
            borderRadius: 25,
        },
        mainText: {
            textAlign: "center",
        },
        mainGrid: {
            marginTop: "15rem",
        },
    }));

const HomePage: FunctionComponent<{}> = () => {

    const { isLoggedIn: isLog, user, logout } = useContext(ReactAuthContext);
    const [anchorAuthMenu, setAnchorAuthMenu] = useState<null | HTMLElement>(null);
    const [themeString, setThemeString] = useState<string>("light");

    const theme = useTheme();
    const c = useStyles(theme);
    const router = useRouter();

    const open = Boolean(anchorAuthMenu);

    const isLoggedIn = (): boolean => isLog && !!user;
    const isDarkTheme = (): boolean => themeString === "dark";

    useEffect(() => {
        setThemeString(getThemeString());
        return () => {
        };
    }, [])

    const handleAuthMenu = (event: React.MouseEvent<HTMLElement>) => {
        setAnchorAuthMenu(event.currentTarget);
    };

    const handleClose = () => {
        setAnchorAuthMenu(null);
    };

    const getLink = () => {
        return isLoggedIn() ? "/app" : "/login";
    };
    const getImgSrc = () => {
        return isDarkTheme() ? "/images/logos/MainWhite.png" : "/images/logos/Main.png";
    }

    const changeTheme = () => {
        switchTheme();

        router.reload();
    };

    const authMenu = (<>
        <Button
            color="primary"
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
            <MenuItem onClick={handleClose}>
                <ListItemIcon>
                    <PersonIcon fontSize="small" />
                </ListItemIcon>
                <Typography variant="inherit">
                    Profil
                </Typography>
            </MenuItem>
            <MenuItem onClick={handleClose} >
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
    </>);

    return (<>
        <header className={c.headerMain}>
            <Toolbar className={c.headerContainer}>
                <Link href="/" >
                    <div className={c.logoContainer}>
                        <img src={getImgSrc()} className={c.logoImg} />
                        <h1 className={c.logoText}>SmartHome</h1>
                    </div>
                </Link>
                <div>
                    <IconButton color="primary" onClick={changeTheme}>
                        {isDarkTheme() ?
                            <Brightness7Icon />
                            :
                            <Brightness4Icon />
                        }
                    </IconButton>
                    {isLoggedIn() ?
                        authMenu
                        :
                        <Link href="/login">
                            <Button variant="text" color="primary" size="large">
                                Přihlášení
                            </Button>
                        </Link>
                    }
                </div>
            </Toolbar>
        </header>
        <Grid container justify="center" alignItems="center" className={c.mainGrid}>
            <Grid item className={c.mainText}>
                <Typography variant="h2" gutterBottom>
                    Platforma pro ovládání domácnosti
                </Typography>
                <Typography variant="h5" gutterBottom>
                    Spravujte svůj byt či dům jednoduše a pohodlě na dálku z počítače.
                </Typography>
                <br />
                <Link href={getLink()}>
                    <Button variant="contained"
                        className={c.menuButton}
                        size="large"
                        color="secondary">
                        Přejít do aplikace
                    </Button>
                </Link>
            </Grid>
        </Grid>
    </>
    );

}

export default HomePage;