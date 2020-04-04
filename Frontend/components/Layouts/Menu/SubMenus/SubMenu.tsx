import { FunctionComponent } from "react";
import { Link, makeStyles, Theme, createStyles, Typography } from "@material-ui/core";
import { useRouter } from "next/router";
import classNames from "classnames";

interface SubMenuItem {
    text: string,
    link: string,
}

const useStyles = makeStyles((theme: Theme) => createStyles({
    menuContainer: {
        marginTop: "0.5rem",
    },
    menuItem: {
        padding: "0.5rem",
        display: "inline-block",
        // "&:first-child": {
        //     paddingLeft: "0",
        // }
    },
    menuItemActive: {
        borderBottom: `2px solid ${theme.palette.secondary.main}`,
    },
}));

const SubMenu: FunctionComponent = () => {
    const c = useStyles();
    const router = useRouter();

    const items: SubMenuItem[] = [
        {
            text: "Přehled",
            link: "/app",
        },
        {
            text: "Projekty",
            link: "/projectss",
        },
        {
            text: "Nastavení",
            link: "/settings",
        },
    ];

    const getItem = (item: SubMenuItem, index: number, active: boolean) => {
        const names = classNames(
            c.menuItem,
            { [c.menuItemActive]: active }
        );
        return (
            <Link key={index} href={item.link} className={names} color="textPrimary">
                <Typography variant="body1" component="span">
                    {item.text}
                </Typography>
            </Link>
        );
    };

    return (
        <div className={c.menuContainer}>
            {items.map((item, index) =>
                getItem(item, index, router.pathname === item.link)
            )}
        </div>
    );
};

export default SubMenu;
