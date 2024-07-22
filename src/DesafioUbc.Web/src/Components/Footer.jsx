import {Link} from "react-router-dom";

const Footer = () => {
    return (
        <footer className="bg-gray-700  shadow  dark:bg-gray-700">
            <div className="w-full mx-auto max-w-screen-xl p-4 md:flex md:items-center md:justify-center">
      <span className="text-sm text-gray-500 sm:text-center dark:text-gray-400">© 2024 <Link
          className="hover:underline" to="/">UBC Students</Link>. Todos os direitos reservados.
    </span>
            </div>
        </footer>
    );
};

export default Footer;