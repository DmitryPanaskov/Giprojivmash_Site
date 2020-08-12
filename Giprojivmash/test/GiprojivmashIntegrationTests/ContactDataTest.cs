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
    internal class ContactDataTest : IDisposable
    {
        private GiprojivmashContext _context;
        private bool _disposedValue;

        [SetUp]
        public async Task Initializer()
        {
            _context = new GiprojivmashContext(new DbContextOptionsBuilder()
                .UseMySQL(IntegrationTestInitializer.GetConnectionString()).Options);
            await IntegrationTestInitializer.ClearContactData(_context);
            await IntegrationTestInitializer.SetContactData(_context);
        }

        [OneTimeTearDown]
        public async Task ClearData()
        {
            await IntegrationTestInitializer.ClearContactData(_context);
        }

        [Test]
        public async Task CreateContactData_WhenCreateContactData_ShouldReturnWithNewContactData()
        {
            // Arrange
            var contactDataService = ServiceInitializer.GetContactData(_context);

            // Act
            await contactDataService.CreateAsync(new ContactDataEntity
            {
                ContactId = 1,
                Data = "Created",
                SubData = "Created",
                Type = 1,
            });

            var list = contactDataService.GetAll();

            // Assert
            list.Should().BeEquivalentTo(new List<ContactDataEntity>
            {
                new ContactDataEntity
                {
                    Id = 1,
                    ContactId = 1,
                    Data = "Created",
                    SubData = "Created",
                    Type = 1,
                },
                new ContactDataEntity
                {
                    Id = 2,
                    ContactId = 1,
                    Data = "Created",
                    SubData = "Created",
                    Type = 1,
                },
                new ContactDataEntity
                {
                    Id = 3,
                    ContactId = 2,
                    Data = "Created",
                    SubData = "Created",
                    Type = 1,
                },
                new ContactDataEntity
                {
                    Id = 4,
                    ContactId = 1,
                    Data = "Created",
                    SubData = "Created",
                    Type = 1,
                },
            });
        }

        [Test]
        public async Task UpdateContactData_WhenUpdateContactData_ShouldReturnUpdatedContactData()
        {
            // Arrange
            var servicecontactData = ServiceInitializer.GetContactData(_context);

            // Act
            await servicecontactData.UpdateAsync(new ContactDataEntity
            {
                Id = 1,
                ContactId = 1,
                Data = "Updated",
                SubData = "Updated",
                Type = 1,
            });

            var list = servicecontactData.GetAll();

            // Assert
            list.Should().BeEquivalentTo(new List<ContactDataEntity>
            {
                new ContactDataEntity
                {
                    Id = 1,
                    ContactId = 1,
                    Data = "Updated",
                    SubData = "Updated",
                    Type = 1,
                },
                new ContactDataEntity
                {
                    Id = 2,
                    ContactId = 1,
                    Data = "2",
                    SubData = "2",
                    Type = 1,
                },
                new ContactDataEntity
                {
                    Id = 3,
                    ContactId = 2,
                    Data = "1",
                    SubData = "1",
                    Type = 1,
                },
            });
        }

        [Test]
        public async Task DeletecontactData_WhenDeletecontactData_ShouldReturnWithoutDeletedcontactData()
        {
            // Arrange
            var contactDataService = ServiceInitializer.GetContactData(_context);

            // Act
            await contactDataService.DeleteAsync(1);
            var contactDataList = contactDataService.GetAll();

            // Assert
            contactDataList.Should().BeEquivalentTo(new List<ContactDataEntity>
            {
                new ContactDataEntity
                {
                    Id = 2,
                    ContactId = 1,
                    Data = "2",
                    SubData = "2",
                    Type = 1,
                },
                new ContactDataEntity
                {
                    Id = 3,
                    ContactId = 2,
                    Data = "1",
                    SubData = "1",
                    Type = 1,
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