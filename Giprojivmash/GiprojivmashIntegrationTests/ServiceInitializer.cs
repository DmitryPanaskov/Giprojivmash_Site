using Giprojivmash.BLL.Interfaces;
using Giprojivmash.BLL.Services;
using Giprojivmash.DAL.Context;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DAL.Repositories;

namespace GiprojivmahsIntegrationTests
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
            return new ServiceThirdLayerService(new GenericRepository<ServiceThirdLayerEntity>(context));
        }

        public static IContactService GetContact(GiprojivmashContext context)
        {
            return new ContactService(new GenericRepository<ContactEntity>(context),
                new GenericRepository<ContactPhoneEntity>(context));
        }

        public static IContactPhoneService GetContactPhone(GiprojivmashContext context)
        {
            return new ContactPhoneService(new GenericRepository<ContactPhoneEntity>(context));
        }

        public static IHistoryService GetHistory(GiprojivmashContext context)
        {
            return new HistoryService(new GenericRepository<HistoryEntity>(context),
                new GenericRepository<HistoryPhotoEntity>(context));
        }

        public static IHistoryPhotoService GetHistoryPhoto(GiprojivmashContext context)
        {
            return new HistoryPhotoService(new GenericRepository<HistoryPhotoEntity>(context));
        }

        public static IVacancyService GetVacancy(GiprojivmashContext context)
        {
            return new VacancyService(new GenericRepository<VacancyEntity>(context));
        }
    }
}
