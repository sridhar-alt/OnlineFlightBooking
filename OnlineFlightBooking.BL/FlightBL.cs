using OnilneFlightBooking.Entity;
using OnlineFlightbooking.DAL;
using System;
using System.Collections;
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
        public static Flight GetFlightDetails(int flightId)
        {
            Flight flight = FlightRepository.GetFlightDetails(flightId);
            return flight;
        }
        public static FlightTravelClass GetDetailsClass(int id)
        {
            return FlightRepository.GetDetailsClass(id);
        }
        public static void UpdateFlight(Flight flight)
        {
            FlightRepository.UpdateFlight(flight);
        }

        public static IEnumerable<FlightTravelClass> DisplayClass(int flightId)
        {
            return FlightRepository.DisplayClass(flightId);
        }

        public static void DeleteFlight(Flight flight)
        {
            FlightRepository.DeleteFlight(flight);
        }

        public static IEnumerable<TravelClass> GetTravelClass()
        {
            return FlightRepository.GetTravelClass();
        }

        public static void CreateClass(FlightTravelClass create)
        {
            FlightRepository.CreateClass(create);
        }

        public static void EditClass(FlightTravelClass flightTravelClass)
        {
            FlightRepository.EditClass(flightTravelClass);
        }

        public static void DeleteFlightTravelClass(FlightTravelClass flightTravelClass)
        {
            FlightRepository.DeleteFlightTravelClass(flightTravelClass);
        }
    }
}
