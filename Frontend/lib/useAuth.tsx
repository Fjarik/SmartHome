import { useContext } from "react";
import { ReactAuthContext, IAuthContext } from "./auth/authContext";

const useAuth = (): IAuthContext => {
    const ctx = useContext(ReactAuthContext);

    return ctx;
};

export default useAuth;