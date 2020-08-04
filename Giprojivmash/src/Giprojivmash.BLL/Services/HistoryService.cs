using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Giprojivmash.BLL.Interfaces;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DAL.Interfaces;

namespace Giprojivmash.BLL.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly IRepository<HistoryEntity> _historyRepository;
        private readonly IRepository<HistoryPhotoEntity> _historyPhotoRepository;

        public HistoryService(
            IRepository<HistoryEntity> historyRepository,
            IRepository<HistoryPhotoEntity> historyPhotoRepository)
        {
            _historyRepository = historyRepository;
            _historyPhotoRepository = historyPhotoRepository;
        }

        public async Task<HistoryEntity> GetByIdAsync(int id)
        {
           return await _historyRepository.GetByIdAsync(id);
        }

        public IEnumerable<HistoryEntity> GetEntities(Func<HistoryEntity, bool> predicate)
        {
            return _historyRepository.GetEntities(predicate).ToList();
        }

        public IEnumerable<HistoryEntity> GetAll()
        {
            return _historyRepository.GetAll().ToList();
        }

        public async Task CreateAsync(HistoryEntity entity)
        {
            await _historyRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(HistoryEntity entity)
        {
            await _historyRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteHistoryPhoto(id);
            await _historyRepository.DeleteAsync(id);
        }

        private async Task DeleteHistoryPhoto(int id)
        {
            var list = _historyPhotoRepository.GetEntities(m => m.HistoryId == id).ToList();
            await _historyPhotoRepository.DeleteRangeAsync(list);
        }
    }
}
