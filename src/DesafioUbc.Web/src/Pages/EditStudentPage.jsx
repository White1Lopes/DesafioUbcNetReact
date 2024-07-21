import {useEffect, useState} from 'react';
import {Link, useParams} from 'react-router-dom';
import {getStudentById, updateStudent} from '../Services/StudentService.jsx';
import StudentForm from '../Components/StudentForm.jsx';
import {useAuth} from '../Auth/AuthContext.jsx';
import {MoonLoader} from "react-spinners";
import {toast} from "react-toastify";
import {FaExclamationTriangle} from "react-icons/fa";

const EditStudentPage = () => {
    const {id} = useParams();
    const [initialStudent, setInitialStudent] = useState(null);
    const [loading, setLoading] = useState(false);
    const authToken = localStorage.getItem("authToken");

    useEffect(() => {
        const fetchStudent = async () => {
            setLoading(true);
            const response = await getStudentById(id, authToken);
            if (response.isValid)
                setInitialStudent(response.data);

            if (!response.isValid)
                toast.error("Houve um erro ao resgatar estudante");

            setLoading(false);
        };
        fetchStudent();
    }, [id, authToken]);

    const handleSubmit = async (student) => {
        return await updateStudent(id, student, authToken);
    };

    return (
        <>
            {(() => {
                if (loading) {
                    return <div className="flex justify-center py-14">
                        <MoonLoader/>
                    </div>
                } else if (initialStudent == null) {
                    return (
                        <section className='bg-gray-600 text-center flex flex-col justify-center items-center h-dvh'>
                            <FaExclamationTriangle className='text-yellow-400 text-6xl mb-4'/>
                            <h1 className='text-6xl font-bold mb-4'>Não foi possível encontrar o estudante</h1>
                            <p className='text-xl mb-5'>Se quiser pode voltar a página inicial</p>
                            <Link
                                to='/'
                                className='text-white bg-primary-600 hover:bg-primary-700 rounded-md px-3 py-2 mt-4'
                            >
                                Voltar para o início
                            </Link>
                        </section>)
                }
                else{
                return <StudentForm initialStudent={initialStudent} onSubmit={handleSubmit} isEdit={true}/>

                }
            })()}
        </>
    );
};

export default EditStudentPage;