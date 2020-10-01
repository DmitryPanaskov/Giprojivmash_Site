using Giprojivmash.BLL.Interfaces;
using Giprojivmash.BLL.Services;
using Giprojivmash.DAL.Context;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DAL.Repositories;

namespace GiprojivmashIntegrationTests
{
    public static class ServiceInitializer
    {
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

        public static IUserService GetUser(GiprojivmashContext context)
        {
            return new UserService(new IdentityRepository(context));
        }
    }
}
