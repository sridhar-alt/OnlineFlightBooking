using OnilneFlightBooking.Entity;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace OnlineFlightbooking.DAL
{
    public class FlightRepository
    {
        public static List<Flight> FlightList()
        {
            UserContext userContext = new UserContext();
            return userContext.FlightEntity.ToList();
        }
        public static IEnumerable<Flight> DisplayFlight()
        {
            UserContext userContext = new UserContext();
            List<Flight> flightDetails = userContext.FlightEntity.ToList();
            return flightDetails;
        }
        public static void AddFlight(Flight flight)
        {
            UserContext userContext = new UserContext();
            userContext.FlightEntity.Add(flight);
            userContext.SaveChanges();
        }
        public static Flight GetDetails(int flightId)
        {
            UserContext userContext = new UserContext();
            Flight flight = userContext.FlightEntity.Where(model => model.Flight_Id == flightId).SingleOrDefault();
            return flight;
        }

        public static void UpdateFlight(Flight flight)
        {
            UserContext userContext = new UserContext();
            userContext.Entry(flight).State = EntityState.Modified;
            int change = userContext.SaveChanges();
        }

        public static void DeleteFlight(Flight flight)
        {
            UserContext userContext = new UserContext();
            Flight flightEntity = userContext.FlightEntity.Where(model => model.Flight_Id == flight.Flight_Id).SingleOrDefault();
            userContext.FlightEntity.Attach(flightEntity);
            userContext.FlightEntity.Remove(flightEntity);
            userContext.SaveChanges();
        }
    }
}
