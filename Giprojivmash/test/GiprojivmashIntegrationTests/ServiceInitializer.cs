using Giprojivmash.BLL.Interfaces;
using Giprojivmash.BLL.Services;
using Giprojivmash.DAL.Context;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DAL.Repositories;

namespace GiprojivmashIntegrationTests
{
    public static class ServiceInitializer
    {
        public static IPageService GetPageService(GiprojivmashContext context)
        {
            return new PageService(
                new GenericRepository<PageEntity>(context));
        }

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

        public static IContactService GetContact(GiprojivmashContext context)
        {
            return new ContactService(new GenericRepository<ContactEntity>(context),
                new GenericRepository<ContactDataEntity>(context));
        }

        public static IContactDataService GetContactData(GiprojivmashContext context)
        {
            return new ContactDataService(new GenericRepository<ContactDataEntity>(context),
                new GenericRepository<ContactEntity>(context));
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

        public static IPortfolioService GetPortfolio(GiprojivmashContext context)
        {
            return new PortfolioService(new GenericRepository<PortfolioEntity>(context),
                new GenericRepository<PortfolioPhotoEntity>(context));
        }

        public static IPortfolioPhotoService GetPortfolioPhoto(GiprojivmashContext context)
        {
            return new PortfolioPhotoService(new GenericRepository<PortfolioPhotoEntity>(context));
        }

        public static IVacancyService GetVacancy(GiprojivmashContext context)
        {
            return new VacancyService(new GenericRepository<VacancyEntity>(context));
        }

        public static IDepartmentService GetDepartment(GiprojivmashContext context)
        {
            return new DepartmentService(new GenericRepository<DepartmentEntity>(context));
        }
    }
}
