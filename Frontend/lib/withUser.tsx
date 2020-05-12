import { FunctionComponent, useEffect } from "react";
import { useRouter } from "next/router";
import customUrls from "utils/customUrls";
import { NextPage } from "next";
import { useSnackbar } from "notistack";
import useAuth from "./useAuth";

const withUser = (Component: NextPage) => {
    const hocComponent: FunctionComponent = ({ ...props }) => {

        const router = useRouter();
        const { enqueueSnackbar } = useSnackbar();
        const { account: { loginUrl } } = customUrls;
        const { user, loading, logout } = useAuth();

        useEffect(() => {
            if (loading) {
                return;
            }

            if (!user) {
                enqueueSnackbar("Pro přístup na tuto stránku musíte být přihlášen/a", { variant: "warning" });
                logout();
                router.push(loginUrl);
                return;
            }
            return () => {
            };
        }, [loading]);

        return <Component {...props} />;
    };

    return hocComponent;
};


export default withUser;