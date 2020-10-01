using System.Threading.Tasks;
using Giprojivmash.DAL.Context;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DAL.Interfaces;

namespace Giprojivmash.DAL.Repositories
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly GiprojivmashContext _context;

        public IdentityRepository(GiprojivmashContext context)
        {
            _context = context;
        }

        public async Task UpdateAsync(UserEntity entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
