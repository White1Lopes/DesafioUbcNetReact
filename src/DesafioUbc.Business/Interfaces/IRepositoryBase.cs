using DesafioUbc.Business.Entitys;

namespace DesafioUbc.Business.Interfaces;

public interface IRepositoryBase<T> where T : BaseEntity {
    T Add(T entity);
    T Delete(T entity);
    T? Get(long id);
    T Update(T entity);
}