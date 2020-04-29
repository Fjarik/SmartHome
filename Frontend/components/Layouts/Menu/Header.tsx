import { FunctionComponent, useState, useEffect, useContext } from "react";
import { Button, Toolbar, Theme, Link, IconButton, makeStyles, colors, Typography, Container, Divider, useMediaQuery } from "@material-ui/core";
import { ReactAuthContext } from "../../../src/graphql/auth";
import Brightness7Icon from "@material-ui/icons/Brightness7";
import Brightness4Icon from "@material-ui/icons/Brightness4";
import { switchTheme, getThemeString } from "../../Themes/MainTheme";
import { useRouter } from "next/router";
import AuthMenu from "./SubMenus/AuthMenu";
import SubMenu from "./SubMenus/SubMenu";
import customUrls from "../../../utils/customUrls";
import useAuth from "../../../lib/useAuth";


const useStyles = makeStyles((theme: Theme) => ({
    headerMain: {
        // position: "relative",
        // display: "flex",
        // flexDirection: "row",
        // alignItems: "center",
        zIndex: 3,
        // height: "100px",
        backgroundColor: "transparent",
        // justifyContent: "center"
        marginBottom: "2rem",
    },
    headerContainer: {
        position: "relative",
        // width: "100%",
        // height: "100%",
        // maxWidth: "1200px",
        display: "flex",
        // flexDirection: "row",
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
        padding: "0.5rem",
        height: "60px",
        width: "60px",
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
    const [isDarkTheme, setIsDarkTheme] = useState<boolean>(false);
    const { user, logout } = useAuth();
    const { indexUrl, app: { appUrl }, account: { loginUrl } } = customUrls;

    const isMobile = useMediaQuery((theme: Theme) => theme.breakpoints.up("sm"));

    const router = useRouter();
    const c = useStyles();

    useEffect(() => {
        setIsDarkTheme(getThemeString() === "dark");
        return () => {
        };
    }, []);

    const getImgSrc = (): string => {
        return isDarkTheme ? "/images/logos/MainWhite.png" : "/images/logos/Main.png";
    };

    const changeTheme = (): void => {
        switchTheme();

        router.reload();
    };

    const getLink = (): string => {
        return user ? appUrl : indexUrl;
    };


    return (
        <header className={c.headerMain}>
            <Container>
                <div className={c.headerContainer}>
                    <Link href={getLink()} className={c.logoLink} >
                        <div className={c.logoContainer}>
                            <img src={getImgSrc()} className={c.logoImg} />
                            <Typography variant="h4" className={c.logoText}>
                                SmartHome
                            </Typography>
                        </div>
                    </Link>
                    <div>
                        {isMobile &&
                            <IconButton color="inherit" onClick={changeTheme}>
                                {isDarkTheme ?
                                    <Brightness7Icon />
                                    :
                                    <Brightness4Icon />
                                }
                            </IconButton>
                        }
                        {user ?
                            <AuthMenu user={user} logout={logout} />
                            :
                            <Link href={loginUrl}>
                                <Button variant="text" size="large" className={c.loginBtn}>
                                    Přihlášení
                            </Button>
                            </Link>
                        }
                    </div>
                </div>
                {user && <SubMenu />}
            </Container>
            <Divider />
        </header>
    );
};

export default Header;
