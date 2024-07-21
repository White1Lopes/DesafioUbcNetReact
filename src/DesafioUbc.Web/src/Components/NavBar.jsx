import {NavLink} from 'react-router-dom';
import {CiLogin, CiLogout} from "react-icons/ci";
import {FaHome} from "react-icons/fa";
import logo from '../assets/student.png'

const NavBar = ({isAuthenticated, logout}) => {
    const linkClass = ({isActive}) =>
        isActive
            ? 'bg-gray-700 text-white hover:bg-gray-900 hover:text-white rounded-md px-3 py-2'
            : 'text-white hover:bg-gray-900 hover:text-white rounded-md px-3 py-2';

    return (
        <nav className='bg-gray-700 border-b border-gray-500'>
            <div className='mx-auto max-w-7xl px-2 sm:px-6 lg:px-8'>
                <div className='flex h-20 items-center justify-between'>
                    <div className='flex flex-1  justify-between items-stretch '>
                        <NavLink className='flex flex-shrink-0 items-center mr-4' to='/'>
                            <img className=' md:px-0 px-20 h-10 w-auto' src={logo} alt='UBC Students'/>
                            <span className='hidden md:block text-white text-2xl font-bold ml-2'>
                UBC Students
              </span>
                        </NavLink>
                        <div className='md:ml-auto'>
                            <div className='flex space-x-2'>
                                <NavLink to='/' className={linkClass}>
                                    <FaHome/>
                                </NavLink>
                                {isAuthenticated
                                    ? <NavLink to='/' className={linkClass}>
                                        <CiLogout onClick={logout}/>
                                    </NavLink>
                                    : <NavLink to='/login' className={linkClass}>
                                        <CiLogin/>
                                    </NavLink>
                                }
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </nav>
    );
};
export default NavBar;