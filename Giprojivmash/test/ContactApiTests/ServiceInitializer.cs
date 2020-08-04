using Giprojivmash.BLL.Interfaces;
using Giprojivmash.BLL.Services;
using Giprojivmash.DAL.Context;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DAL.Repositories;

namespace ContactApiTests
{
    public static class ServiceInitializer
    {
        public static IContactService GetContact(GiprojivmashContext context)
        {
            return new ContactService(new GenericRepository<ContactEntity>(context),
                new GenericRepository<ContactPhoneEntity>(context));
        }

        public static IContactPhoneService GetContactPhone(GiprojivmashContext context)
        {
            return new ContactPhoneService(new GenericRepository<ContactPhoneEntity>(context));
        }
    }
}
