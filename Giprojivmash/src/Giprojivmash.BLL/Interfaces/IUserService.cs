using System.Security.Principal;
using System.Threading.Tasks;
using Giprojivmash.DAL.Entities;

namespace Giprojivmash.BLL.Interfaces
{
    public interface IUserService : IIdentity
    {
        Task UpdateAsync(UserEntity entity);
    }
}
