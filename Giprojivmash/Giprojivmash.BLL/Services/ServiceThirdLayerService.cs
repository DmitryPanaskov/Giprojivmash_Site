using System.Collections.Generic;
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

        public async Task<IEnumerable<ServiceThirdLayerEntity>> GetAllAsync()
        {
            return await _serviceThirdLayerRepository.GetAllAsync();
        }
    }
}
