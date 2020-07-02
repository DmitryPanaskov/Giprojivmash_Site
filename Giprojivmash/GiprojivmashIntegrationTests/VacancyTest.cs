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
    internal class VacancyTest : IDisposable
    {
        private GiprojivmashContext _context;
        private bool _disposedValue;

        [SetUp]
        public async Task Initializer()
        {
            _context = new GiprojivmashContext(new DbContextOptionsBuilder().UseSqlServer(IntegrationTestInitializer.GetConnectionString()).Options);
            await IntegrationTestInitializer.ClearVacancy(_context);
            await IntegrationTestInitializer.SetVacancy(_context);
        }

        [Test]
        public async Task CreateVacancy_WhenCreateVacancy_ShouldReturnWithNewVacancy()
        {
            // Arrange
            var contactService = ServiceInitializer.GetVacancy(_context);

            // Act
            await contactService.CreateAsync(new VacancyEntity
            {
                Position = "Created",
                Description = "Created",
                Contact = "Created",
            });

            var list = contactService.GetAll();

            // Assert
            list.Should().BeEquivalentTo(new List<VacancyEntity>
            {
                new VacancyEntity
                {
                    Id = 1,
                    Description = "1",
                    Contact = "1",
                    Position = "1",
                },
                new VacancyEntity
                {
                    Id = 2,
                    Description = "2",
                    Contact = "2",
                    Position = "2",
                },
                new VacancyEntity
                {
                    Id = 3,
                    Position = "Created",
                    Description = "Created",
                    Contact = "Created",
                },
            });
        }

        [Test]
        public async Task UpdateVacancy_WhenUpdateVacancy_ShouldReturnUpdatedContact()
        {
            // Arrange
            var serviceVacancy = ServiceInitializer.GetVacancy(_context);

            // Act
            await serviceVacancy.UpdateAsync(new VacancyEntity
            {
                Id = 1,
                Description = "Updated",
                Contact = "Updated",
                Position = "Updated",
            });

            var list = serviceVacancy.GetAll();

            // Assert
            list.Should().BeEquivalentTo(new List<VacancyEntity>
            {
                new VacancyEntity
                {
                    Id = 1,
                    Description = "Updated",
                    Contact = "Updated",
                    Position = "Updated",
                },
                new VacancyEntity
                {
                    Id = 2,
                    Description = "2",
                    Contact = "2",
                    Position = "2",
                },
            });
        }

        [Test]
        public async Task DeleteVacancy_WhenDeleteVacancy_ShouldReturnWithoutDeletedVacancy()
        {
            // Arrange
            var vacancyService = ServiceInitializer.GetVacancy(_context);

            // Act
            await vacancyService.DeleteAsync(1);
            var vacancytList = vacancyService.GetAll();

            // Assert
            vacancytList.Should().BeEquivalentTo(new List<VacancyEntity>
            {
                new VacancyEntity
                {
                    Id = 2,
                    Description = "2",
                    Contact = "2",
                    Position = "2",
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
