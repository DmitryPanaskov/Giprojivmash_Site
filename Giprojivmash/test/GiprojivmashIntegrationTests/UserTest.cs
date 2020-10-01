using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Giprojivmash.DAL.Context;
using Giprojivmash.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace GiprojivmashIntegrationTests
{
    [TestFixture]
    internal class UserTest : IDisposable
    {
        private GiprojivmashContext _context;
        private bool _disposedValue;

        [SetUp]
        public async Task Initializer()
        {
            _context = new GiprojivmashContext(new DbContextOptionsBuilder().UseMySQL(IntegrationTestInitializer.GetConnectionString()).Options);
            await IntegrationTestInitializer.ClearUser(_context);
            await IntegrationTestInitializer.SetUser(_context);
        }

        [OneTimeTearDown]
        public async Task ClearData()
        {
            await IntegrationTestInitializer.ClearUser(_context);
        }

        [Test]
        public async Task UpdateUser_WhenUpdateUser_ShouldReturnUpdatedUser()
        {
            // Arrange
            var userService = ServiceInitializer.GetUser(_context);
            var user = _context.ApplicationUsers.First();
            var passwordHash = new PasswordHasher<UserEntity>().HashPassword(user, "999999");
            user.PasswordHash = passwordHash;
            user.UserName = "Super Admin";

            // Act
            await userService.UpdateAsync(user);
            var updatedUser = _context.ApplicationUsers.First();

            // Assert
            updatedUser.Should().BeEquivalentTo(new UserEntity
            {
                 Id = user.Id,
                 UserName = "Super Admin",
                 PasswordHash = passwordHash,
                 Email = "post@gipro.gomel.by",
                 SecurityStamp = updatedUser.SecurityStamp,
                 ConcurrencyStamp = updatedUser.ConcurrencyStamp,
                 AccessFailedCount = updatedUser.AccessFailedCount,
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
