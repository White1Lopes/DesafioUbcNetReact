import {useEffect, useState} from 'react';
import {Link, useNavigate, useParams} from 'react-router-dom';
import {deleteStudent, getStudentById} from '../Services/StudentService';
import StudentDetail from '../Components/StudentDetail';
import {toast} from 'react-toastify';
import {MoonLoader} from "react-spinners";
import Modal from "../Components/Modal.jsx";

const StudentPage = () => {
    const {id} = useParams();
    const navigate = useNavigate();
    const [student, setStudent] = useState(null);
    const [loading, setLoading] = useState(true);
    const [isModalOpen, setIsModalOpen] = useState(false);

    useEffect(() => {
        const fetchStudent = async () => {
            try {
                const response = await getStudentById(id, localStorage.getItem('authToken'));
                setStudent(response.data);
            } catch (error) {
                toast.error('Erro ao buscar os detalhes do estudante');
            } finally {
                setLoading(false);
            }
        };

        fetchStudent();
    }, [id]);

    const handleDelete = async () => {
        try {
            await deleteStudent(id, localStorage.getItem('authToken'));
            toast.success('Estudante excluído com sucesso!');
            navigate('/');
        } catch (error) {
            toast.error('Erro ao excluir o estudante');
        }
    };

    const openModal = () => setIsModalOpen(true);
    const closeModal = () => setIsModalOpen(false);

    if (loading) {
        return <MoonLoader/>;
    }

    if (!student) {
        return <div className="h-[80vh] text-center container mx-auto p-4">Estudante não encontrado.</div>;
    }

    return (
        <div className="container mx-auto p-4">
            <h1 className="text-2xl font-bold mb-4">Detalhes do Estudante</h1>
            <StudentDetail student={student}/>
            <Link
                to={`/students/edit/${student.id}`}
                className="mt-4 bg-orange-500 hover:bg-red-600 text-white font-bold py-3 px-4 rounded-full mr-2"
            >
                Editar Estudante
            </Link>
            <button
                className="mt-4 bg-red-500 hover:bg-red-600 text-white font-bold py-2 px-4 rounded-full"
                onClick={openModal}
            >
                Excluir Estudante
            </button>
            <Modal
                isOpen={isModalOpen}
                onClose={closeModal}
                onConfirm={handleDelete}
                message="Tem certeza de que deseja excluir este estudante?"
            />
        </div>
    );
};

export default StudentPage;