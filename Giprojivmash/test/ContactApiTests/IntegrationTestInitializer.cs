using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Giprojivmash.DAL.Context;
using Giprojivmash.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactApiTests
{
    public static class IntegrationTestInitializer
    {
        public static async Task SetContact(GiprojivmashContext context)
        {
            Validator(context);
            var contacts = new List<ContactEntity>
            {
                new ContactEntity
                {
                    Address = "1",
                    Description = "1",
                    Photo = "1",
                },
                new ContactEntity
                {
                    Address = "2",
                    Description = "2",
                    Photo = "2",
                },
            };

            foreach (var contact in contacts)
            {
                await context.Contact.AddAsync(contact);
                await context.SaveChangesAsync();
            }
        }

        public static async Task SetContactPhone(GiprojivmashContext context)
        {
            Validator(context);
            var phones = new List<ContactPhoneEntity>
            {
                new ContactPhoneEntity
                {
                    ContactId = 1,
                    Number = "1",
                    Type = 1,
                },
                new ContactPhoneEntity
                {
                    ContactId = 1,
                    Number = "2",
                    Type = 1,
                },
                new ContactPhoneEntity
                {
                    ContactId = 2,
                    Number = "1",
                    Type = 1,
                },
            };

            foreach (var phone in phones)
            {
                await context.ContactPhone.AddAsync(phone);
                await context.SaveChangesAsync();
            }
        }

        public static string GetConnectionString()
        {
            return "server=localhost;user id=root;password=12345;persistsecurityinfo=True;database=giprojivmash_site;Charset=utf8;";
        }

        public static async Task ClearAllTable(GiprojivmashContext context)
        {
            Validator(context);
            await ClearContact(context);
            await ClearContactPhone(context);
        }

        public static async Task ClearContact(GiprojivmashContext context)
        {
            Validator(context);
            await context.Database.ExecuteSqlRawAsync(@"TRUNCATE TABLE contact");
        }

        public static async Task ClearContactPhone(GiprojivmashContext context)
        {
            Validator(context);
            await context.Database.ExecuteSqlRawAsync(@"TRUNCATE TABLE contactphone");
        }

        private static void Validator(GiprojivmashContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
        }
    }
}
