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
            _context = new GiprojivmashContext(new DbContextOptionsBuilder().UseSqlServer(IntegrationTestInitializer.GetConnectionString()).Options);
            await IntegrationTestInitializer.ClearServiceFirstLayer(_context);
            await IntegrationTestInitializer.SetServiceFirstLayer(_context);
            await IntegrationTestInitializer.ClearServiceSecondLayer(_context);
            await IntegrationTestInitializer.SetServiceSecondLayer(_context);
            await IntegrationTestInitializer.ClearServiceThirdLayer(_context);
            await IntegrationTestInitializer.SetServiceThirdLayer(_context);
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

            var list = serviceFirstLayerService.GetAll();

            // Assert
            list.Should().BeEquivalentTo(new List<ServiceFirstLayerEntity>
            {
                new ServiceFirstLayerEntity
                {
                    Id = 1,
                    Description = "1",
                },
                new ServiceFirstLayerEntity
                {
                    Id = 2,
                    Description = "2",
                },
                new ServiceFirstLayerEntity
                {
                    Id = 3,
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

            var list = serviceFirstLayerService.GetAll();

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
        public async Task DeleteServiceFirstLayer_WhenDeleteServiceFirstLayer_ShouldReturnWithoutDeletedServiceFirstLayerAndWithoutServiceSecondLayerAndWithoutServiceThirdLayer()
        {
            // Arrange
            var serviceFirstLayerService = ServiceInitializer.GetServiceFirstLayerService(_context);
            var serviceSecondLayerService = ServiceInitializer.GetServiceSecondLayerService(_context);
            var serviceThirdLayerService = ServiceInitializer.GetServiceThirdLayerService(_context);

            // Act
            await serviceFirstLayerService.DeleteAsync(1);
            var listFirst = serviceFirstLayerService.GetAll();
            var listSecond = serviceSecondLayerService.GetAll();
            var listThird = serviceThirdLayerService.GetAll();

            // Assert
            listFirst.Should().BeEquivalentTo(new List<ServiceFirstLayerEntity>
            {
                new ServiceFirstLayerEntity
                {
                    Id = 2,
                    Description = "2",
                },
            });
            listSecond.Should().BeEquivalentTo(new List<ServiceSecondLayerEntity>
            {
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
