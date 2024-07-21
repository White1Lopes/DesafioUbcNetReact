import {Route, createBrowserRouter, createRoutesFromElements, RouterProvider} from 'react-router-dom';
import HomePage from "./Pages/HomePage.jsx";
import MainLayout from "./Layouts/MainLayout.jsx";
import NotFoundPage from "./Pages/NotFoundPage.jsx";
import LoginPage from "./Pages/LoginPage.jsx";
import {AuthProvider} from "./Auth/AuthContext.jsx";
import StudentsPage from "./Pages/StudentsPage.jsx";

const App = () => {

    const router = createBrowserRouter(
        createRoutesFromElements(
            <Route path='/' element={<MainLayout/>}>
                <Route index element={<HomePage/>}/>
                <Route path="/login" element={<LoginPage/>}/>
                <Route path="/students" element={<StudentsPage />} />
                <Route path='*' element={<NotFoundPage/>}/>
            </Route>
        )
    );

    return (
        <AuthProvider>
            <RouterProvider router={router} />
        </AuthProvider>
    );
};

export default App;