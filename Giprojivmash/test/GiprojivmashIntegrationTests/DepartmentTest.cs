using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Giprojivmash.DAL.Context;
using Giprojivmash.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace GiprojivmashIntegrationTests
{
    [TestFixture]
    internal class DepartmentTest : IDisposable
    {
        private GiprojivmashContext _context;
        private bool _disposedValue;

        [SetUp]
        public async Task Initializer()
        {
            _context = new GiprojivmashContext(new DbContextOptionsBuilder().UseMySQL(IntegrationTestInitializer.GetConnectionString()).Options);
            await IntegrationTestInitializer.ClearDepartment(_context);
            await IntegrationTestInitializer.SetDepartment(_context);
        }

        [OneTimeTearDown]
        public async Task ClearData()
        {
            await IntegrationTestInitializer.ClearDepartment(_context);
        }

        [Test]
        public async Task CreateDepartment_WhenCreateDepartment_ShouldReturnWithNewDepartment()
        {
            // Arrange
            var departmentService = ServiceInitializer.GetDepartment(_context);

            // Act
            await departmentService.CreateAsync(new DepartmentEntity
            {
                Name = "Created",
            });

            var list = departmentService.GetAll();

            // Assert
            list.Should().BeEquivalentTo(new List<DepartmentEntity>
            {
                new DepartmentEntity
                {
                    Id = 1,
                    Name = "1",
                },
                new DepartmentEntity
                {
                    Id = 2,
                    Name = "2",
                },
                new DepartmentEntity
                {
                    Id = 3,
                    Name = "Created",
                },
            });
        }

        [Test]
        public async Task UpdateDepartment_WhenUpdateDepartment_ShouldReturnUpdatedDepartment()
        {
            // Arrange
            var serviceContact = ServiceInitializer.GetDepartment(_context);

            // Act
            await serviceContact.UpdateAsync(new DepartmentEntity
            {
                Id = 1,
                Name = "Updated",
            });

            var list = serviceContact.GetAll();

            // Assert
            list.Should().BeEquivalentTo(new List<DepartmentEntity>
            {
                new DepartmentEntity
                {
                    Id = 1,
                    Name = "Updated",
                },
                new DepartmentEntity
                {
                    Id = 2,
                    Name = "2",
                },
            });
        }

        [Test]
        public async Task DeleteDepartment_WhenDeleteDepartment_ShouldReturnWithoutDeletedDepartmentAndWithoutDepartmentPhoto()
        {
            // Arrange
            var departmentService = ServiceInitializer.GetDepartment(_context);

            // Act
            await departmentService.DeleteAsync(1);
            var departmentList = departmentService.GetAll();

            // Assert
            departmentList.Should().BeEquivalentTo(new List<DepartmentEntity>
            {
                new DepartmentEntity
                {
                    Id = 2,
                    Name = "2",
                },
            });
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
