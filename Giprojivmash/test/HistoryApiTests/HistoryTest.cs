using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Giprojivmash.DAL.Context;
using Giprojivmash.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace HistoryApiTests
{
    [TestFixture]
    internal class HistoryTest : IDisposable
    {
        private GiprojivmashContext _context;
        private bool _disposedValue;

        [SetUp]
        public async Task Initializer()
        {
            _context = new GiprojivmashContext(new DbContextOptionsBuilder().UseMySQL(IntegrationTestInitializer.GetConnectionString()).Options);
            await IntegrationTestInitializer.ClearHistory(_context);
            await IntegrationTestInitializer.SetHistory(_context);
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
        public async Task CreateHistory_WhenCreateHistory_ShouldReturnWithNewHistory()
        {
            // Arrange
            var contactService = ServiceInitializer.GetHistory(_context);

            // Act
            await contactService.CreateAsync(new HistoryEntity
            {
                Description = "Created",
            });

            var list = contactService.GetAll();

            // Assert
            list.Should().BeEquivalentTo(new List<HistoryEntity>
            {
                new HistoryEntity
                {
                    Id = 1,
                    Description = "1",
                },
                new HistoryEntity
                {
                    Id = 2,
                    Description = "2",
                },
                new HistoryEntity
                {
                    Id = 3,
                    Description = "Created",
                },
            });
        }

        [Test]
        public async Task UpdateHistory_WhenUpdateHistory_ShouldReturnUpdatedHistory()
        {
            // Arrange
            var serviceContact = ServiceInitializer.GetHistory(_context);

            // Act
            await serviceContact.UpdateAsync(new HistoryEntity
            {
                Id = 1,
                Description = "Updated",
            });

            var list = serviceContact.GetAll();

            // Assert
            list.Should().BeEquivalentTo(new List<HistoryEntity>
            {
                new HistoryEntity
                {
                    Id = 1,
                    Description = "Updated",
                },
                new HistoryEntity
                {
                    Id = 2,
                    Description = "2",
                },
            });
        }

        [Test]
        public async Task DeleteHistory_WhenDeleteHistory_ShouldReturnWithoutDeletedHistoryAndWithoutHistoryPhoto()
        {
            // Arrange
            var historyService = ServiceInitializer.GetHistory(_context);
            var historyPhotoService = ServiceInitializer.GetHistoryPhoto(_context);

            // Act
            await historyService.DeleteAsync(1);
            var historyList = historyService.GetAll();
            var historyPhotoList = historyPhotoService.GetAll();

            // Assert
            historyList.Should().BeEquivalentTo(new List<HistoryEntity>
            {
                new HistoryEntity
                {
                    Id = 2,
                    Description = "2",
                },
            });
            historyPhotoList.Should().BeEquivalentTo(new List<HistoryPhotoEntity>
            {
                new HistoryPhotoEntity
                {
                    Id = 3,
                    HistoryId = 2,
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
