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
    internal class ContactTest : IDisposable
    {
        private GiprojivmashContext _context;
        private bool _disposedValue;

        [SetUp]
        public async Task Initializer()
        {
            _context = new GiprojivmashContext(new DbContextOptionsBuilder().UseMySQL(IntegrationTestInitializer.GetConnectionString()).Options);
            await IntegrationTestInitializer.ClearContact(_context);
            await IntegrationTestInitializer.SetContact(_context);
            await IntegrationTestInitializer.ClearContactData(_context);
            await IntegrationTestInitializer.SetContactData(_context);
        }

        [OneTimeTearDown]
        public async Task ClearData()
        {
            await IntegrationTestInitializer.ClearContact(_context);
            await IntegrationTestInitializer.ClearContactData(_context);
        }

        [Test]
        public async Task CreateContact_WhenCreateContact_ShouldReturnWithNewContact()
        {
            // Arrange
            var contactService = ServiceInitializer.GetContact(_context);

            // Act
            await contactService.CreateAsync(new ContactEntity
            {
                FirstName = "Created",
                LastName = "Created",
                Position = "Created",
                Patronymic = "Created",
                Photo = "Created",
                Gender = Gender.Male,
                IndexNumber = 3,
                PositionType = PositionType.Manager,
            });

            var list = contactService.GetAll();

            // Assert
            list.Should().BeEquivalentTo(new List<ContactEntity>
            {
                new ContactEntity
                {
                    Id = 1,
                    Position = "1",
                    FirstName = "1",
                    LastName = "1",
                    Patronymic = "1",
                    Photo = "1",
                    IndexNumber = 1,
                    PositionType = PositionType.Manager,
                    Gender = Gender.Male,
                },
                new ContactEntity
                {
                    Id = 2,
                    Position = "2",
                    FirstName = "2",
                    LastName = "2",
                    Patronymic = "2",
                    Photo = "2",
                    IndexNumber = 2,
                    PositionType = PositionType.ChiefProjectEngineer,
                    Gender = Gender.Male,
                },
                new ContactEntity
                {
                    Id = 3,
                    FirstName = "Created",
                    LastName = "Created",
                    Patronymic = "Created",
                    Position = "Created",
                    Photo = "Created",
                    IndexNumber = 3,
                    PositionType = PositionType.Manager,
                    Gender = Gender.Male,
                },
            });
        }

        [Test]
        public async Task UpdateContact_WhenUpdateContact_ShouldReturnUpdatedContact()
        {
            // Arrange
            var serviceContact = ServiceInitializer.GetContact(_context);

            // Act
            await serviceContact.UpdateAsync(new ContactEntity
            {
                Id = 1,
                Position = "Updated",
                FirstName = "Updated",
                LastName = "Updated",
                Patronymic = "Updated",
                Photo = "Updated",
                IndexNumber = 1,
                PositionType = PositionType.Manager,
                Gender = Gender.Male,
            });

            var list = serviceContact.GetAll();

            // Assert
            list.Should().BeEquivalentTo(new List<ContactEntity>
            {
                new ContactEntity
                {
                    Id = 1,
                    FirstName = "Updated",
                    LastName = "Updated",
                    Patronymic = "Updated",
                    Position = "Updated",
                    Photo = "Updated",
                    IndexNumber = 1,
                    PositionType = PositionType.Manager,
                    Gender = Gender.Male,
                },
                new ContactEntity
                {
                    Id = 2,
                    Position = "2",
                    FirstName = "2",
                    LastName = "2",
                    Patronymic = "2",
                    Photo = "2",
                    IndexNumber = 2,
                    PositionType = PositionType.ChiefProjectEngineer,
                    Gender = Gender.Male,
                },
            });
        }

        [Test]
        public async Task DeleteContact_WhenDeleteContact_ShouldReturnWithoutDeletedContactAndWithoutContactData()
        {
            // Arrange
            var contactService = ServiceInitializer.GetContact(_context);
            var contactPhoneService = ServiceInitializer.GetContactData(_context);

            // Act
            await contactService.DeleteAsync(1);
            var contactList = contactService.GetAll();
            var contactPhoneList = contactPhoneService.GetAll();

            // Assert
            contactList.Should().BeEquivalentTo(new List<ContactEntity>
            {
                new ContactEntity
                {
                    Id = 2,
                    Position = "2",
                    FirstName = "2",
                    LastName = "2",
                    Patronymic = "2",
                    Photo = "2",
                    IndexNumber = 2,
                    PositionType = PositionType.ChiefProjectEngineer,
                },
            });
            contactPhoneList.Should().BeEquivalentTo(new List<ContactDataEntity>
            {
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
