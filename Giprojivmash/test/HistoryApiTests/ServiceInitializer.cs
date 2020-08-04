using Giprojivmash.BLL.Interfaces;
using Giprojivmash.BLL.Services;
using Giprojivmash.DAL.Context;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DAL.Repositories;

namespace HistoryApiTests
{
    public static class ServiceInitializer
    {
        public static IHistoryService GetHistory(GiprojivmashContext context)
        {
            return new HistoryService(new GenericRepository<HistoryEntity>(context),
                new GenericRepository<HistoryPhotoEntity>(context));
        }

        public static IHistoryPhotoService GetHistoryPhoto(GiprojivmashContext context)
        {
            return new HistoryPhotoService(new GenericRepository<HistoryPhotoEntity>(context));
        }
    }
}
