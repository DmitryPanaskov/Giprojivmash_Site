using Giprojivmash.BLL.DTO;
using Giprojivmash.DAL.Entities;

namespace Giprojivmash.BLL.Mapper
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<ServiceFirstLayerEntity, ServiceFirstLayerDto>();
            CreateMap<ServiceSecondLayerEntity, ServiceSecondLayerDto>();
            CreateMap<ServiceThirdLayerEntity, ServiceThirdLayerDto>();
        }
    }
}
