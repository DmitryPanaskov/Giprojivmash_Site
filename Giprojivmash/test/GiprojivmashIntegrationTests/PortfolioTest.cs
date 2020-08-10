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
    internal class PortfolioTest : IDisposable
    {
        private GiprojivmashContext _context;
        private bool _disposedValue;

        [SetUp]
        public async Task Initializer()
        {
            _context = new GiprojivmashContext(new DbContextOptionsBuilder().UseMySQL(IntegrationTestInitializer.GetConnectionString()).Options);
            await IntegrationTestInitializer.ClearPortfolio(_context);
            await IntegrationTestInitializer.SetPortfolio(_context);
            await IntegrationTestInitializer.ClearPortfolioPhoto(_context);
            await IntegrationTestInitializer.SetPortfolioPhoto(_context);
        }

        [OneTimeTearDown]
        public async Task ClearData()
        {
            await IntegrationTestInitializer.ClearPortfolio(_context);
            await IntegrationTestInitializer.ClearPortfolioPhoto(_context);
        }

        [Test]
        public async Task CreatePortfolio_WhenCreatePortfolio_ShouldReturnWithNewPortfolio()
        {
            // Arrange
            var portfolioService = ServiceInitializer.GetPortfolio(_context);

            // Act
            await portfolioService.CreateAsync(new PortfolioEntity
            {
                Description = "Created",
            });

            var list = portfolioService.GetAll();

            // Assert
            list.Should().BeEquivalentTo(new List<PortfolioEntity>
            {
                new PortfolioEntity
                {
                    Id = 1,
                    Description = "1",
                },
                new PortfolioEntity
                {
                    Id = 2,
                    Description = "2",
                },
                new PortfolioEntity
                {
                    Id = 3,
                    Description = "Created",
                },
            });
        }

        [Test]
        public async Task UpdatePortfolio_WhenUpdatePortfolio_ShouldReturnUpdatedPortfolio()
        {
            // Arrange
            var serviceContact = ServiceInitializer.GetPortfolio(_context);

            // Act
            await serviceContact.UpdateAsync(new PortfolioEntity
            {
                Id = 1,
                Description = "Updated",
            });

            var list = serviceContact.GetAll();

            // Assert
            list.Should().BeEquivalentTo(new List<PortfolioEntity>
            {
                new PortfolioEntity
                {
                    Id = 1,
                    Description = "Updated",
                },
                new PortfolioEntity
                {
                    Id = 2,
                    Description = "2",
                },
            });
        }

        [Test]
        public async Task DeletePortfolio_WhenDeletePortfolio_ShouldReturnWithoutDeletedPortfolioAndWithoutPortfolioPhoto()
        {
            // Arrange
            var portfolioService = ServiceInitializer.GetPortfolio(_context);
            var portfolioPhotoService = ServiceInitializer.GetPortfolioPhoto(_context);

            // Act
            await portfolioService.DeleteAsync(1);
            var portfolioList = portfolioService.GetAll();
            var portfolioPhotoList = portfolioPhotoService.GetAll();

            // Assert
            portfolioList.Should().BeEquivalentTo(new List<PortfolioEntity>
            {
                new PortfolioEntity
                {
                    Id = 2,
                    Description = "2",
                },
            });
            portfolioPhotoList.Should().BeEquivalentTo(new List<PortfolioPhotoEntity>
            {
                new PortfolioPhotoEntity
                {
                    Id = 3,
                    PortfolioId = 2,
                    PhotoName = "1",
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
