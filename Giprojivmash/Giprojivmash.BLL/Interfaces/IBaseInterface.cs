using System.Collections.Generic;
using System.Threading.Tasks;

namespace Giprojivmash.BLL.Interfaces
{
    public interface IBaseInterface<T>
    {
        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);
    }
}
