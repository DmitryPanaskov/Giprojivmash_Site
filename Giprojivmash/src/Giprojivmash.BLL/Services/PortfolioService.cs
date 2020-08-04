using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Giprojivmash.BLL.Interfaces;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DAL.Interfaces;

namespace Giprojivmash.BLL.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IRepository<PortfolioEntity> _portfolioRepository;
        private readonly IRepository<PortfolioPhotoEntity> _portfolioPhotoRepository;

        public PortfolioService(
            IRepository<PortfolioEntity> portfolioRepository,
            IRepository<PortfolioPhotoEntity> portfolioPhotoRepository)
        {
            _portfolioRepository = portfolioRepository;
            _portfolioPhotoRepository = portfolioPhotoRepository;
        }

        public async Task<PortfolioEntity> GetByIdAsync(int id)
        {
           return await _portfolioRepository.GetByIdAsync(id);
        }

        public IEnumerable<PortfolioEntity> GetEntities(Func<PortfolioEntity, bool> predicate)
        {
            return _portfolioRepository.GetEntities(predicate).ToList();
        }

        public IEnumerable<PortfolioEntity> GetAll()
        {
            return _portfolioRepository.GetAll().ToList();
        }

        public async Task CreateAsync(PortfolioEntity entity)
        {
            await _portfolioRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(PortfolioEntity entity)
        {
            await _portfolioRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await DeletePortfolioPhoto(id);
            await _portfolioRepository.DeleteAsync(id);
        }

        private async Task DeletePortfolioPhoto(int id)
        {
            var list = _portfolioPhotoRepository.GetEntities(m => m.PortfolioId == id).ToList();
            await _portfolioPhotoRepository.DeleteRangeAsync(list);
        }
    }
}
