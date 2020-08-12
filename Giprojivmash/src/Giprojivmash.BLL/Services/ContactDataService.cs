using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Giprojivmash.BLL.Interfaces;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DAL.Interfaces;

namespace Giprojivmash.BLL.Services
{
    public class ContactDataService : IContactDataService
    {
        private readonly IRepository<ContactDataEntity> _phoneRepository;

        public ContactDataService(
            IRepository<ContactDataEntity> phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }

        public async Task<ContactDataEntity> GetByIdAsync(int id)
        {
           return await _phoneRepository.GetByIdAsync(id);
        }

        public IEnumerable<ContactDataEntity> GetEntities(Func<ContactDataEntity, bool> predicate)
        {
            return _phoneRepository.GetEntities(predicate).ToList();
        }

        public IEnumerable<ContactDataEntity> GetAll()
        {
            return _phoneRepository.GetAll().ToList();
        }

        public async Task CreateAsync(ContactDataEntity entity)
        {
            await _phoneRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(ContactDataEntity entity)
        {
            await _phoneRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _phoneRepository.DeleteAsync(id);
        }
    }
}
