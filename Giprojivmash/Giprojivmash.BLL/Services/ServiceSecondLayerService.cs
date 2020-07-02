using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Giprojivmash.BLL.Interfaces;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DAL.Interfaces;

namespace Giprojivmash.BLL.Services
{
    public class ServiceSecondLayerService : IServiceSecondLayerService
    {
        private readonly IRepository<ServiceSecondLayerEntity> _serviceSecondLayerRepository;
        private readonly IRepository<ServiceThirdLayerEntity> _serviceThirdLayerRepository;

        public ServiceSecondLayerService(IRepository<ServiceSecondLayerEntity> serviceSecondLayerRepository,
             IRepository<ServiceThirdLayerEntity> serviceThirdLayerRepository)
        {
            _serviceSecondLayerRepository = serviceSecondLayerRepository;
            _serviceThirdLayerRepository = serviceThirdLayerRepository;
        }

        public async Task<ServiceSecondLayerEntity> GetByIdAsync(int id)
        {
            return await _serviceSecondLayerRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(ServiceSecondLayerEntity entity)
        {
            await _serviceSecondLayerRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(ServiceSecondLayerEntity entity)
        {
            await _serviceSecondLayerRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteServiceThirdLayer(id);
            await _serviceSecondLayerRepository.DeleteAsync(id);
        }

        public IEnumerable<ServiceSecondLayerEntity> GetEntities(Func<ServiceSecondLayerEntity, bool> predicate)
        {
            return _serviceSecondLayerRepository.GetEntities(predicate).ToList();
        }

        public IEnumerable<ServiceSecondLayerEntity> GetAll()
        {
            return _serviceSecondLayerRepository.GetAll().ToList();
        }

        private async Task DeleteServiceThirdLayer(int id)
        {
            var list = _serviceThirdLayerRepository.GetEntities(m => m.ServiceSecondLayerId == id).ToList();
            await _serviceThirdLayerRepository.DeleteRangeAsync(list);
        }
    }
}
