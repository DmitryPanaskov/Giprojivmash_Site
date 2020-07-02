using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Giprojivmash.BLL.Interfaces;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DAL.Interfaces;

namespace Giprojivmash.BLL.Services
{
    public class ServiceFirstLayerService : IServiceFirstLayerService
    {
        private readonly IRepository<ServiceFirstLayerEntity> _serviceFirstLayerRepository;
        private readonly IRepository<ServiceSecondLayerEntity> _serviceSecondLayerRepository;
        private readonly IRepository<ServiceThirdLayerEntity> _serviceThirdLayerRepository;

        public ServiceFirstLayerService(
            IRepository<ServiceFirstLayerEntity> serviceFirstLayerRepository,
            IRepository<ServiceSecondLayerEntity> serviceSecondLayerRepository,
            IRepository<ServiceThirdLayerEntity> serviceThirdLayerRepository)
        {
            _serviceFirstLayerRepository = serviceFirstLayerRepository;
            _serviceSecondLayerRepository = serviceSecondLayerRepository;
            _serviceThirdLayerRepository = serviceThirdLayerRepository;
        }

        public async Task<ServiceFirstLayerEntity> GetByIdAsync(int id)
        {
            return await _serviceFirstLayerRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(ServiceFirstLayerEntity entity)
        {
            await _serviceFirstLayerRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(ServiceFirstLayerEntity entity)
        {
            await _serviceFirstLayerRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteServiceSecondLayer(id);
            await _serviceFirstLayerRepository.DeleteAsync(id);
        }

        public IEnumerable<ServiceFirstLayerEntity> GetAll()
        {
            return _serviceFirstLayerRepository.GetAll().ToList();
        }

        public IEnumerable<ServiceFirstLayerEntity> GetEntities(Func<ServiceFirstLayerEntity, bool> predicate)
        {
            return _serviceFirstLayerRepository.GetEntities(predicate).ToList();
        }

        private async Task DeleteServiceSecondLayer(int id)
        {
            var list = _serviceSecondLayerRepository.GetEntities(m => m.ServiceFirstLayerId == id).ToList();
            await DeleteServiceThirdLayer(list);
            await _serviceSecondLayerRepository.DeleteRangeAsync(list);
        }

        private async Task DeleteServiceThirdLayer(IEnumerable<ServiceSecondLayerEntity> serviceSecondLayerEntities)
        {
            foreach (var item in serviceSecondLayerEntities)
            {
                var list = _serviceThirdLayerRepository.GetEntities(m => m.ServiceSecondLayerId == item.Id).ToList();
                await _serviceThirdLayerRepository.DeleteRangeAsync(list);
            }
        }
    }
}
