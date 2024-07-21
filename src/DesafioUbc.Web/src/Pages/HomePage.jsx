import {useAuth} from "../Auth/AuthContext.jsx";
import {useOutletContext} from "react-router-dom";
const HomePage = () => {
    const { isAuthenticated, logout } = useOutletContext();

    return (
        <div>
            {isAuthenticated ? (
                <p>Você está logado.</p>
            ) : (
                <p>Você não está logado.</p>
            )}
        </div>
    );
};

export default HomePage;