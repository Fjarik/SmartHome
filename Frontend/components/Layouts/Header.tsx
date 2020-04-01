import { FunctionComponent, useState, useEffect, useContext } from 'react'
import { Button, Toolbar, Theme, Link, IconButton, useTheme, makeStyles, createStyles } from '@material-ui/core';
import { ReactAuthContext } from '../../src/graphql/auth';
import Brightness7Icon from '@material-ui/icons/Brightness7';
import Brightness4Icon from '@material-ui/icons/Brightness4';
import { switchTheme, getThemeString } from "../Themes/MainTheme";
import { useRouter } from "next/router";
import AuthMenu from './AuthMenu';


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
        logoLink: {
            "&:hover": {
                textDecoration: "none",
            }
        }
    }));

const Header: FunctionComponent = () => {
    const [themeString, setThemeString] = useState<string>("light");
    const { isLoggedIn, user, logout } = useContext(ReactAuthContext);

    const theme = useTheme();
    const router = useRouter();
    const c = useStyles(theme);

    const isDarkTheme = (): boolean => themeString === "dark";

    useEffect(() => {
        setThemeString(getThemeString());
        return () => {
        };
    }, [])

    const getImgSrc = () => {
        return isDarkTheme() ? "/images/logos/MainWhite.png" : "/images/logos/Main.png";
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
                    {isLoggedIn ?
                        <AuthMenu user={user} logout={logout} />
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
    )
}

export default Header;
