using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Giprojivmash.DAL.Context;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DataModels.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GiprojivmashIntegrationTests
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
                    FirstName = "1",
                    LastName = "1",
                    Patronymic = "1",
                    Description = "1",
                    Photo = "1",
                    Position = "1",
                    IndexNumber = 1,
                    PositionType = PositionType.Manager,
                    Gender = Gender.Male,
                },
                new ContactEntity
                {
                    FirstName = "2",
                    LastName = "2",
                    Patronymic = "2",
                    Description = "2",
                    Photo = "2",
                    Position = "2",
                    IndexNumber = 2,
                    PositionType = PositionType.ChiefProjectEngineer,
                    Gender = Gender.Male,
                },
            };

            foreach (var contact in contacts)
            {
                await context.Contacts.AddAsync(contact);
                await context.SaveChangesAsync();
            }
        }

        public static async Task SetContactData(GiprojivmashContext context)
        {
            Validator(context);
            var phones = new List<ContactDataEntity>
            {
                new ContactDataEntity
                {
                    ContactId = 1,
                    Data = "1",
                    SubData = "1",
                    ContactDataType = ContactDataType.WorkTelephone,
                },
                new ContactDataEntity
                {
                    ContactId = 1,
                    Data = "2",
                    SubData = "2",
                    ContactDataType = ContactDataType.WorkTelephone,
                },
                new ContactDataEntity
                {
                    ContactId = 2,
                    Data = "1",
                    SubData = "1",
                    ContactDataType = ContactDataType.WorkTelephone,
                },
            };

            foreach (var phone in phones)
            {
                await context.ContactDatas.AddAsync(phone);
                await context.SaveChangesAsync();
            }
        }

        public static async Task SetVacancy(GiprojivmashContext context)
        {
            Validator(context);
            var vacancies = new List<VacancyEntity>
            {
                new VacancyEntity
                {
                     Position = "1",
                     Description = "1",
                     PhoneNumber = "1",
                },
                new VacancyEntity
                {
                     Position = "2",
                     Description = "2",
                     PhoneNumber = "2",
                },
            };

            foreach (var vacancy in vacancies)
            {
                await context.Vacancies.AddAsync(vacancy);
                await context.SaveChangesAsync();
            }
        }

        public static async Task SetHistory(GiprojivmashContext context)
        {
            Validator(context);
            var histories = new List<HistoryEntity>
            {
                new HistoryEntity
                {
                     Description = "1",
                },
                new HistoryEntity
                {
                     Description = "2",
                },
            };

            foreach (var history in histories)
            {
                await context.Histories.AddAsync(history);
                await context.SaveChangesAsync();
            }
        }

        public static async Task SetHistoryPhoto(GiprojivmashContext context)
        {
            Validator(context);
            var historyPhotos = new List<HistoryPhotoEntity>
            {
                new HistoryPhotoEntity
                {
                    HistoryId = 1,
                    PhotoName = "1",
                },
                new HistoryPhotoEntity
                {
                    HistoryId = 1,
                    PhotoName = "2",
                },
                new HistoryPhotoEntity
                {
                    HistoryId = 2,
                    PhotoName = "1",
                },
            };

            foreach (var historyPhoto in historyPhotos)
            {
                await context.HistoryPhotos.AddAsync(historyPhoto);
                await context.SaveChangesAsync();
            }
        }

        public static async Task SetPortfolio(GiprojivmashContext context)
        {
            Validator(context);
            var portfolios = new List<PortfolioEntity>
            {
                new PortfolioEntity
                {
                     Description = "1",
                },
                new PortfolioEntity
                {
                     Description = "2",
                },
            };

            foreach (var portfolio in portfolios)
            {
                await context.Portfolios.AddAsync(portfolio);
                await context.SaveChangesAsync();
            }
        }

        public static async Task SetPortfolioPhoto(GiprojivmashContext context)
        {
            Validator(context);
            var portfolioPhotos = new List<PortfolioPhotoEntity>
            {
                new PortfolioPhotoEntity
                {
                    PortfolioId = 1,
                    PhotoName = "1",
                },
                new PortfolioPhotoEntity
                {
                    PortfolioId = 1,
                    PhotoName = "2",
                },
                new PortfolioPhotoEntity
                {
                    PortfolioId = 2,
                    PhotoName = "1",
                },
            };

            foreach (var portfolioPhoto in portfolioPhotos)
            {
                await context.PortfolioPhotos.AddAsync(portfolioPhoto);
                await context.SaveChangesAsync();
            }
        }

        public static async Task SetUser(GiprojivmashContext context)
        {
            Validator(context);
            var passwordHasher = new PasswordHasher<UserEntity>();
            var user = new UserEntity
            {
                Id = "09c4597a-3267-4cf9-8942-86dcae7f18e3",
                Email = "post@gipro.gomel.by",
                UserName = "Admin",
                PasswordHash = passwordHasher.HashPassword(new UserEntity(), "123456"),
                AccessFailedCount = 10,
                EmailConfirmed = false,
                LockoutEnabled = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
            };
            await context.ApplicationUsers.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public static string GetConnectionString()
        {
            return "server=localhost;user id=root;password=12345;persistsecurityinfo=True;database=giprojivmash_site;Charset=utf8;";
        }

        public static async Task ClearPage(GiprojivmashContext context)
        {
            Validator(context);
            await context.Database.ExecuteSqlRawAsync(@"TRUNCATE TABLE page");
        }

        public static async Task ClearServiceFirstLayer(GiprojivmashContext context)
        {
            Validator(context);
            await context.Database.ExecuteSqlRawAsync(@"TRUNCATE TABLE servicefirstlayer");
        }

        public static async Task ClearServiceSecondLayer(GiprojivmashContext context)
        {
            Validator(context);
            await context.Database.ExecuteSqlRawAsync(@"TRUNCATE TABLE servicesecondlayer");
        }

        public static async Task ClearServiceThirdLayer(GiprojivmashContext context)
        {
            Validator(context);
            await context.Database.ExecuteSqlRawAsync(@"TRUNCATE TABLE servicethirdlayer");
        }

        public static async Task ClearContact(GiprojivmashContext context)
        {
            Validator(context);
            await context.Database.ExecuteSqlRawAsync(@"TRUNCATE TABLE contact");
        }

        public static async Task ClearContactData(GiprojivmashContext context)
        {
            Validator(context);
            await context.Database.ExecuteSqlRawAsync(@"TRUNCATE TABLE contactdata");
        }

        public static async Task ClearHistory(GiprojivmashContext context)
        {
            Validator(context);
            await context.Database.ExecuteSqlRawAsync(@"TRUNCATE TABLE history");
        }

        public static async Task ClearHistoryPhoto(GiprojivmashContext context)
        {
            Validator(context);
            await context.Database.ExecuteSqlRawAsync(@"TRUNCATE TABLE historyphoto");
        }

        public static async Task ClearPortfolio(GiprojivmashContext context)
        {
            Validator(context);
            await context.Database.ExecuteSqlRawAsync(@"TRUNCATE TABLE portfolio");
        }

        public static async Task ClearPortfolioPhoto(GiprojivmashContext context)
        {
            Validator(context);
            await context.Database.ExecuteSqlRawAsync(@"TRUNCATE TABLE portfoliophoto");
        }

        public static async Task ClearVacancy(GiprojivmashContext context)
        {
            Validator(context);
            await context.Database.ExecuteSqlRawAsync(@"TRUNCATE TABLE vacancy");
        }

        public static async Task ClearUser(GiprojivmashContext context)
        {
            Validator(context);
            await context.Database.ExecuteSqlRawAsync(@"TRUNCATE TABLE aspnetusers");
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
