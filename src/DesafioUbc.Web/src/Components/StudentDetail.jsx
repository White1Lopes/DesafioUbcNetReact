const StudentDetail = ({student}) => {
    return (
        <div className="bg-white p-6 rounded-lg shadow-md">
            <h2 className="text-2xl font-bold mb-4">{student.nome}</h2>
            <div className="mb-2"><strong>Idade:</strong> {student.idade}</div>
            <div className="mb-2"><strong>Série:</strong> {student.serie}</div>
            <div className="mb-2"><strong>Nota Média:</strong> {student.notaMedia}</div>
            <div className="mb-2"><strong>Endereço:</strong> {student.endereco}</div>
            <div className="mb-2"><strong>Nome do Pai:</strong> {student.nomePai}</div>
            <div className="mb-2"><strong>Nome da Mãe:</strong> {student.nomeMae}</div>
            <div className="mb-2"><strong>Data de
                Nascimento:</strong> {new Date(student.dataNascimento).toLocaleDateString()}</div>
        </div>
    );
};

export default StudentDetail;