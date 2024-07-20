using DesafioUbc.Business.Entitys;
using DesafioUbc.Business.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DesafioUbc.Infrastructure.Data.Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T: BaseEntity
{
    protected readonly AppDbContext _appDbContext;

    public RepositoryBase(AppDbContext dbContext)
    {
        _appDbContext = dbContext;
    }

    public T Add(T entity)
    {
        _appDbContext.Add(entity);
        _appDbContext.SaveChanges();

        return entity;
    }

    public T Delete(T entity)
    {
        _appDbContext.Remove(entity);
        _appDbContext.SaveChanges();

        return entity;
    }

    public T? Get(long id)
    {
        return _appDbContext.Set<T>()
                            .AsNoTracking()
                            .FirstOrDefault(x => x.Id == id);
    }

    public T Update(T entity)
    {
        _appDbContext.Update(entity);
        _appDbContext.SaveChanges();

        return entity;
    }
}