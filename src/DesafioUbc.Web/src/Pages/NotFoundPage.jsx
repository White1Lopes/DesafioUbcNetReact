import {FaExclamationTriangle} from "react-icons/fa";
import {Link} from "react-router-dom";

const NotFoundPage = () => {
    return (
        <section className='bg-gray-600 text-center flex flex-col justify-center items-center h-dvh'>
            <FaExclamationTriangle className='text-yellow-400 text-6xl mb-4'/>
            <h1 className='text-6xl font-bold mb-4'>404 Not Found</h1>
            <p className='text-xl mb-5'>Essa página não existe</p>
            <Link
                to='/'
                className='text-white bg-primary-600 hover:bg-primary-700 rounded-md px-3 py-2 mt-4'
            >
                Voltar para o início
            </Link>
        </section>
    );
};

export default NotFoundPage;