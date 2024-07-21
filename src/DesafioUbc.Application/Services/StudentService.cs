using DesafioUbc.Application.Mappers;
using DesafioUbc.Application.Requests.Student;
using DesafioUbc.Application.Responses;
using DesafioUbc.Business.Entitys;
using DesafioUbc.Infrastructure.Data.Repositories;

namespace DesafioUbc.Application.Services;

public interface IStudentService
{
    Response<Student?> Create(EditorStudentRequest request);
    PagedResponse<List<Student>> GetAll(GetAllStudentsRequest request);
    Response<Student?> GetById(long id);
    Response<Student?> Update(long id, EditorStudentRequest request);
    Response<Student?> Delete(long id);
}

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly IStudentMapper _studentMapper;

    public StudentService(IStudentRepository studentRepository, IStudentMapper studentMapper)
    {
        _studentRepository = studentRepository;
        _studentMapper = studentMapper;
    }

    public Response<Student?> Create(EditorStudentRequest request)
    {
        return new Response<Student?>(_studentRepository.Add(_studentMapper.RequestToDomain(request)), true);
    }

    public PagedResponse<List<Student>> GetAll(GetAllStudentsRequest request)
    {
        var (students, count) = _studentRepository.GetAll(request.PageNumber, request.PageSize);

        return new PagedResponse<List<Student>>(
            students,
            count,
            request.PageNumber, request.PageSize);
    }

    public Response<Student?> GetById(long id)
    {
        var student = _studentRepository.Get(id);

        return student is null
            ? new Response<Student?>(null, false)
            : new Response<Student?>(student, true);
    }

    public Response<Student?> Update(long id, EditorStudentRequest request)
    {
        var student = _studentRepository.Get(id);

        if (student is null) return new Response<Student?>(null, false);

        student = _studentMapper.RequestToDomain(request);
        student.Id = id;

        student = _studentRepository.Update(student);

        return new Response<Student?>(student, true);
    }

    public Response<Student?> Delete(long id)
    {
        var student = _studentRepository.Get(id);

        if (student is null) return new Response<Student?>(null, false);

        _studentRepository.Delete(student);

        return new Response<Student?>(student, true);
    }
}