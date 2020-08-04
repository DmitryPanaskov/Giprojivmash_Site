using Giprojivmash.BLL.Interfaces;
using Giprojivmash.BLL.Services;
using Giprojivmash.DAL.Context;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DAL.Repositories;

namespace ServiceApiTests
{
    public static class ServiceInitializer
    {
        public static IServiceFirstLayerService GetServiceFirstLayerService(GiprojivmashContext context)
        {
            return new ServiceFirstLayerService(
                new GenericRepository<ServiceFirstLayerEntity>(context),
                new GenericRepository<ServiceSecondLayerEntity>(context),
                new GenericRepository<ServiceThirdLayerEntity>(context));
        }

        public static IServiceSecondLayerService GetServiceSecondLayerService(GiprojivmashContext context)
        {
            return new ServiceSecondLayerService(
                new GenericRepository<ServiceSecondLayerEntity>(context),
                new GenericRepository<ServiceThirdLayerEntity>(context));
        }

        public static IServiceThirdLayerService GetServiceThirdLayerService(GiprojivmashContext context)
        {
            return new ServiceThirdLayerService(new GenericRepository<ServiceThirdLayerEntity>(context),
                new GenericRepository<ServiceSecondLayerEntity>(context));
        }
    }
}
