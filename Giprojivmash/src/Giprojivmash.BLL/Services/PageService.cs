using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Giprojivmash.BLL.Interfaces;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DAL.Interfaces;

namespace Giprojivmash.BLL.Services
{
    public class PageService : IPageService
    {
        private readonly IRepository<PageEntity> _pageRepository;

        public PageService(IRepository<PageEntity> pageRepository)
        {
            _pageRepository = pageRepository;
        }

        public async Task<PageEntity> GetByIdAsync(int id)
        {
            return await _pageRepository.GetByIdAsync(id);
        }

        public IEnumerable<PageEntity> GetEntities(Func<PageEntity, bool> predicate)
        {
            return _pageRepository.GetEntities(predicate).ToList();
        }

        public IEnumerable<PageEntity> GetAll()
        {
            return _pageRepository.GetAll().ToList();
        }

        public async Task CreateAsync(PageEntity entity)
        {
            await _pageRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(PageEntity entity)
        {
            await _pageRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _pageRepository.DeleteAsync(id);
        }
    }
}
