using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Giprojivmash.BLL.Interfaces;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DAL.Interfaces;

namespace Giprojivmash.BLL.Services
{
    public class PortfolioPhotoService : IPortfolioPhotoService
    {
        private readonly IRepository<PortfolioPhotoEntity> _portfolioPhotoRepository;

        public PortfolioPhotoService(
            IRepository<PortfolioPhotoEntity> portfolioPhotoRepository)
        {
            _portfolioPhotoRepository = portfolioPhotoRepository;
        }

        public async Task<PortfolioPhotoEntity> GetByIdAsync(int id)
        {
           return await _portfolioPhotoRepository.GetByIdAsync(id);
        }

        public IEnumerable<PortfolioPhotoEntity> GetEntities(Func<PortfolioPhotoEntity, bool> predicate)
        {
            return _portfolioPhotoRepository.GetEntities(predicate).ToList();
        }

        public IEnumerable<PortfolioPhotoEntity> GetAll()
        {
            return _portfolioPhotoRepository.GetAll().ToList();
        }

        public async Task CreateAsync(PortfolioPhotoEntity entity)
        {
            await _portfolioPhotoRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(PortfolioPhotoEntity entity)
        {
            await _portfolioPhotoRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _portfolioPhotoRepository.DeleteAsync(id);
        }
    }
}
