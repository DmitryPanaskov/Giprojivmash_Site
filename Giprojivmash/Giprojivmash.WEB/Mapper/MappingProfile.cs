using Giprojivmash.DAL.Entities;
using Giprojivmash.WEB.Models;

namespace Giprojivmash.WEB.Mapper
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<ServiceFirstLayerViewModel, ServiceFirstLayerEntity>().ReverseMap();
            CreateMap<ServiceSecondLayerViewModel, ServiceSecondLayerEntity>().ReverseMap();
            CreateMap<ServiceThirdLayerViewModel, ServiceThirdLayerEntity>().ReverseMap();
        }
    }
}
