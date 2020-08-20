using Giprojivmash.DAL.Entities;
using Giprojivmash.WEB.Models;
using Giprojivmash.WEB.Models.Service;

namespace Giprojivmash.WEB.Mapper
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<BaseEntity, BaseViewModel>();
            CreateMap<ServiceFirstLayerEntity, ServiceFirstLayerViewModel>();
            CreateMap<ServiceSecondLayerEntity, ServiceSecondLayerViewModel>();
            CreateMap<ServiceThirdLayerEntity, ServiceThirdLayer>();
        }
    }
}
