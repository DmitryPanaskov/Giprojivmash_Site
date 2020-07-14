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
    internal class PortfolioPhotoTest : IDisposable
    {
        private GiprojivmashContext _context;
        private bool _disposedValue;

        [SetUp]
        public async Task Initializer()
        {
            _context = new GiprojivmashContext(new DbContextOptionsBuilder().UseMySQL(IntegrationTestInitializer.GetConnectionString()).Options);
            await IntegrationTestInitializer.ClearPortfolioPhoto(_context);
            await IntegrationTestInitializer.SetPortfolioPhoto(_context);
        }

        [OneTimeTearDown]
        public async Task ClearData()
        {
            await IntegrationTestInitializer.ClearPortfolioPhoto(_context);
        }

        [Test]
        public async Task CreatePortfolioPhoto_WhenCreatePortfolioPhoto_ShouldReturnWithNewPortfolioPhoto()
        {
            // Arrange
            var portfolioPhotoService = ServiceInitializer.GetPortfolioPhoto(_context);

            // Act
            await portfolioPhotoService.CreateAsync(new PortfolioPhotoEntity
            {
                PhotoName = "Created",
                PortfolioId = 1,
            });

            var list = portfolioPhotoService.GetAll();

            // Assert
            list.Should().BeEquivalentTo(new List<PortfolioPhotoEntity>
            {
                new PortfolioPhotoEntity
                {
                    Id = 1,
                    PortfolioId = 1,
                    PhotoName = "1",
                },
                new PortfolioPhotoEntity
                {
                    Id = 2,
                    PortfolioId = 1,
                    PhotoName = "2",
                },
                new PortfolioPhotoEntity
                {
                    Id = 3,
                    PortfolioId = 2,
                    PhotoName = "1",
                },
                new PortfolioPhotoEntity
                {
                    Id = 4,
                    PhotoName = "Created",
                    PortfolioId = 1,
                },
            });
        }

        [Test]
        public async Task UpdatePortfolioPhoto_WhenUpdatePortfolioPhoto_ShouldReturnUpdatedPortfolioPhoto()
        {
            // Arrange
            var servicePortfolioPhoto = ServiceInitializer.GetPortfolioPhoto(_context);

            // Act
            await servicePortfolioPhoto.UpdateAsync(new PortfolioPhotoEntity
            {
                Id = 1,
                PhotoName = "Updated",
                PortfolioId = 1,
            });

            var list = servicePortfolioPhoto.GetAll();

            // Assert
            list.Should().BeEquivalentTo(new List<PortfolioPhotoEntity>
            {
                new PortfolioPhotoEntity
                {
                    Id = 1,
                    PhotoName = "Updated",
                    PortfolioId = 1,
                },
                new PortfolioPhotoEntity
                {
                    Id = 2,
                    PhotoName = "2",
                    PortfolioId = 1,
                },
                new PortfolioPhotoEntity
                {
                    Id = 3,
                    PhotoName = "1",
                    PortfolioId = 2,
                },
            });
        }

        [Test]
        public async Task DeletePortfolioPhoto_WhenDeletePortfolioPhoto_ShouldReturnWithoutDeletedPortfolioPhoto()
        {
            // Arrange
            var portfolioPhotoService = ServiceInitializer.GetPortfolioPhoto(_context);

            // Act
            await portfolioPhotoService.DeleteAsync(1);
            var portfolioPhotoList = portfolioPhotoService.GetAll();

            // Assert
            portfolioPhotoList.Should().BeEquivalentTo(new List<PortfolioPhotoEntity>
            {
                new PortfolioPhotoEntity
                {
                    Id = 2,
                    PortfolioId = 1,
                    PhotoName = "2",
                },
                new PortfolioPhotoEntity
                {
                    Id = 3,
                    PhotoName = "1",
                    PortfolioId = 2,
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
