using DesafioUbc.Business.Entitys;
using DesafioUbc.Business.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DesafioUbc.Infrastructure.Data.Repositories;

public interface IUserRepository : IRepositoryBase<User>
{
    User? GetByUsername(string username);
}

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public User? GetByUsername(string username)
    {
        return _appDbContext.User.FirstOrDefault(x => x.Username == username);
    }
}