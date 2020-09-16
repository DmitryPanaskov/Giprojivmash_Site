using Giprojivmash.DAL.Entities;
using Giprojivmash.WEB.Models;
using Giprojivmash.WEB.Models.About;
using Giprojivmash.WEB.Models.Contact;

namespace Giprojivmash.WEB.Mapper
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<BaseEntity, BaseViewModel>();
            CreateMap<ContactEntity, ContactViewModel>();
            CreateMap<ContactDataEntity, ContactDataViewModel>();
            CreateMap<VacancyEntity, VacancyViewModel>();
        }
    }
}
