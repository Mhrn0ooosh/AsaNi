using AsaNi.DomainClasses;
using AsaNi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace AsaNi.Helper
{
    public static class ObjectAutoMapper
    {
        public static OperateHouseViewModel MapToOperateHouseViewModel(House foundHouse)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<House, OperateHouseViewModel>();
                cfg.CreateMap<Owner, OwnerViewModel>();
            });

            var mapper = config.CreateMapper();
            var operateHouseViewModel = mapper.Map<OperateHouseViewModel>(foundHouse);
            return operateHouseViewModel;
        }
        public static House MapToHouse(OperateHouseViewModel operateHouseViewModel)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OperateHouseViewModel, House>();
                cfg.CreateMap<OwnerViewModel,Owner>();
            });
            var mapper = config.CreateMapper();
            var house = mapper.Map<House>(operateHouseViewModel);
            return house;
        }
    }
}
