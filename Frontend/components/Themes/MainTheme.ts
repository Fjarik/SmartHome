import { createMuiTheme, Theme } from "@material-ui/core";
import { ThemeCookieKey } from "../../src/Global/Keys";
import Cookies from "universal-cookie";
import { PaletteOptions } from "@material-ui/core/styles/createPalette";

const defaultTheme = "light";

const isBrowserDark = (): boolean => {
    return window && window.matchMedia && window.matchMedia("(prefers-color-scheme: dark)").matches;
};

const setTheme = (theme: string) => {
    new Cookies().set(ThemeCookieKey, theme, { path: "/", maxAge: 60 * 60 * 24 * 10 /* seconds -> 10 days*/ });
};

const switchTheme = (): void => {
    const current = getThemeString();
    let newTheme = "dark";
    if (current === newTheme) {
        newTheme = "light";
    }
    setTheme(newTheme);
};

const getThemeString = (): string => {
    let theme = new Cookies().get(ThemeCookieKey);
    // console.log(theme);
    if (!theme) {
        theme = defaultTheme;
        if (isBrowserDark) {
            theme = "dark";
        }
        setTheme(theme);
    }
    return theme;
};

const getTheme = (): Theme => {

    const commonPalette: PaletteOptions = {

    };

    const darkModePalette: PaletteOptions = {
        type: "dark",
        primary: {
            // main: "#CF0E58", // Red
            main: "#36C5F0", //Blue
        },
        secondary: {
            main: "#CF0E58",
            // main: "#36C5F0",
            // contrastText: "#fff",
        }
    };

    const lightModePalette: PaletteOptions = {
        type: "light",
        primary: {
            main: "#CF0E58",
        },
        secondary: {
            main: "#36C5F0",
            contrastText: "#fff",
        }
    };

    const mainTheme = createMuiTheme({
        palette: {
            ...commonPalette,
            ...(getThemeString() === "dark" ? darkModePalette : lightModePalette),
        },
    });

    return mainTheme;
};

export { getTheme, setTheme, getThemeString, switchTheme };
