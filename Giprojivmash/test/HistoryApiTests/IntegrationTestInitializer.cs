using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Giprojivmash.DAL.Context;
using Giprojivmash.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HistoryApiTests
{
    public static class IntegrationTestInitializer
    {
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
            return "server=localhost;user id=root;password=12345;persistsecurityinfo=True;database=giprojivmash_site;Charset=utf8;";
        }

        public static async Task ClearAllTable(GiprojivmashContext context)
        {
            Validator(context);
            await ClearHistory(context);
            await ClearHistoryPhoto(context);
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

        private static void Validator(GiprojivmashContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
        }
    }
}
