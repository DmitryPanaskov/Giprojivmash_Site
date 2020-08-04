using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Giprojivmash.BLL.Interfaces
{
    public interface IBaseInterface<T>
    {
        Task<T> GetByIdAsync(int id);

        IEnumerable<T> GetEntities(Func<T, bool> predicate);

        IEnumerable<T> GetAll();

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);
    }
}
