using DesafioUbc.Application.Requests.Student;
using DesafioUbc.Business.Entitys;

namespace DesafioUbc.Application.Mappers;

public interface IStudentMapper
{
    Student RequestToDomain(EditorStudentRequest request);
}

public class StudentMapper : IStudentMapper
{
    public Student RequestToDomain(EditorStudentRequest request)
    {
        return new Student()
        {
            Nome = request.Nome,
            Idade = request.Idade,
            Serie = request.Serie,
            NotaMedia = request.NotaMedia,
            Endereco = request.Endereco,
            NomePai = request.NomePai,
            NomeMae = request.NomeMae,
            DataNascimento = request.DataNascimento
        };
    }
}