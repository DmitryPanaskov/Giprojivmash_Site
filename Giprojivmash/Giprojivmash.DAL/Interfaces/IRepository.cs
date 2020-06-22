using System.Collections.Generic;
using System.Threading.Tasks;
using Giprojivmash.DAL.Entities;

namespace Giprojivmash.DAL.Interfaces
{
    public interface IRepository<T>
        where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);
    }
}
