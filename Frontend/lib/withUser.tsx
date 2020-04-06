import { FunctionComponent, useEffect, useContext } from "react";
import { ReactAuthContext, getToken } from "../src/graphql/auth";
import { useRouter } from "next/router";
import customUrls from "../utils/customUrls";
import { NextPage } from "next";

const withUser = (Component: NextPage) => {
    const hocComponent: FunctionComponent = ({ ...props }) => {

        const router = useRouter();
        const { account: { loginUrl } } = customUrls;

        useEffect(() => {
            const token = getToken();
            // console.log(token);
            if (!token) {
                console.log("You must be logeed in");
                router.push(loginUrl);
                return;
            }
            return () => {
            };
        }, []);

        return <Component {...props} />;
    };

    return hocComponent;
};


export default withUser;