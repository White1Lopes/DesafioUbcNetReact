import {Outlet} from "react-router-dom";
import NavBar from "../Components/NavBar.jsx";
import {useAuth} from "../Auth/AuthContext.jsx";
import Footer from "../Components/Footer.jsx";
import {ToastContainer} from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';

const MainLayout = () => {
    const {isAuthenticated, logout} = useAuth();

    return (
        <>
            <NavBar isAuthenticated={isAuthenticated} logout={logout}/>
            <Outlet context={{isAuthenticated, logout}}/>
            <ToastContainer/>
            <Footer/>
        </>
    );
};

export default MainLayout;