using System.Collections.Generic;
using System.Threading.Tasks;
using Giprojivmash.BLL.Interfaces;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DAL.Interfaces;

namespace Giprojivmash.BLL.Services
{
    public class ServiceFirstLayerService : IServiceFirstLayerService
    {
        private readonly IRepository<ServiceFirstLayerEntity> _serviceFirstLayerRepository;

        public ServiceFirstLayerService(IRepository<ServiceFirstLayerEntity> serviceFirstLayerRepository)
        {
            _serviceFirstLayerRepository = serviceFirstLayerRepository;
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
            await _serviceFirstLayerRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ServiceFirstLayerEntity>> GetAllAsync()
        {
            return await _serviceFirstLayerRepository.GetAllAsync();
        }
    }
}
