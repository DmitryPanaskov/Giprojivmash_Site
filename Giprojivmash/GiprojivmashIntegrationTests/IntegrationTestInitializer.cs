using System;
using System.Collections.Generic;
using System.IO;
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
                context.ServiceFirstLayers.Add(serviceFirstLayer);
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
                    Description = "1 1 1",
                },
                new ServiceSecondLayerEntity
                {
                    ServiceFirstLayerId = 1,
                    Description = "2 1 2",
                },
            };

            foreach (var serviceSecondLayer in serviceSecondLayers)
            {
                context.ServiceSecondLayers.Add(serviceSecondLayer);
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
                    ServiceThirdLayerId = 1,
                    Description = "1 1 1",
                },
                new ServiceThirdLayerEntity
                {
                    ServiceThirdLayerId = 1,
                    Description = "1 1 1",
                },
                new ServiceThirdLayerEntity
                {
                    ServiceThirdLayerId = 1,
                    Description = "1 1 1",
                },
            };

            foreach (var serviceThirdLayer in serviceThirdLayers)
            {
                context.ServiceThirdLayers.Add(serviceThirdLayer);
                await context.SaveChangesAsync();
            }
        }

        public static RestoreDataBase(GiprojivmashContext context)
        {
            Validator(context);
            context.Database.ExecuteSqlRaw(@"DROP DATABASE Giprojivmash_Site");
            const string dacPacName = "Giprojivmashe_Site.dacpac";
            const string connectionString = "Server=localhost;Database=Giprojivmash_Test;trusted_connection=true";
            var path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\", dacPacName));
            var dacPack = new DacServices(connectionString);
            var dacOptions = new DacDeployOptions { CreateNewDatabase = true };
            using (var dp = DacPackage.Load(path))
            {
                dacPack.Deploy(dp, @"TicketManagement", true, dacOptions);
            }
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
