using OnilneFlightBooking.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightMVC.Models
{
    public class MapConfig
    {
        public static void RegisterMap()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<SignUpModel, UserEntity>();
                config.CreateMap<SignInModel, UserEntity>();
                config.CreateMap<FlightModel, FlightEntity>();
            });
        }
    }
}