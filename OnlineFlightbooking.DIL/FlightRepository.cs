using OnilneFlightBooking.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace OnlineFlightbooking.DAL
{
    public class FlightRepository
    {
        public static List<FlightEntity> List()
        {
            UserContext userContext = new UserContext();
            return userContext.FlightEntity.ToList();
        }
        public static IEnumerable<FlightEntity> DisplayFlight()
        {
            UserContext userContext = new UserContext();
            List<FlightEntity> flightDetails = userContext.FlightEntity.ToList();
            return flightDetails;
        }
        public static void AddFlight(FlightEntity flight)
        {
            UserContext userContext = new UserContext();
            userContext.FlightEntity.Add(flight);
            userContext.SaveChanges();
        }
        public static FlightEntity GetDetails(int flightId)
        {
            UserContext userContext = new UserContext();
            FlightEntity flight = userContext.FlightEntity.Where(model => model.Flight_Id == flightId).SingleOrDefault();
            return flight;
        }

        public static void UpdateFlight(FlightEntity flight)
        {
            UserContext userContext = new UserContext();
            userContext.Entry(flight).State = EntityState.Modified;
            int change = userContext.SaveChanges();
        }

        public static void DeleteFlight(FlightEntity flight)
        {
            UserContext userContext = new UserContext();
            FlightEntity flightEntity = userContext.FlightEntity.Where(model => model.Flight_Id == flight.Flight_Id).SingleOrDefault();
            userContext.FlightEntity.Attach(flightEntity);
            userContext.FlightEntity.Remove(flightEntity);
            userContext.SaveChanges();
        }
    }
}
