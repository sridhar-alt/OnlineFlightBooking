using OnilneFlightBooking.Entity;
using System;
using System.Collections;
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
            using (UserContext userContext = new UserContext())
            {
                return userContext.FlightEntity.ToList();
            }
        }
        public static IEnumerable<Flight> DisplayFlight()
        {
            using (UserContext userContext = new UserContext())
            {
                List<Flight> flightDetails = userContext.FlightEntity.ToList();
                return flightDetails;
            }
        }
        public static void AddFlight(Flight flight)
        {
            using (UserContext userContext = new UserContext())
            {
                userContext.FlightEntity.Add(flight);
                userContext.SaveChanges();
            }
        }
        public static IEnumerable<FlightTravelClass> DisplayClass(int flightId)
        {

            using (UserContext userContext = new UserContext())
            {
                List<FlightTravelClass> TravelClass=userContext.FlightTravelClasses.Where(x => x.FlightId == flightId).Include(f => f.Flight).Include(f => f.TravelClass).ToList();
                return TravelClass;
            }
        }
        public static void CreateClass(FlightTravelClass create)
        {
            using (UserContext userContext = new UserContext())
            {
                userContext.FlightTravelClasses.Add(create);
                userContext.SaveChanges();
            }
        }
        public static void EditClass(FlightTravelClass flightTravelClass)
        {
            using (UserContext userContext = new UserContext())
            {
                userContext.Entry(flightTravelClass).State = EntityState.Modified;
                userContext.SaveChanges();
            }
        }
        public static void DeleteFlightTravelClass(FlightTravelClass deleteClass)
        {
            using(UserContext userContext=new UserContext())
            {
                FlightTravelClass flightTravelClass = userContext.FlightTravelClasses.Where(model => model.FlightTravelClassId == deleteClass.FlightTravelClassId).SingleOrDefault();
                userContext.FlightTravelClasses.Attach(flightTravelClass);
                userContext.FlightTravelClasses.Remove(flightTravelClass);
                userContext.SaveChanges();
            }
        }

        public static IEnumerable<TravelClass> GetTravelClass()
        {
            using (UserContext userContext = new UserContext())
            {
                List<TravelClass> classes= userContext.TravelClasses.ToList();
                return classes;
            }
        }

        public static FlightTravelClass GetDetailsClass(int id)
        {
            using (UserContext userContext = new UserContext())
            {
                FlightTravelClass classes = userContext.FlightTravelClasses.Where(model => model.FlightTravelClassId == id).SingleOrDefault();
                return classes;
            }
        }
        public static Flight GetFlightDetails(int flightId)
        {
            using (UserContext userContext = new UserContext())
            {
                Flight flight = userContext.FlightEntity.Where(model => model.FlightId == flightId).SingleOrDefault();
                return flight;
            }
        }

        public static void UpdateFlight(Flight flight)
        {
            using (UserContext userContext = new UserContext())
            {
                userContext.Entry(flight).State = EntityState.Modified;
                int change = userContext.SaveChanges();
            }
        }

        public static void DeleteFlight(Flight flight)
        {
            using (UserContext userContext = new UserContext())
            {
                Flight flightEntity = userContext.FlightEntity.Where(model => model.FlightId == flight.FlightId).SingleOrDefault();
                userContext.FlightEntity.Attach(flightEntity);
                userContext.FlightEntity.Remove(flightEntity);
                userContext.SaveChanges();
            }
        }

    }
}
