import { ReactAuthContext, IAuthContext } from "../src/graphql/auth";
import { useContext } from "react";

const useAuth = (): IAuthContext => {
    const ctx = useContext(ReactAuthContext);

    return ctx;
};

export default useAuth;