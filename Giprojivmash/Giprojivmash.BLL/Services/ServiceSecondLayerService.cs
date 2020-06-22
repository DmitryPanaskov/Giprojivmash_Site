using System.Collections.Generic;
using System.Threading.Tasks;
using Giprojivmash.BLL.Interfaces;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DAL.Interfaces;

namespace Giprojivmash.BLL.Services
{
    public class ServiceSecondLayerService : IServiceSecondLayerService
    {
        private readonly IRepository<ServiceSecondLayerEntity> _serviceSecondLayerRepository;

        public ServiceSecondLayerService(IRepository<ServiceSecondLayerEntity> serviceSecondLayerRepository)
        {
            _serviceSecondLayerRepository = serviceSecondLayerRepository;
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
            await _serviceSecondLayerRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ServiceSecondLayerEntity>> GetAllAsync()
        {
            return await _serviceSecondLayerRepository.GetAllAsync();
        }
    }
}
