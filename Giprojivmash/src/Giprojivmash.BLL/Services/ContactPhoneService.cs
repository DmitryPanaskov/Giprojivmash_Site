using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Giprojivmash.BLL.Interfaces;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DAL.Interfaces;

namespace Giprojivmash.BLL.Services
{
    public class ContactPhoneService : IContactPhoneService
    {
        private readonly IRepository<ContactPhoneEntity> _phoneRepository;

        public ContactPhoneService(
            IRepository<ContactPhoneEntity> phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }

        public async Task<ContactPhoneEntity> GetByIdAsync(int id)
        {
           return await _phoneRepository.GetByIdAsync(id);
        }

        public IEnumerable<ContactPhoneEntity> GetEntities(Func<ContactPhoneEntity, bool> predicate)
        {
            return _phoneRepository.GetEntities(predicate).ToList();
        }

        public IEnumerable<ContactPhoneEntity> GetAll()
        {
            return _phoneRepository.GetAll().ToList();
        }

        public async Task CreateAsync(ContactPhoneEntity entity)
        {
            await _phoneRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(ContactPhoneEntity entity)
        {
            await _phoneRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _phoneRepository.DeleteAsync(id);
        }
    }
}
