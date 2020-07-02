using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Giprojivmash.BLL.Interfaces;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DAL.Interfaces;

namespace Giprojivmash.BLL.Services
{
    public class HistoryPhotoService : IHistoryPhotoService
    {
        private readonly IRepository<HistoryPhotoEntity> _historyPhotoRepository;

        public HistoryPhotoService(
            IRepository<HistoryPhotoEntity> historyPhotoRepository)
        {
            _historyPhotoRepository = historyPhotoRepository;
        }

        public async Task<HistoryPhotoEntity> GetByIdAsync(int id)
        {
           return await _historyPhotoRepository.GetByIdAsync(id);
        }

        public IEnumerable<HistoryPhotoEntity> GetEntities(Func<HistoryPhotoEntity, bool> predicate)
        {
            return _historyPhotoRepository.GetEntities(predicate).ToList();
        }

        public IEnumerable<HistoryPhotoEntity> GetAll()
        {
            return _historyPhotoRepository.GetAll().ToList();
        }

        public async Task CreateAsync(HistoryPhotoEntity entity)
        {
            await _historyPhotoRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(HistoryPhotoEntity entity)
        {
            await _historyPhotoRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _historyPhotoRepository.DeleteAsync(id);
        }
    }
}
