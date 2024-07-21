import {useState, useEffect} from 'react';
import {useNavigate} from 'react-router-dom';
import {toast} from 'react-toastify';

const StudentForm = ({initialStudent, onSubmit, isEdit}) => {
    const [nome, setNome] = useState(initialStudent?.nome || '');
    const [idade, setIdade] = useState(initialStudent?.idade || 0);
    const [serie, setSerie] = useState(initialStudent?.serie || 0);
    const [notaMedia, setNotaMedia] = useState(initialStudent?.notaMedia || 0.0);
    const [endereco, setEndereco] = useState(initialStudent?.endereco || '');
    const [nomePai, setNomePai] = useState(initialStudent?.nomePai || '');
    const [nomeMae, setNomeMae] = useState(initialStudent?.nomeMae || '');
    const [dataNascimento, setDataNascimento] = useState(initialStudent?.dataNascimento ? new Date(initialStudent.dataNascimento) : new Date());

    const navigate = useNavigate();

    const handleDatetimeChange = (event) => {
        setDataNascimento(new Date(event.target.value));
    };

    const submitForm = async (e) => {
        e.preventDefault();

        const student = {
            nome,
            idade,
            serie,
            notaMedia,
            endereco,
            nomePai,
            nomeMae,
            dataNascimento
        };

        const response = await onSubmit(student);

        if (response.isValid) {
            toast.success(`Estudante ${isEdit ? "editado" : "registrado"} com sucesso!`);
            return navigate(`/students/${response.data.id}`);
        }

        toast.error("Ocorreu um erro durante a operação");
    };

    return (
        <section className='bg-gray-500'>
            <div className='container m-auto max-w-2xl py-24'>
                <div className='bg-gray-400 px-6 py-8 mb-4 shadow-md rounded-md  m-4 md:m-0'>
                    <form onSubmit={submitForm}>
                        <h2 className='text-3xl text-center font-semibold mb-6'>{initialStudent ? 'Editar Estudante' : 'Registrar Estudante'}</h2>

                        <div className='mb-4'>
                            <label
                                htmlFor='nome'
                                className='block text-gray-700 font-bold mb-2'
                            >
                                Nome
                            </label>
                            <input
                                type='text'
                                id='nome'
                                name='nome'
                                className='border rounded w-full py-2 px-3 mb-2'
                                placeholder='Luiz Gustavo'
                                required
                                value={nome}
                                onChange={(e) => setNome(e.target.value)}
                            />
                        </div>

                        <div className='mb-4'>
                            <label
                                htmlFor="idade"
                                className='block text-gray-700 font-bold mb-2'>
                                Idade
                            </label>
                            <input
                                type='number'
                                id='idade'
                                name='idade'
                                className='border rounded w-full py-2 px-3 mb-2'
                                required
                                value={idade}
                                onChange={(e) => setIdade(e.target.value)}
                            />
                        </div>

                        <div className='mb-4'>
                            <label
                                htmlFor='serie'
                                className='block text-gray-700 font-bold mb-2'
                            >
                                Série
                            </label>
                            <input
                                type='number'
                                id='serie'
                                name='serie'
                                className='border rounded w-full py-2 px-3 mb-2'
                                required
                                value={serie}
                                onChange={(e) => setSerie(e.target.value)}
                            />
                        </div>

                        <div className='mb-4'>
                            <label
                                htmlFor='notaMedia'
                                className='block text-gray-700 font-bold mb-2'
                            >
                                Nota Média
                            </label>
                            <input
                                type='number'
                                id='notaMedia'
                                name='notaMedia'
                                className='border rounded w-full py-2 px-3 mb-2'
                                required
                                value={notaMedia}
                                onChange={(e) => setNotaMedia(e.target.value)}
                            />
                        </div>

                        <div className='mb-4'>
                            <label
                                htmlFor="endereco"
                                className='block text-gray-700 font-bold mb-2'>
                                Endereço
                            </label>
                            <input
                                type='text'
                                id='endereco'
                                name='endereco'
                                className='border rounded w-full py-2 px-3 mb-2'
                                placeholder='Rua da salvação 820, c16'
                                required
                                value={endereco}
                                onChange={(e) => setEndereco(e.target.value)}
                            />
                        </div>

                        <div className='mb-4'>
                            <label
                                htmlFor='nomePai'
                                className='block text-gray-700 font-bold mb-2'
                            >
                                Nome do pai
                            </label>
                            <input
                                type='text'
                                id='nomePai'
                                name='nomePai'
                                className='border rounded w-full py-2 px-3 mb-2'
                                placeholder='Reginaldo'
                                required
                                value={nomePai}
                                onChange={(e) => setNomePai(e.target.value)}
                            />
                        </div>

                        <div className='mb-4'>
                            <label
                                htmlFor='nomeMae'
                                className='block text-gray-700 font-bold mb-2'
                            >
                                Nome da mãe
                            </label>
                            <input
                                type='text'
                                id='nomeMae'
                                name='nomeMae'
                                className='border rounded w-full py-2 px-3 mb-2'
                                placeholder='Angela'
                                required
                                value={nomeMae}
                                onChange={(e) => setNomeMae(e.target.value)}
                            />
                        </div>

                        <div className='mb-4'>
                            <label
                                htmlFor='dataNascimento'
                                className='block text-gray-700 font-bold mb-2'
                            >
                                Data de Nascimento
                            </label>
                            <input
                                type="datetime-local"
                                id="dataNascimento"
                                className='border rounded w-full py-2 px-3'
                                value={dataNascimento.toISOString().substring(0, 16)}
                                onChange={handleDatetimeChange}
                            />
                        </div>

                        <div>
                            <button
                                className='bg-primary-500 hover:bg-primary-600 text-white font-bold py-2 px-4 rounded-full w-full focus:outline-none focus:shadow-outline'
                                type='submit'
                            >
                                {initialStudent ? 'Atualizar Estudante' : 'Registrar Estudante'}
                            </button>
                        </div>
                    </form>
                </div>
            </div>
        </section>
    );
};

export default StudentForm;