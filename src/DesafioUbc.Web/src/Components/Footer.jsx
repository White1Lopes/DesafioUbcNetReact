import {Link} from "react-router-dom";

const Footer = () => {
    return (
        <footer className="bg-gray-700  shadow  dark:bg-gray-700">
            <div className="w-full mx-auto max-w-screen-xl p-4 md:flex md:items-center md:justify-between">
      <span className="text-sm text-gray-500 sm:text-center dark:text-gray-400">© 2024 <Link
          className="hover:underline" to="/">UBC Students</Link>. Todos os direitos reservados.
    </span>
                <ul className="flex flex-wrap items-center px-12 mt-3 text-sm font-medium text-gray-500 dark:text-gray-400 sm:mt-0">
                    <li>
                        <a href="/Sobre" className="hover:underline me-4 md:me-6">Sobre</a>
                    </li>
                    <li>
                        <a href="/Contato" className="hover:underline">Contato</a>
                    </li>
                </ul>
            </div>
        </footer>
    );
};

export default Footer;