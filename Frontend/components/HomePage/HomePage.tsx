import { FunctionComponent, useContext } from "react";
import Link from "next/link";
import Button from "@material-ui/core/Button";
import { ReactAuthContext } from "../../src/graphql/auth";

const HomePage: FunctionComponent<{}> = () => {

    const { isLoggedIn: isLog, user } = useContext(ReactAuthContext);

    const isLoggedIn = isLog && !!user;

    return (
        <div>
            {isLoggedIn ?
                <p>Přihlšený uživatel: {user?.firstname} {user?.lastname}</p>
                :
                <Link href="/login">
                    <Button variant="contained" color="primary">
                        Přihlášení
                    </Button>
                </Link>
            }
        </div >
    );

}

export default HomePage;