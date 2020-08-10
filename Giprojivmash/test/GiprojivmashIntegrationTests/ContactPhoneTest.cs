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
    internal class ContactPhoneTest : IDisposable
    {
        private GiprojivmashContext _context;
        private bool _disposedValue;

        [SetUp]
        public async Task Initializer()
        {
            _context = new GiprojivmashContext(new DbContextOptionsBuilder()
                .UseMySQL(IntegrationTestInitializer.GetConnectionString()).Options);
            await IntegrationTestInitializer.ClearContactPhone(_context);
            await IntegrationTestInitializer.SetContactPhone(_context);
        }

        [OneTimeTearDown]
        public async Task ClearData()
        {
            await IntegrationTestInitializer.ClearContactPhone(_context);
        }

        [Test]
        public async Task CreateContactPhone_WhenCreateContactPhone_ShouldReturnWithNewContactPhone()
        {
            // Arrange
            var contactPhoneService = ServiceInitializer.GetContactPhone(_context);

            // Act
            await contactPhoneService.CreateAsync(new ContactPhoneEntity
            {
                ContactId = 1,
                Number = "Created",
                Type = 1,
            });

            var list = contactPhoneService.GetAll();

            // Assert
            list.Should().BeEquivalentTo(new List<ContactPhoneEntity>
            {
                new ContactPhoneEntity
                {
                    Id = 1,
                    ContactId = 1,
                    Number = "1",
                    Type = 1,
                },
                new ContactPhoneEntity
                {
                    Id = 2,
                    ContactId = 1,
                    Number = "2",
                    Type = 1,
                },
                new ContactPhoneEntity
                {
                    Id = 3,
                    ContactId = 2,
                    Number = "1",
                    Type = 1,
                },
                new ContactPhoneEntity
                {
                    Id = 4,
                    ContactId = 1,
                    Number = "Created",
                    Type = 1,
                },
            });
        }

        [Test]
        public async Task UpdateContactPhone_WhenUpdateContactPhone_ShouldReturnUpdatedContact()
        {
            // Arrange
            var serviceContactPhone = ServiceInitializer.GetContactPhone(_context);

            // Act
            await serviceContactPhone.UpdateAsync(new ContactPhoneEntity
            {
                Id = 1,
                ContactId = 1,
                Number = "Updated",
                Type = 1,
            });

            var list = serviceContactPhone.GetAll();

            // Assert
            list.Should().BeEquivalentTo(new List<ContactPhoneEntity>
            {
                new ContactPhoneEntity
                {
                    Id = 1,
                    ContactId = 1,
                    Number = "Updated",
                    Type = 1,
                },
                new ContactPhoneEntity
                {
                    Id = 2,
                    ContactId = 1,
                    Number = "2",
                    Type = 1,
                },
                new ContactPhoneEntity
                {
                    Id = 3,
                    ContactId = 2,
                    Number = "1",
                    Type = 1,
                },
            });
        }

        [Test]
        public async Task DeleteContactPhone_WhenDeleteContactPhone_ShouldReturnWithoutDeletedContactPhone()
        {
            // Arrange
            var contactPhoneService = ServiceInitializer.GetContactPhone(_context);

            // Act
            await contactPhoneService.DeleteAsync(1);
            var contactPhoneList = contactPhoneService.GetAll();

            // Assert
            contactPhoneList.Should().BeEquivalentTo(new List<ContactPhoneEntity>
            {
                new ContactPhoneEntity
                {
                    Id = 2,
                    ContactId = 1,
                    Number = "2",
                    Type = 1,
                },
                new ContactPhoneEntity
                {
                    Id = 3,
                    ContactId = 2,
                    Number = "1",
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