import { useEffect, useState } from 'react';
import { useAuth } from '../Auth/AuthContext.jsx';
import { getStudents } from '../Services/StudentService.jsx';
import {MoonLoader} from "react-spinners";

const StudentsList = () => {
    const { isAuthenticated } = useAuth();
    const [students, setStudents] = useState([]);
    const [page, setPage] = useState(1);
    const [totalPages, setTotalPages] = useState(1);
    const [loading, setLoading] = useState(true);
    const authToken  = localStorage.getItem('authToken');  // Supondo que o token JWT está no contexto

    useEffect(  () => {
        if (isAuthenticated) {
            fetchStudents(page);

        }
    }, [isAuthenticated, page]);

    const fetchStudents = async (page) => {
        setLoading(true);
        try {
            const data = await getStudents(page, authToken);
            console.log(data);
            setStudents(data.data);
            setTotalPages(data.totalPages);
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

    return (
        <div className="container mx-auto p-4">
            <h1 className="text-2xl font-bold mb-4 text-center">Lista de Estudantes</h1>
            {loading ? (
                <MoonLoader/>
            ) : (
                <div>
                    <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
                        {students.map((student) => (
                            <div key={student.id} className="text-center bg-white shadow-md rounded-lg p-4">
                                <h2 className="text-xl font-semibold">{student.nome}</h2>
                                <p className="text-gray-600">Série: {student.serie}</p>
                                <p className="text-gray-600">Idade: {student.idade}</p>
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
            )}
        </div>
    );
};

export default StudentsList;