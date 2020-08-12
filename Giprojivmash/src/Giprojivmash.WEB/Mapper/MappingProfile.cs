﻿using Giprojivmash.DAL.Entities;
using Giprojivmash.WEB.Models;

namespace Giprojivmash.WEB.Mapper
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<BaseEntity, BaseViewModel>();
            CreateMap<ServiceFirstLayerEntity, ServiceFirstLayerViewModel>();
            CreateMap<ServiceSecondLayerEntity, ServiceSecondLayerViewModel>();
            CreateMap<ServiceThirdLayerEntity, ServiceThirdLayerViewModel>();
        }
    }
}
