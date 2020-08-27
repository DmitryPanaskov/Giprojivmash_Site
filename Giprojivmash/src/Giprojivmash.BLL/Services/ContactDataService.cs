using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Giprojivmash.BLL.Interfaces;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DAL.Interfaces;
using Giprojivmash.DataModels.Enums;

namespace Giprojivmash.BLL.Services
{
    public class ContactDataService : IContactDataService
    {
        private readonly IRepository<ContactEntity> _contactRepository;
        private readonly IRepository<ContactDataEntity> _contactDataRepository;

        public ContactDataService(
            IRepository<ContactDataEntity> contactDataRepository,
            IRepository<ContactEntity> contactRepository)
        {
            _contactRepository = contactRepository;
            _contactDataRepository = contactDataRepository;
        }

        public async Task<ContactDataEntity> GetByIdAsync(int id)
        {
            return await _contactDataRepository.GetByIdAsync(id);
        }

        public IEnumerable<ContactDataEntity> GetEntities(Func<ContactDataEntity, bool> predicate)
        {
            return _contactDataRepository.GetEntities(predicate).ToList();
        }

        public IEnumerable<ContactDataEntity> GetAll()
        {
            return _contactDataRepository.GetAll().ToList();
        }

        public async Task CreateAsync(ContactDataEntity entity)
        {
            await _contactDataRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(ContactDataEntity entity)
        {
            await _contactDataRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _contactDataRepository.DeleteAsync(id);
        }

        public IEnumerable<ContactDataEntity> GetContactDataListByPositionType(PositionType position)
        {
            var a = _contactRepository.GetAll().ToList();
            Console.WriteLine(a);
            var contactList = _contactRepository.GetEntities(m => m.PositionType == position).ToList();
            var contactDataList = _contactDataRepository.GetAll();
            var contactDataListByPositionType = (from contact in contactList
                                                 join contactData in contactDataList
                                                 on contact.Id equals contactData.ContactId
                                                 select contactData).ToList();
            return contactDataListByPositionType;
        }
    }
}
