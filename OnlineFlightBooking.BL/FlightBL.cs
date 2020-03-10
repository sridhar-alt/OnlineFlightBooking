using OnilneFlightBooking.Entity;
using OnlineFlightbooking.DAL;
using System.Collections.Generic;
namespace OnlineFlightBooking.BL
{
    public class FlightBL
    {
        public static IEnumerable<Flight> DisplayFlight()
        {
            IEnumerable<Flight> flightDetails = FlightRepository.DisplayFlight();
            return flightDetails;
        }
        public static void AddFlight(Flight flight)
        {
            FlightRepository.AddFlight(flight);
        }
        public static Flight GetDetails(int flightId)
        {
            Flight flight = FlightRepository.GetDetails(flightId);
            return flight;
        }
        public static void UpdateFlight(Flight flight)
        {
            FlightRepository.UpdateFlight(flight);
        }
        public static void DeleteFlight(Flight flight)
        {
            FlightRepository.DeleteFlight(flight);
        }
    }
}
