import {useState} from 'react';
import {useNavigate} from 'react-router-dom';
import {toast} from 'react-toastify';
import {createStudent} from "../Services/StudentService.jsx";
import StudentForm from "../Components/StudentForm.jsx";

const CreateStudentPage = () => {
    const navigate = useNavigate();

    const handleSubmit = async (student) => {
        return await createStudent(student, localStorage.getItem('authToken'));
    };

    return <StudentForm onSubmit={handleSubmit}/>;
};
export default CreateStudentPage;