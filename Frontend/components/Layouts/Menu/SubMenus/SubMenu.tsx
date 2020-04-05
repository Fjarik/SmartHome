import { FunctionComponent } from "react";
import { Link, makeStyles, Theme, createStyles, Typography } from "@material-ui/core";
import { useRouter } from "next/router";
import classNames from "classnames";
import customUrls from "../../../../utils/customUrls";

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
    },
    menuItemActive: {
        borderBottom: `2px solid ${theme.palette.secondary.main}`,
    },
}));

const SubMenu: FunctionComponent = () => {
    const c = useStyles();
    const router = useRouter();

    const { app: { appUrl, projects, settings } } = customUrls;

    const items: SubMenuItem[] = [
        {
            text: "Přehled",
            link: appUrl,
        },
        {
            text: "Projekty",
            link: projects,
        },
        {
            text: "Nastavení",
            link: settings,
        },
    ];

    const isActive = (link: string): boolean => {
        if (link == appUrl) {
            return router.pathname == link;
        }
        const withoutApp = link.replace(appUrl, "");
        return router.pathname.includes(withoutApp);
    };

    const getItem = ({ link, text }: SubMenuItem, index: number) => {
        const active = isActive(link);
        const names = classNames(
            c.menuItem,
            { [c.menuItemActive]: active }
        );
        return (
            <Link key={index} href={link} className={names} color="textPrimary">
                <Typography variant="body1" component="span">
                    {text}
                </Typography>
            </Link>
        );
    };

    return (
        <div className={c.menuContainer}>
            {items.map((item, index) =>
                getItem(item, index)
            )}
        </div>
    );
};

export default SubMenu;
