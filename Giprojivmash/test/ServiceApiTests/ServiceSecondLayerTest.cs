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
    internal class ServiceSecondLayerTest : IDisposable
    {
        private GiprojivmashContext _context;
        private bool _disposedValue;

        [SetUp]
        public async Task Initializer()
        {
            _context = new GiprojivmashContext(new DbContextOptionsBuilder().UseMySQL(IntegrationTestInitializer.GetConnectionString()).Options);
            await IntegrationTestInitializer.ClearServiceSecondLayer(_context);
            await IntegrationTestInitializer.SetServiceSecondLayer(_context);
            await IntegrationTestInitializer.ClearServiceThirdLayer(_context);
            await IntegrationTestInitializer.SetServiceThirdLayer(_context);
        }

        [OneTimeTearDown]
        public async Task ClearData()
        {
            await IntegrationTestInitializer.ClearServiceSecondLayer(_context);
            await IntegrationTestInitializer.ClearServiceThirdLayer(_context);
        }

        [Test]
        public async Task CreateServiceSecondLayer_WhenCreateServiceSecondLayer_ShouldReturnWithNewServiceSecondLayer()
        {
            // Arrange
            var serviceSecondLayerService = ServiceInitializer.GetServiceSecondLayerService(_context);

            // Act
            await serviceSecondLayerService.CreateAsync(new ServiceSecondLayerEntity
            {
                ServiceFirstLayerId = 1,
                Description = "Created serviceSecondLayerService",
            });

            var list = serviceSecondLayerService.GetAll();

            // Assert
            list.Should().BeEquivalentTo(new List<ServiceSecondLayerEntity>
                {
                    new ServiceSecondLayerEntity
                    {
                        Id = 1,
                        ServiceFirstLayerId = 1,
                        Description = "1",
                    },
                    new ServiceSecondLayerEntity
                    {
                        Id = 2,
                        ServiceFirstLayerId = 1,
                        Description = "2",
                    },
                    new ServiceSecondLayerEntity
                    {
                        Id = 3,
                        ServiceFirstLayerId = 2,
                        Description = "3",
                    },
                    new ServiceSecondLayerEntity
                    {
                        Id = 4,
                        ServiceFirstLayerId = 1,
                        Description = "Created serviceSecondLayerService",
                    },
                });
        }

        [Test]
        public async Task UpdateServiceSecondLayer_WhenUpdateServiceSecondLayer_ShouldReturnUpdatedServiceSecondLayer()
        {
            // Arrange
            var serviceSecondLayerService = ServiceInitializer.GetServiceSecondLayerService(_context);

            // Act
            await serviceSecondLayerService.UpdateAsync(new ServiceSecondLayerEntity { Id = 1, ServiceFirstLayerId = 1, Description = "Updated serviceSecondLayerService" });

            var list = serviceSecondLayerService.GetAll();

            // Assert
            list.Should().BeEquivalentTo(new List<ServiceSecondLayerEntity>
                {
                    new ServiceSecondLayerEntity
                    {
                        Id = 1,
                        ServiceFirstLayerId = 1,
                        Description = "Updated serviceSecondLayerService",
                    },
                    new ServiceSecondLayerEntity
                    {
                        Id = 2,
                        ServiceFirstLayerId = 1,
                        Description = "2",
                    },
                    new ServiceSecondLayerEntity
                    {
                        Id = 3,
                        ServiceFirstLayerId = 2,
                        Description = "3",
                    },
                });
        }

        [Test]
        public async Task DeleteServiceSecondLayer_WhenDeleteServiceSecondLayer_ShouldReturnWithoutDeletedServiceSecondLayer()
        {
            // Arrange
            var serviceSecondLayerService = ServiceInitializer.GetServiceSecondLayerService(_context);
            var serviceThirdLayerService = ServiceInitializer.GetServiceThirdLayerService(_context);

            // Act
            await serviceSecondLayerService.DeleteAsync(1);
            var listSecond = serviceSecondLayerService.GetAll();
            var listThird = serviceThirdLayerService.GetAll();

            // Assert
            listSecond.Should().BeEquivalentTo(new List<ServiceSecondLayerEntity>
                {
                    new ServiceSecondLayerEntity
                    {
                        Id = 2,
                        ServiceFirstLayerId = 1,
                        Description = "2",
                    },
                    new ServiceSecondLayerEntity
                    {
                        Id = 3,
                        ServiceFirstLayerId = 2,
                        Description = "3",
                    },
                });
            listThird.Should().BeEquivalentTo(new List<ServiceThirdLayerEntity>
                {
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
