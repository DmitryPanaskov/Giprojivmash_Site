using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Giprojivmash.DAL.Context;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DataModels.Enums;
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
            await IntegrationTestInitializer.ClearContact(_context);
            await IntegrationTestInitializer.SetContactData(_context);
            await IntegrationTestInitializer.SetContact(_context);
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
                ContactDataType = ContactDataType.WorkTelephone,
            });

            var list = contactDataService.GetAll();

            // Assert
            list.Should().BeEquivalentTo(new List<ContactDataEntity>
            {
                new ContactDataEntity
                {
                    Id = 1,
                    ContactId = 1,
                    Data = "1",
                    SubData = "1",
                    ContactDataType = ContactDataType.WorkTelephone,
                },
                new ContactDataEntity
                {
                    Id = 2,
                    ContactId = 1,
                    Data = "2",
                    SubData = "2",
                    ContactDataType = ContactDataType.WorkTelephone,
                },
                new ContactDataEntity
                {
                    Id = 3,
                    ContactId = 2,
                    Data = "1",
                    SubData = "1",
                    ContactDataType = ContactDataType.WorkTelephone,
                },
                new ContactDataEntity
                {
                    Id = 4,
                    ContactId = 1,
                    Data = "Created",
                    SubData = "Created",
                    ContactDataType = ContactDataType.WorkTelephone,
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
                ContactDataType = ContactDataType.WorkTelephone,
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
                    ContactDataType = ContactDataType.WorkTelephone,
                },
                new ContactDataEntity
                {
                    Id = 2,
                    ContactId = 1,
                    Data = "2",
                    SubData = "2",
                    ContactDataType = ContactDataType.WorkTelephone,
                },
                new ContactDataEntity
                {
                    Id = 3,
                    ContactId = 2,
                    Data = "1",
                    SubData = "1",
                    ContactDataType = ContactDataType.WorkTelephone,
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
                    ContactDataType = ContactDataType.WorkTelephone,
                },
                new ContactDataEntity
                {
                    Id = 3,
                    ContactId = 2,
                    Data = "1",
                    SubData = "1",
                    ContactDataType = ContactDataType.WorkTelephone,
                },
            });
        }

        [Test]
        public void GetContactDataByPositionType_WhenGetContactDataByPositionType_ShouldReturnContactDataByPositionType()
        {
            // Arrange
            var contactDataService = ServiceInitializer.GetContactData(_context);

            // Act
            var list = contactDataService.GetContactDataListByPositionType(PositionType.Manager);

            // Assert
            list.Should().BeEquivalentTo(new List<ContactDataEntity>
            {
                new ContactDataEntity
                {
                    Id = 1,
                    ContactId = 1,
                    Data = "1",
                    SubData = "1",
                    ContactDataType = ContactDataType.WorkTelephone,
                },
                new ContactDataEntity
                {
                    Id = 2,
                    ContactId = 1,
                    Data = "2",
                    SubData = "2",
                    ContactDataType = ContactDataType.WorkTelephone,
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