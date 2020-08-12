using Giprojivmash.BLL.DTO;
using Giprojivmash.WEB.Models;

namespace Giprojivmash.WEB.Mapper
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<BaseDto, BaseViewModel>();
            CreateMap<ServiceFirstLayerDto, ServiceFirstLayerViewModel>();
            CreateMap<ServiceSecondLayerDto, ServiceSecondLayerViewModel>();
            CreateMap<ServiceThirdLayerDto, ServiceThirdLayerViewModel>();
        }
    }
}
