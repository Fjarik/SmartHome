import { FunctionComponent, useState, useEffect, useContext } from 'react'
import { Button, Toolbar, Theme, Link, IconButton, makeStyles, colors, Typography } from '@material-ui/core';
import { ReactAuthContext } from '../../src/graphql/auth';
import Brightness7Icon from '@material-ui/icons/Brightness7';
import Brightness4Icon from '@material-ui/icons/Brightness4';
import { switchTheme, getThemeString } from "../Themes/MainTheme";
import { useRouter } from "next/router";
import AuthMenu from './AuthMenu';


const useStyles = makeStyles((theme: Theme) => ({
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
        alignItems: "center",
        color: theme.palette.type == "light" ? theme.palette.primary.main : "#fff!important",
    },
    logoContainer: {
        display: "flex",
        cursor: "pointer",
        userSelect: "none",
    },
    logoImg: {
        height: "70px",
        width: "70px",
    },
    logoText: {
        marginBottom: "0px",
        marginTop: "auto",
        fontSize: "xx-large",
        color: theme.palette.type == "light" ? theme.palette.primary.main : "#fff!important",
    },
    logoLink: {
        "&:hover": {
            textDecoration: "none",
        }
    },
    loginBtn: {
        color: theme.palette.type == "light" ? theme.palette.primary.main : "#fff!important",
    }
}));

const Header: FunctionComponent = () => {
    const [isDarkTheme, setIsDarkTheme] = useState<boolean>(false)
    const { user, logout } = useContext(ReactAuthContext);

    const router = useRouter();
    const c = useStyles();

    useEffect(() => {
        setIsDarkTheme(getThemeString() === "dark");
        return () => {
        };
    }, [])

    const getImgSrc = () => {
        return isDarkTheme ? "/images/logos/MainWhite.png" : "/images/logos/Main.png";
    }

    const changeTheme = () => {
        switchTheme();

        router.reload();
    };

    return (
        <header className={c.headerMain}>
            <Toolbar className={c.headerContainer}>
                <Link href="/" className={c.logoLink} >
                    <div className={c.logoContainer}>
                        <img src={getImgSrc()} className={c.logoImg} />
                        <Typography variant="h4" className={c.logoText}>
                            SmartHome
                        </Typography>
                    </div>
                </Link>
                <div>
                    <IconButton color="inherit" onClick={changeTheme}>
                        {isDarkTheme ?
                            <Brightness7Icon />
                            :
                            <Brightness4Icon />
                        }
                    </IconButton>
                    {!!user ?
                        <AuthMenu user={user} logout={logout} />
                        :
                        <Link href="/login">
                            <Button variant="text" size="large" className={c.loginBtn}>
                                Přihlášení
                            </Button>
                        </Link>
                    }
                </div>
            </Toolbar>
        </header>
    );
}

export default Header;