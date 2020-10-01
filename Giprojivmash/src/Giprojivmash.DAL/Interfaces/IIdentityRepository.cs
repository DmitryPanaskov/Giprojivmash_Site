using System.Threading.Tasks;
using Giprojivmash.DAL.Entities;

namespace Giprojivmash.DAL.Interfaces
{
    public interface IIdentityRepository
    {
        Task UpdateAsync(UserEntity entity);
    }
}
