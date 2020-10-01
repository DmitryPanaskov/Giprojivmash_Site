using System.Threading.Tasks;
using Giprojivmash.BLL.Interfaces;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DAL.Interfaces;

namespace Giprojivmash.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IIdentityRepository _repository;

        public UserService(IIdentityRepository repository)
        {
            _repository = repository;
        }

        public string AuthenticationType { get; }

        public bool IsAuthenticated { get; }

        public string Name { get; }

        public async Task UpdateAsync(UserEntity entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
