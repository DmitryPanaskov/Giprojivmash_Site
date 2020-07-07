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
    internal class HistrotyPhotoTest : IDisposable
    {
        private GiprojivmashContext _context;
        private bool _disposedValue;

        [SetUp]
        public async Task Initializer()
        {
            _context = new GiprojivmashContext(new DbContextOptionsBuilder().UseSqlServer(IntegrationTestInitializer.GetConnectionString()).Options);
            await IntegrationTestInitializer.ClearHistoryPhoto(_context);
            await IntegrationTestInitializer.SetHistoryPhoto(_context);
        }

        [OneTimeTearDown]
        public async Task ClearData()
        {
            await IntegrationTestInitializer.ClearHistory(_context);
            await IntegrationTestInitializer.ClearHistoryPhoto(_context);
        }

        [Test]
        public async Task CreateHistoryPhoto_WhenCreateHistoryPhoto_ShouldReturnWithNewHistoryPhoto()
        {
            // Arrange
            var historyPhotoService = ServiceInitializer.GetHistoryPhoto(_context);

            // Act
            await historyPhotoService.CreateAsync(new HistoryPhotoEntity
            {
                PhotoName = "Created",
                HistoryId = 1,
            });

            var list = historyPhotoService.GetAll();

            // Assert
            list.Should().BeEquivalentTo(new List<HistoryPhotoEntity>
            {
                new HistoryPhotoEntity
                {
                    Id = 1,
                    HistoryId = 1,
                    PhotoName = "1",
                },
                new HistoryPhotoEntity
                {
                    Id = 2,
                    HistoryId = 1,
                    PhotoName = "2",
                },
                new HistoryPhotoEntity
                {
                    Id = 3,
                    HistoryId = 2,
                    PhotoName = "1",
                },
                new HistoryPhotoEntity
                {
                    Id = 4,
                    PhotoName = "Created",
                    HistoryId = 1,
                },
            });
        }

        [Test]
        public async Task UpdateHistoryPhoto_WhenUpdateHistoryPhoto_ShouldReturnUpdatedHistoryPhoto()
        {
            // Arrange
            var serviceHistoryPhoto = ServiceInitializer.GetHistoryPhoto(_context);

            // Act
            await serviceHistoryPhoto.UpdateAsync(new HistoryPhotoEntity
            {
                Id = 1,
                PhotoName = "Updated",
                HistoryId = 1,
            });

            var list = serviceHistoryPhoto.GetAll();

            // Assert
            list.Should().BeEquivalentTo(new List<HistoryPhotoEntity>
            {
                new HistoryPhotoEntity
                {
                    Id = 1,
                    PhotoName = "Updated",
                    HistoryId = 1,
                },
                new HistoryPhotoEntity
                {
                    Id = 2,
                    PhotoName = "2",
                    HistoryId = 1,
                },
                new HistoryPhotoEntity
                {
                    Id = 3,
                    PhotoName = "1",
                    HistoryId = 2,
                },
            });
        }

        [Test]
        public async Task DeleteHistoryPhoto_WhenDeleteHistoryPhoto_ShouldReturnWithoutDeletedHistoryPhoto()
        {
            // Arrange
            var historyPhotoService = ServiceInitializer.GetHistoryPhoto(_context);

            // Act
            await historyPhotoService.DeleteAsync(1);
            var historyPhotoList = historyPhotoService.GetAll();

            // Assert
            historyPhotoList.Should().BeEquivalentTo(new List<HistoryPhotoEntity>
            {
                new HistoryPhotoEntity
                {
                    Id = 2,
                    HistoryId = 1,
                    PhotoName = "2",
                },
                new HistoryPhotoEntity
                {
                    Id = 3,
                    PhotoName = "1",
                    HistoryId = 2,
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
