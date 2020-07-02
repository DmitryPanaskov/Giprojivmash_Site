using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Giprojivmash.DAL.Entities;

namespace Giprojivmash.DAL.Interfaces
{
    public interface IRepository<T>
        where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetEntities(Func<T, bool> predicate);

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);

        Task DeleteRangeAsync(IEnumerable<T> entities);
    }
}
