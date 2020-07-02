using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Giprojivmash.BLL.Interfaces;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DAL.Interfaces;

namespace Giprojivmash.BLL.Services
{
    public class ServiceThirdLayerService : IServiceThirdLayerService
    {
        private readonly IRepository<ServiceThirdLayerEntity> _serviceThirdLayerRepository;

        public ServiceThirdLayerService(IRepository<ServiceThirdLayerEntity> serviceThirdLayerRepository)
        {
            _serviceThirdLayerRepository = serviceThirdLayerRepository;
        }

        public async Task<ServiceThirdLayerEntity> GetByIdAsync(int id)
        {
            return await _serviceThirdLayerRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(ServiceThirdLayerEntity entity)
        {
            await _serviceThirdLayerRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(ServiceThirdLayerEntity entity)
        {
            await _serviceThirdLayerRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _serviceThirdLayerRepository.DeleteAsync(id);
        }

        public IEnumerable<ServiceThirdLayerEntity> GetEntities(Func<ServiceThirdLayerEntity, bool> predicate)
        {
            return _serviceThirdLayerRepository.GetEntities(predicate).ToList();
        }

        public IEnumerable<ServiceThirdLayerEntity> GetAll()
        {
            return _serviceThirdLayerRepository.GetAll().ToList();
        }
    }
}
