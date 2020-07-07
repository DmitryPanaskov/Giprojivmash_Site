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
    internal class ContactTest : IDisposable
    {
        private GiprojivmashContext _context;
        private bool _disposedValue;

        [SetUp]
        public async Task Initializer()
        {
            _context = new GiprojivmashContext(new DbContextOptionsBuilder().UseSqlServer(IntegrationTestInitializer.GetConnectionString()).Options);
            await IntegrationTestInitializer.ClearContact(_context);
            await IntegrationTestInitializer.SetContact(_context);
            await IntegrationTestInitializer.ClearContactPhone(_context);
            await IntegrationTestInitializer.SetContactPhone(_context);
        }

        [OneTimeTearDown]
        public async Task ClearData()
        {
            await IntegrationTestInitializer.ClearContact(_context);
            await IntegrationTestInitializer.ClearContactPhone(_context);
        }

        [Test]
        public async Task CreateContact_WhenCreateContact_ShouldReturnWithNewContact()
        {
            // Arrange
            var contactService = ServiceInitializer.GetContact(_context);

            // Act
            await contactService.CreateAsync(new ContactEntity
            {
                Address = "Created",
                Description = "Created",
                Photo = "Created",
            });

            var list = contactService.GetAll();

            // Assert
            list.Should().BeEquivalentTo(new List<ContactEntity>
            {
                new ContactEntity
                {
                    Id = 1,
                    Description = "1",
                    Address = "1",
                    Photo = "1",
                },
                new ContactEntity
                {
                    Id = 2,
                    Description = "2",
                    Address = "2",
                    Photo = "2",
                },
                new ContactEntity
                {
                    Id = 3,
                    Address = "Created",
                    Description = "Created",
                    Photo = "Created",
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
                Description = "Updated",
                Address = "Updated",
                Photo = "Updated",
            });

            var list = serviceContact.GetAll();

            // Assert
            list.Should().BeEquivalentTo(new List<ContactEntity>
            {
                new ContactEntity
                {
                    Id = 1,
                    Address = "Updated",
                    Description = "Updated",
                    Photo = "Updated",
                },
                new ContactEntity
                {
                    Id = 2,
                    Description = "2",
                    Address = "2",
                    Photo = "2",
                },
            });
        }

        [Test]
        public async Task DeleteContact_WhenDeleteContact_ShouldReturnWithoutDeletedContactAndWithoutContactPhone()
        {
            // Arrange
            var contactService = ServiceInitializer.GetContact(_context);
            var contactPhoneService = ServiceInitializer.GetContactPhone(_context);

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
                    Description = "2",
                    Address = "2",
                    Photo = "2",
                },
            });
            contactPhoneList.Should().BeEquivalentTo(new List<ContactPhoneEntity>
            {
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
