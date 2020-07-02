using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Giprojivmash.DAL.Context;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Giprojivmash.DAL.Repositories
{
    public class GenericRepository<T> : IRepository<T>
        where T : BaseEntity
    {
        private readonly GiprojivmashContext _context;

        public GenericRepository(GiprojivmashContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
           return await _context.Set<T>().FirstAsync(m=>m.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            var entry = await _context.Set<T>().FirstAsync(e => e.Id == entity.Id);
            _context.Entry(entry).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FirstAsync(m => m.Id == id);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<T> GetEntities(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            _context.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }
    }
}
