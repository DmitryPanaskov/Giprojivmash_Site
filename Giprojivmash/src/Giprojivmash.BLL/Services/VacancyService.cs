using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Giprojivmash.BLL.Interfaces;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DAL.Interfaces;

namespace Giprojivmash.BLL.Services
{
    public class VacancyService : IVacancyService
    {
        private readonly IRepository<VacancyEntity> _vacancyRepository;

        public VacancyService(
            IRepository<VacancyEntity> vacancyRepository)
        {
            _vacancyRepository = vacancyRepository;
        }

        public async Task<VacancyEntity> GetByIdAsync(int id)
        {
           return await _vacancyRepository.GetByIdAsync(id);
        }

        public IEnumerable<VacancyEntity> GetEntities(Func<VacancyEntity, bool> predicate)
        {
            return _vacancyRepository.GetEntities(predicate).ToList();
        }

        public IEnumerable<VacancyEntity> GetAll()
        {
            return _vacancyRepository.GetAll().ToList();
        }

        public async Task CreateAsync(VacancyEntity entity)
        {
            await _vacancyRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(VacancyEntity entity)
        {
            await _vacancyRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _vacancyRepository.DeleteAsync(id);
        }
    }
}
