using OnilneFlightBooking.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineFlightBooking.Models
{
    public class MapConfig
    {
        public static void RegisterMap()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<SignUpModel, User>();
                config.CreateMap<SignInModel, User>();
                config.CreateMap<FlightModel, Flight>();
                config.CreateMap<FlightTravelClassModel, FlightTravelClass>();
            });
        }
    }
}