using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Giprojivmash.BLL.Interfaces;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DAL.Interfaces;

namespace Giprojivmash.BLL.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<DepartmentEntity> _departmentRepository;

        public DepartmentService(IRepository<DepartmentEntity> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<DepartmentEntity> GetByIdAsync(int id)
        {
            return await _departmentRepository.GetByIdAsync(id);
        }

        public IEnumerable<DepartmentEntity> GetEntities(Func<DepartmentEntity, bool> predicate)
        {
            return _departmentRepository.GetEntities(predicate).ToList();
        }

        public IEnumerable<DepartmentEntity> GetAll()
        {
            return _departmentRepository.GetAll().ToList();
        }

        public async Task CreateAsync(DepartmentEntity entity)
        {
            await _departmentRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(DepartmentEntity entity)
        {
            await _departmentRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _departmentRepository.DeleteAsync(id);
        }
    }
}
