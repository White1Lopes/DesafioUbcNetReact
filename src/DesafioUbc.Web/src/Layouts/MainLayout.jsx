import {Outlet} from "react-router-dom";
import NavBar from "../Components/NavBar.jsx";
import {useAuth} from "../Auth/AuthContext.jsx";
const MainLayout = () => {
    const { isAuthenticated, logout } = useAuth();

    return (
        <>
            <NavBar isAuthenticated={isAuthenticated} logout={logout} />
            <Outlet context={{isAuthenticated, logout}} />
        </>
    );
};

export default MainLayout;