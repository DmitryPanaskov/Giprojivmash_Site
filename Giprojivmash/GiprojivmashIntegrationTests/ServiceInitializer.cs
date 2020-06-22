using Giprojivmash.BLL.Interfaces;
using Giprojivmash.BLL.Services;
using Giprojivmash.DAL.Context;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DAL.Repositories;

namespace GiprojivmahsIntegrationTests
{
    public static class ServiceInitializer
    {
        public static string GetConnectionString()
        {
            return @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Giprojivmash_Site;";
        }

        public static IServiceFirstLayerService GetServiceFirstLayerService(GiprojivmashContext context)
        {
            return new ServiceFirstLayerService(new GenericRepository<ServiceFirstLayerEntity>(context));
        }

        public static IServiceSecondLayerService GetServiceSecondLayerService(GiprojivmashContext context)
        {
            return new ServiceSecondLayerService(new GenericRepository<ServiceSecondLayerEntity>(context));
        }

        public static IServiceThirdLayerService GetServiceThirdLayerService(GiprojivmashContext context)
        {
            return new ServiceThirdLayerService(new GenericRepository<ServiceThirdLayerEntity>(context));
        }
    }
}
