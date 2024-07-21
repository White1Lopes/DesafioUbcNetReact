import {Route, createBrowserRouter, createRoutesFromElements, RouterProvider} from 'react-router-dom';
import HomePage from "./Pages/HomePage.jsx";
import MainLayout from "./Layouts/MainLayout.jsx";
import NotFoundPage from "./Pages/NotFoundPage.jsx";
import LoginPage from "./Pages/LoginPage.jsx";
import {AuthProvider} from "./Auth/AuthContext.jsx";
import StudentsPage from "./Pages/StudentsPage.jsx";
import CreateStudentPage from "./Pages/CreateStudentPage.jsx";
import EditStudentPage from "./Pages/EditStudentPage.jsx";
import StudentPage from "./Pages/StudentPage.jsx";

const App = () => {

    const router = createBrowserRouter(
        createRoutesFromElements(
            <Route path='/' element={<MainLayout/>}>
                <Route index element={<HomePage/>}/>
                <Route path="/login" element={<LoginPage/>}/>
                <Route path="/students" element={<StudentsPage/>}/>
                <Route path="/students/add" element={<CreateStudentPage/>}/>
                <Route path="/students/edit/:id" element={<EditStudentPage/>}/>
                <Route path="/students/:id" element={<StudentPage/>}/>
                <Route path='*' element={<NotFoundPage/>}/>
            </Route>
        )
    );

    return (
        <AuthProvider>
            <RouterProvider router={router}/>
        </AuthProvider>
    );
};

export default App;