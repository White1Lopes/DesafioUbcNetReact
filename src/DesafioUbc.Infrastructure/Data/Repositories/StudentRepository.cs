using DesafioUbc.Business.Entitys;
using DesafioUbc.Business.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DesafioUbc.Infrastructure.Data.Repositories;

public interface IStudentRepository : IRepositoryBase<Student>
{
    (List<Student>, int) GetAll(int pageNumber, int pageSize);
}

public class StudentRepository : RepositoryBase<Student>, IStudentRepository
{
    public StudentRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public (List<Student>, int) GetAll(int pageNumber, int pageSize)
    {
        var query = _appDbContext.Students
                             .AsNoTracking()
                             .OrderBy(s => s.Id);

        var students =  query
                               .Skip((pageNumber - 1) * pageSize)
                               .Take(pageSize)
                               .ToList();

        var count = query.Count();

        return (students, count);
    }
}