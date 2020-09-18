using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER.Domain.Interfaces
{
    public interface IService<T>
    {
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<List<T>> GetAll();
        Task<T> GetById(Guid id);
    }
}
