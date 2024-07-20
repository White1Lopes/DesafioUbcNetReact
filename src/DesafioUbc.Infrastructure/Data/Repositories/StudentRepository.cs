using DesafioUbc.Business.Entitys;
using DesafioUbc.Business.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DesafioUbc.Infrastructure.Data.Repositories;

public interface IStudentRepository : IRepositoryBase<Student>
{
    List<Student> GetAll();
}

public class StudentRepository : RepositoryBase<Student>, IStudentRepository
{
    public StudentRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public List<Student> GetAll()
    {
        return _appDbContext.Students.AsNoTracking().ToList();
    }
}