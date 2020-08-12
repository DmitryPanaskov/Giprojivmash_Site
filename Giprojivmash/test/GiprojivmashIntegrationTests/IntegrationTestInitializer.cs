using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Giprojivmash.DAL.Context;
using Giprojivmash.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GiprojivmashIntegrationTests
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
                     Title = "1",
                     PhotoTitle = "1",
                     DescriptionShort = "1",
                },
                new ServiceFirstLayerEntity
                {
                     Description = "2",
                     DescriptionShort = "2",
                     PhotoTitle = "2",
                     Title = "2",
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
                    FirstName = "1",
                    LastName = "1",
                    Patronymic = "1",
                    Description = "1",
                    Photo = "1",
                },
                new ContactEntity
                {
                    FirstName = "2",
                    LastName = "2",
                    Patronymic = "2",
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
                    Type = 1,
                },
                new ContactDataEntity
                {
                    ContactId = 1,
                    Data = "2",
                    SubData = "2",
                    Type = 1,
                },
                new ContactDataEntity
                {
                    ContactId = 2,
                    Data = "1",
                    SubData = "1",
                    Type = 1,
                },
            };

            foreach (var phone in phones)
            {
                await context.ContactData.AddAsync(phone);
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
                await context.Portfolio.AddAsync(portfolio);
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
                await context.PortfolioPhoto.AddAsync(portfolioPhoto);
                await context.SaveChangesAsync();
            }
        }

        public static string GetConnectionString()
        {
            return "server=localhost;user id=root;password=12345;persistsecurityinfo=True;database=giprojivmash_site;Charset=utf8;";
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

        private static void Validator(GiprojivmashContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
        }
    }
}
