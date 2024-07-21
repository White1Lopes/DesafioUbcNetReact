import {useEffect, useState} from 'react';
import {useAuth} from '../Auth/AuthContext.jsx';
import {getStudents} from '../Services/StudentService.jsx';
import {MoonLoader} from "react-spinners";
import StudentsList from "../Components/StudentsList.jsx";

const StudentsPage = () => {
    return (
        <div className="bg-gray-600">
            <StudentsList/>
        </div>
    );
};

export default StudentsPage;