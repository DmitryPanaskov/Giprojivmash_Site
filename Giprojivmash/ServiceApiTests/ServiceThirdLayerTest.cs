using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Giprojivmash.DAL.Context;
using Giprojivmash.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace ServiceApiTests
{
    [TestFixture]
    internal class ServiceThirdLayerTest : IDisposable
    {
        private GiprojivmashContext _context;
        private bool _disposedValue;

        [SetUp]
        public async Task Initializer()
        {
            _context = new GiprojivmashContext(new DbContextOptionsBuilder().UseMySQL(IntegrationTestInitializer.GetConnectionString()).Options);
            await IntegrationTestInitializer.ClearServiceThirdLayer(_context);
            await IntegrationTestInitializer.SetServiceThirdLayer(_context);
        }

        [OneTimeTearDown]
        public async Task ClearData()
        {
            await IntegrationTestInitializer.ClearServiceThirdLayer(_context);
        }

        [Test]
        public async Task CreateServiceThirdLayer_WhenCreateServiceThirdLayer_ShouldReturnWithNewServiceThirdLayer()
        {
            // Arrange
            var serviceThirdLayerService = ServiceInitializer.GetServiceThirdLayerService(_context);

            // Act
            await serviceThirdLayerService.CreateAsync(new ServiceThirdLayerEntity
            {
                ServiceSecondLayerId = 1,
                Description = "Created serviceThirdLayerService",
            });

            var list = serviceThirdLayerService.GetAll();

            // Assert
            list.Should().BeEquivalentTo(new List<ServiceThirdLayerEntity>
                {
                    new ServiceThirdLayerEntity
                    {
                        Id = 1,
                        ServiceSecondLayerId = 1,
                        Description = "1",
                    },
                    new ServiceThirdLayerEntity
                    {
                        Id = 2,
                        ServiceSecondLayerId = 1,
                        Description = "2",
                    },
                    new ServiceThirdLayerEntity
                    {
                        Id = 3,
                        ServiceSecondLayerId = 1,
                        Description = "3",
                    },
                    new ServiceThirdLayerEntity
                    {
                        Id = 4,
                        ServiceSecondLayerId = 2,
                        Description = "1",
                    },
                    new ServiceThirdLayerEntity
                    {
                        Id = 5,
                        ServiceSecondLayerId = 3,
                        Description = "1",
                    },
                    new ServiceThirdLayerEntity
                    {
                        Id = 6,
                        ServiceSecondLayerId = 1,
                        Description = "Created serviceThirdLayerService",
                    },
                });
        }

        [Test]
        public async Task UpdateServiceThirdLayer_WhenUpdateServiceThirdLayer_ShouldReturnUpdatedServiceThirdLayer()
        {
            // Arrange
            var serviceThirdLayerService = ServiceInitializer.GetServiceThirdLayerService(_context);

            // Act
            await serviceThirdLayerService.UpdateAsync(new ServiceThirdLayerEntity
            {
                Id = 1,
                ServiceSecondLayerId = 1,
                Description = "Updated serviceThirdLayerService",
            });

            var list = serviceThirdLayerService.GetAll();

            // Assert
            list.Should().BeEquivalentTo(new List<ServiceThirdLayerEntity>
                {
                    new ServiceThirdLayerEntity
                    {
                        Id = 1,
                        ServiceSecondLayerId = 1,
                        Description = "Updated serviceThirdLayerService",
                    },
                    new ServiceThirdLayerEntity
                    {
                        Id = 2,
                        ServiceSecondLayerId = 1,
                        Description = "2",
                    },
                    new ServiceThirdLayerEntity
                    {
                        Id = 3,
                        ServiceSecondLayerId = 1,
                        Description = "3",
                    },
                    new ServiceThirdLayerEntity
                    {
                        Id = 4,
                        ServiceSecondLayerId = 2,
                        Description = "1",
                    },
                    new ServiceThirdLayerEntity
                    {
                        Id = 5,
                        ServiceSecondLayerId = 3,
                        Description = "1",
                    },
                });
        }

        [Test]
        public async Task DeleteServiceThirdLayer_WhenDeleteServiceThirdLayer_ShouldReturnWithoutDeletedServiceThirdLayer()
        {
            // Arrange
            var serviceThirdLayerService = ServiceInitializer.GetServiceThirdLayerService(_context);

            // Act
            await serviceThirdLayerService.DeleteAsync(1);
            var listThird = serviceThirdLayerService.GetAll();

            // Assert
            listThird.Should().BeEquivalentTo(new List<ServiceThirdLayerEntity>
                {
                    new ServiceThirdLayerEntity
                    {
                        Id = 2,
                        ServiceSecondLayerId = 1,
                        Description = "2",
                    },
                    new ServiceThirdLayerEntity
                    {
                        Id = 3,
                        ServiceSecondLayerId = 1,
                        Description = "3",
                    },
                    new ServiceThirdLayerEntity
                    {
                        Id = 4,
                        ServiceSecondLayerId = 2,
                        Description = "1",
                    },
                    new ServiceThirdLayerEntity
                    {
                        Id = 5,
                        ServiceSecondLayerId = 3,
                        Description = "1",
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
