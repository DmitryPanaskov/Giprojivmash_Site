using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Giprojivmash.DAL.Context;
using Giprojivmash.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace GiprojivmahsIntegrationTests
{
    [TestFixture]
    internal class ServiceFirstLayerTest : IDisposable
    {
        private GiprojivmashContext _context;
        private bool _disposedValue;

        [SetUp]
        public async Task Initializer()
        {
            _context = new GiprojivmashContext(new DbContextOptionsBuilder().UseSqlServer(ServiceInitializer.GetConnectionString()).Options);

            await _context.Database.ExecuteSqlRawAsync(@"DELETE FROM dbo.[ServiceFirstLayer]");
            await IntegrationTestInitializer.SetServiceFirstLayer(_context);
        }

        [OneTimeTearDown]
        public async Task RestoreDataBase()
        {
            await IntegrationTestInitializer.DropDataBase(_context);
        }

        [Test]
        public async Task CreateServiceFirstLayer_WhenCreateServiceFirstLayer_ShouldReturnWithNewServiceFirstLayer()
        {
            // Arrange
            var serviceFirstLayerService = ServiceInitializer.GetServiceFirstLayerService(_context);

            // Act
            await serviceFirstLayerService.CreateAsync(new ServiceFirstLayerEntity
            {
                Description = "Created serviceFirstLayerService",
            });

            var list = await serviceFirstLayerService.GetAllAsync();

            // Assert
            list.Should().BeEquivalentTo(new List<ServiceFirstLayerEntity>
                {
                    new ServiceFirstLayerEntity
                    {
                        Description = "1",
                    },
                    new ServiceFirstLayerEntity
                    {
                        Description = "2",
                    },
                    new ServiceFirstLayerEntity
                    {
                        Description = "Created serviceFirstLayerService",
                    },
                });
        }

        [Test]
        public async Task UpdateServiceFirstLayer_WhenUpdateServiceFirstLayer_ShouldReturnUpdatedServiceFirstLayer()
        {
            // Arrange
            var serviceFirstLayerService = ServiceInitializer.GetServiceFirstLayerService(_context);

            // Act
            await serviceFirstLayerService.UpdateAsync(new ServiceFirstLayerEntity { Id = 1, Description = "Updated serviceFirstLayerService" });

            var list = await serviceFirstLayerService.GetAllAsync();

            // Assert
            list.Should().BeEquivalentTo(new List<ServiceFirstLayerEntity>
                {
                    new ServiceFirstLayerEntity
                    {
                        Id = 1,
                        Description = "Updated serviceFirstLayerService",
                    },
                    new ServiceFirstLayerEntity
                    {
                        Id = 2,
                        Description = "2",
                    },
                });
        }

        [Test]
        public async Task DeleteServiceFirstLayer_WhenDeleteServiceFirstLayer_ShouldReturnWithoutDeletedServiceFirstLayer()
        {
            // Arrange
            var serviceFirstLayerService = ServiceInitializer.GetServiceFirstLayerService(_context);

            // Act
            await serviceFirstLayerService.DeleteAsync(1);
            var list = await serviceFirstLayerService.GetAllAsync();

            // Assert
            list.Should().BeEquivalentTo(new List<ServiceFirstLayerEntity>
                {
                    new ServiceFirstLayerEntity
                    {
                        Id = 2,
                        Description = "2",
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
