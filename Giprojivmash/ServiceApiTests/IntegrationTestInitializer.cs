using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Giprojivmash.DAL.Context;
using Giprojivmash.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ServiceApiTests
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

        public static string GetConnectionString()
        {
            return "server=localhost;user id=root;password=12345;persistsecurityinfo=True;database=giprojivmash_site;Charset=utf8;";
        }

        public static async Task ClearAllTable(GiprojivmashContext context)
        {
            Validator(context);
            await ClearServiceFirstLayer(context);
            await ClearServiceSecondLayer(context);
            await ClearServiceThirdLayer(context);
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

        private static void Validator(GiprojivmashContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
        }
    }
}
