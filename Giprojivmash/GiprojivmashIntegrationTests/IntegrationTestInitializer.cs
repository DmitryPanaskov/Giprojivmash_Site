using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Giprojivmash.DAL.Context;
using Giprojivmash.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GiprojivmahsIntegrationTests
{
    public static class IntegrationTestInitializer
    {
        public static async Task SetServiceFirstLayer(GiprojivmashContext context)
        {
            Validator(context);
            var serviceFirstLayers = new List<ServiceFirstLayerEntity>
            {
                new ServiceFirstLayerEntity
                {
                     Description = "1",
                },
                new ServiceFirstLayerEntity
                {
                     Description = "2",
                },
            };

            foreach (var serviceFirstLayer in serviceFirstLayers)
            {
                await context.ServiceFirstLayers.AddAsync(serviceFirstLayer);
                await context.SaveChangesAsync();
            }
        }

        public static async Task SetServiceSecondLayer(GiprojivmashContext context)
        {
            Validator(context);
            var serviceSecondLayers = new List<ServiceSecondLayerEntity>
            {
                new ServiceSecondLayerEntity
                {
                    ServiceFirstLayerId = 1,
                    Description = "1",
                },
                new ServiceSecondLayerEntity
                {
                    ServiceFirstLayerId = 1,
                    Description = "2",
                },
                new ServiceSecondLayerEntity
                {
                    ServiceFirstLayerId = 2,
                    Description = "3",
                },
            };

            foreach (var serviceSecondLayer in serviceSecondLayers)
            {
                await context.ServiceSecondLayers.AddAsync(serviceSecondLayer);
                await context.SaveChangesAsync();
            }
        }

        public static async Task SetServiceThirdLayer(GiprojivmashContext context)
        {
            Validator(context);
            var serviceThirdLayers = new List<ServiceThirdLayerEntity>
            {
                new ServiceThirdLayerEntity
                {
                    ServiceSecondLayerId = 1,
                    Description = "1",
                },
                new ServiceThirdLayerEntity
                {
                    ServiceSecondLayerId = 1,
                    Description = "2",
                },
                new ServiceThirdLayerEntity
                {
                    ServiceSecondLayerId = 1,
                    Description = "3",
                },
                new ServiceThirdLayerEntity
                {
                    ServiceSecondLayerId = 2,
                    Description = "1",
                },
                new ServiceThirdLayerEntity
                {
                    ServiceSecondLayerId = 3,
                    Description = "1",
                },
            };

            foreach (var serviceThirdLayer in serviceThirdLayers)
            {
                await context.ServiceThirdLayers.AddAsync(serviceThirdLayer);
                await context.SaveChangesAsync();
            }
        }

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

        public static async Task SetVacancy(GiprojivmashContext context)
        {
            Validator(context);
            var vacancies = new List<VacancyEntity>
            {
                new VacancyEntity
                {
                     Position = "1",
                     Description = "1",
                     Contact = "1",
                },
                new VacancyEntity
                {
                     Position = "2",
                     Description = "2",
                     Contact = "2",
                },
            };

            foreach (var vacancy in vacancies)
            {
                await context.Vacancy.AddAsync(vacancy);
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
                await context.History.AddAsync(history);
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
                await context.HistoryPhoto.AddAsync(historyPhoto);
                await context.SaveChangesAsync();
            }
        }

        public static string GetConnectionString()
        {
            return @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Giprojivmash_Site;";
        }

        public static async Task ClearAllTable(GiprojivmashContext context)
        {
            Validator(context);
            await ClearServiceFirstLayer(context);
            await ClearServiceSecondLayer(context);
            await ClearServiceThirdLayer(context);
            await ClearContact(context);
            await ClearContactPhone(context);
            await ClearHistory(context);
            await ClearHistoryPhoto(context);
            await ClearVacancy(context);
        }

        public static async Task ClearServiceFirstLayer(GiprojivmashContext context)
        {
            Validator(context);
            await context.Database.ExecuteSqlRawAsync(@"TRUNCATE TABLE dbo.[ServiceFirstLayer]");
        }

        public static async Task ClearServiceSecondLayer(GiprojivmashContext context)
        {
            Validator(context);
            await context.Database.ExecuteSqlRawAsync(@"TRUNCATE TABLE dbo.[ServiceSecondLayer]");
        }

        public static async Task ClearServiceThirdLayer(GiprojivmashContext context)
        {
            Validator(context);
            await context.Database.ExecuteSqlRawAsync(@"TRUNCATE TABLE dbo.[ServiceThirdLayer]");
        }

        public static async Task ClearContact(GiprojivmashContext context)
        {
            Validator(context);
            await context.Database.ExecuteSqlRawAsync(@"TRUNCATE TABLE dbo.[Contact]");
        }

        public static async Task ClearContactPhone(GiprojivmashContext context)
        {
            Validator(context);
            await context.Database.ExecuteSqlRawAsync(@"TRUNCATE TABLE dbo.[ContactPhone]");
        }

        public static async Task ClearHistory(GiprojivmashContext context)
        {
            Validator(context);
            await context.Database.ExecuteSqlRawAsync(@"TRUNCATE TABLE dbo.[History]");
        }

        public static async Task ClearHistoryPhoto(GiprojivmashContext context)
        {
            Validator(context);
            await context.Database.ExecuteSqlRawAsync(@"TRUNCATE TABLE dbo.[HistoryPhoto]");
        }

        public static async Task ClearVacancy(GiprojivmashContext context)
        {
            Validator(context);
            await context.Database.ExecuteSqlRawAsync(@"TRUNCATE TABLE dbo.[Vacancy]");
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
