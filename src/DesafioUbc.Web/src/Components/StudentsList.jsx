import {useEffect, useState} from 'react';
import {useAuth} from '../Auth/AuthContext.jsx';
import {deleteStudent, getStudents} from '../Services/StudentService.jsx';
import {MoonLoader} from "react-spinners";
import {Link, useNavigate} from "react-router-dom";
import {IoPersonAddOutline} from "react-icons/io5";
import {CiEdit} from "react-icons/ci";
import {MdDelete} from "react-icons/md";
import {toast} from "react-toastify";
import Modal from "./Modal.jsx";

const StudentsList = () => {
    const navigate = useNavigate();
    const {isAuthenticated} = useAuth();
    const [students, setStudents] = useState([]);
    const [page, setPage] = useState(1);
    const [totalPages, setTotalPages] = useState(1);
    const [loading, setLoading] = useState(true);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [studentToDelete, setStudentToDelete] = useState(null);
    const authToken = localStorage.getItem('authToken');

    useEffect(() => {
        if (isAuthenticated) {
            fetchStudents(page);

        }
    }, [isAuthenticated, page]);

    const fetchStudents = async (page) => {
        setLoading(true);
        try {
            const data = await getStudents(page, authToken);
            if (data.isValid) {
                setStudents(data.data);
                setTotalPages(data.totalPages);
            }
        } catch (error) {
            console.error('Erro ao buscar estudantes', error);
        } finally {
            setLoading(false);
        }
    };

    const handleNextPage = () => {
        if (page < totalPages) {
            setPage(page + 1);
        }
    };

    const handlePreviousPage = () => {
        if (page > 1) {
            setPage(page - 1);
        }
    };

    const handleDelete = async () => {
        try {
            const response = await deleteStudent(studentToDelete, localStorage.getItem('authToken'));
            setStudents(students.filter(student => student.id !== studentToDelete));
            closeModal();
            if (response.isValid) {
                toast.success('Estudante excluído com sucesso!');
                navigate('/');
            }
        } catch (error) {
            toast.error('Erro ao excluir o estudante');
        }
    };

    const openModal = (studentId) => {
        setStudentToDelete(studentId);
        setIsModalOpen(true);
    };

    const closeModal = () => {
        setStudentToDelete(null);
        setIsModalOpen(false);
    };


    return (
        <div className="container mx-auto p-4">
            <div className="flex justify-between">
                <h1 className="text-2xl font-bold mb-4 text-center">Lista de Estudantes</h1>
                <Link to="students/add" className="">
                    <IoPersonAddOutline className="w-6 h-6"/>
                </Link>
            </div>
            {(() => {
                if (loading) {
                    return (
                        <div className="flex justify-center">
                            <MoonLoader/>
                        </div>
                    )
                } else if (students.length == 0) {
                    return (<p
                        className="py-2 text-center text-xl font-bold leading-tight tracking-tight text-gray-900 md:text-2xl dark:text-white">
                        Não tem estudantes registrados
                    </p>)
                } else {
                    return (
                        <div>
                            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
                                {students.map((student) => (
                                    <div key={student.id}
                                         className="flex justify-between bg-white shadow-md rounded-lg p-4">
                                        <Link to={`/students/${student.id}`}
                                              className="m-auto text-center">
                                            <div>
                                                <h2 className="text-xl font-semibold">{student.nome}</h2>
                                                <p className="text-gray-600">Série: {student.serie}</p>
                                                <p className="text-gray-600">Idade: {student.idade}</p>
                                            </div>
                                        </Link>
                                        <div className="flex flex-col justify-between">
                                            <Link to={`students/edit/${student.id}`}>
                                                <CiEdit className="w-7 h-7"/>
                                            </Link>
                                            <button
                                                onClick={() => openModal(student.id)}>
                                                <MdDelete className="w-7 h-7"/>
                                            </button>
                                        </div>
                                    </div>
                                ))}


                            </div>
                            <div className="flex justify-between items-center mt-4">
                                <button
                                    onClick={handlePreviousPage}
                                    disabled={page === 1}
                                    className="bg-blue-500 text-white px-4 py-2 rounded disabled:bg-gray-400"
                                >
                                    Página Anterior
                                </button>
                                <span> Página {page} de {totalPages} </span>
                                <button
                                    onClick={handleNextPage}
                                    disabled={page === totalPages}
                                    className="bg-blue-500 text-white px-4 py-2 rounded disabled:bg-gray-400"
                                >
                                    Próxima Página
                                </button>
                            </div>
                        </div>
                    )
                }
            })()}
                <Modal
                isOpen={isModalOpen}
             onClose={closeModal}
             onConfirm={handleDelete}
             message="Tem certeza de que deseja excluir este estudante?"
        />
</div>
)
};

export default StudentsList;