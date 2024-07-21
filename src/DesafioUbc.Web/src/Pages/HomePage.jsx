import {Link, useOutletContext} from "react-router-dom";
import studentsPhoto from "../assets/students.jpeg";
import successPersonPhoto from "../assets/successPerson.jpg";
import StudentsList from "../Components/StudentsList.jsx";

const HomePage = () => {
    const {isAuthenticated, logout} = useOutletContext();

    return (
        <div>
            {isAuthenticated ? (
                <section className="bg-gray-600">
                    <StudentsList/>
                </section>
            ) : (
                <section className="flex-col justify-center items-center bg-gray-600">
                    <p className="py-3 text-center text-xl font-bold leading-tight tracking-tight text-gray-900 md:text-3xl dark:text-white">
                        A melhor plataforma escolar.
                    </p>
                    <div className="flex justify-center py-4">
                        <img className="rounded-lg shadow-2xl w-1/3 h-1/3  mr-2" src={studentsPhoto}/>
                    </div>
                    <div className="px-12 pt-6 pb-4">
                        <p className="text-center text-xl font-bold leading-tight tracking-tight text-gray-900 md:text-2xl dark:text-white">
                            Bem vindo a UBC Students, sua plataforma de cadastro e gerenciamento de alunos!
                        </p>
                        <p className="py-2 text-center text-xl font-bold leading-tight tracking-tight text-gray-900 md:text-2xl dark:text-white">
                            Logue agora e comece a gerenciar com excelência sua base.
                        </p>
                    </div>
                    <div className="text-center">
                        <Link className="rounded-lg  px-5 py-2 bg-primary-500 " to="/login">
                            Login
                        </Link>
                    </div>
                    <div className="flex justify-center py-4">
                        <img className="rounded-lg shadow-2xl w-1/3 h-1/3  mr-2" src={successPersonPhoto}/>
                    </div>
                    <div className="px-12 pt-6 pb-4">
                        <p className="text-center text-xl font-bold leading-tight tracking-tight text-gray-900 md:text-2xl dark:text-white">
                            Ainda não nos contratou e quer conhecer mais dos nossos preços e serviços?
                        </p>
                        <p className="py-2 text-center text-xl font-bold leading-tight tracking-tight text-gray-900 md:text-2xl dark:text-white">
                            Entre em contato conosco pelo botão abaixo.
                        </p>
                    </div>
                    <div className="text-center pb-4">
                        <Link className="rounded-lg  px-5 py-2 bg-primary-500 " to="/contato">
                            Contato
                        </Link>
                    </div>
                </section>
            )}
        </div>
    );
};

export default HomePage;