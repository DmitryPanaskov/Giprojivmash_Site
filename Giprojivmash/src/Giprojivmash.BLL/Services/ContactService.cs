using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Giprojivmash.BLL.Interfaces;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DAL.Interfaces;

namespace Giprojivmash.BLL.Services
{
    public class ContactService : IContactService
    {
        private readonly IRepository<ContactEntity> _contactRepository;
        private readonly IRepository<ContactPhoneEntity> _contactPhoneRepository;

        public ContactService(
            IRepository<ContactEntity> contactRepository,
            IRepository<ContactPhoneEntity> contactPhoneRepository)
        {
            _contactRepository = contactRepository;
            _contactPhoneRepository = contactPhoneRepository;
        }

        public async Task<ContactEntity> GetByIdAsync(int id)
        {
           return await _contactRepository.GetByIdAsync(id);
        }

        public IEnumerable<ContactEntity> GetEntities(Func<ContactEntity, bool> predicate)
        {
            return _contactRepository.GetEntities(predicate).ToList();
        }

        public IEnumerable<ContactEntity> GetAll()
        {
            return _contactRepository.GetAll().ToList();
        }

        public async Task CreateAsync(ContactEntity entity)
        {
            await _contactRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(ContactEntity entity)
        {
            await _contactRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteContactPhone(id);
            await _contactRepository.DeleteAsync(id);
        }

        private async Task DeleteContactPhone(int id)
        {
            var list = _contactPhoneRepository.GetEntities(m => m.ContactId == id).ToList();
            await _contactPhoneRepository.DeleteRangeAsync(list);
        }
    }
}
