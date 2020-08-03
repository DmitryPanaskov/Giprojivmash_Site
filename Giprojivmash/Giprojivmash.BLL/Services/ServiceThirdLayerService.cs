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
        private readonly IRepository<ServiceSecondLayerEntity> _serviceSecondLayerRepository;

        public ServiceThirdLayerService(IRepository<ServiceThirdLayerEntity> serviceThirdLayerRepository,
            IRepository<ServiceSecondLayerEntity> serviceSecondLayerRepository)
        {
            _serviceThirdLayerRepository = serviceThirdLayerRepository;
            _serviceSecondLayerRepository = serviceSecondLayerRepository;
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

        public IEnumerable<ServiceThirdLayerEntity> GetAllServiceThirdLayerByServiceFirstId(int serviceFirstLayerId)
        {
            var serviceSecondLayerList = _serviceSecondLayerRepository.GetEntities(m => m.ServiceFirstLayerId == serviceFirstLayerId).ToList();
            var serviceThirdLayerList = from third in _serviceThirdLayerRepository.GetAll()
                              join second in serviceSecondLayerList on third.ServiceSecondLayerId equals second.Id
                              select third;
            return serviceThirdLayerList;
        }
    }
}
