﻿using OnilneFlightBooking.Entity;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace OnlineFlightbooking.DAL
{
    public class FlightRepository
    {
        public static List<Flight> FlightList()  //Returns the Flight list from the database
        {
            using (UserContext userContext = new UserContext())
            {
                return userContext.FlightEntity.ToList();
            }
        }
        public static IEnumerable<Flight> DisplayFlight()       //Returns the Flight list for display
        {
            using (UserContext userContext = new UserContext())
            {
                List<Flight> flightDetails = userContext.FlightEntity.ToList();
                return flightDetails;
            }
        }
        public static void AddFlight(Flight flight)         //To Add a flight details to the table from the Database
        {
            using (UserContext userContext = new UserContext())
            {
                userContext.FlightEntity.Add(flight);
                userContext.SaveChanges();
            }
        }
        public static IEnumerable<FlightTravelClass> DisplayClass(int flightId)     //Returns the FlightTravelClass Result based on the FlightId and the  flightName and the Travel Class from the DataBase
        {

            using (UserContext userContext = new UserContext())
            {
                List<FlightTravelClass> TravelClass=userContext.FlightTravelClasses.Where(x => x.FlightId == flightId).Include(f => f.Flight).Include(f => f.TravelClass).ToList();
                return TravelClass;
            }
        }
        public static void CreateClass(FlightTravelClass create)        //Add new FlightTravelClass to the table in the DataBase
        {
            using (UserContext userContext = new UserContext())
            {
                userContext.FlightTravelClasses.Add(create);
                userContext.SaveChanges();
            }
        }
        public static void EditClass(FlightTravelClass flightTravelClass)   //Edit the FlightTravelClass in the table 
        {
            using (UserContext userContext = new UserContext())
            {
                userContext.Entry(flightTravelClass).State = EntityState.Modified;
                userContext.SaveChanges();
            }
        }
        public static void DeleteFlightTravelClass(FlightTravelClass deleteClass)       //Delete the FlightTravelClass in the table
        {
            using(UserContext userContext=new UserContext())
            {
                FlightTravelClass flightTravelClass = userContext.FlightTravelClasses.Where(model => model.FlightTravelClassId == deleteClass.FlightTravelClassId).SingleOrDefault();
                userContext.FlightTravelClasses.Attach(flightTravelClass);
                userContext.FlightTravelClasses.Remove(flightTravelClass);
                userContext.SaveChanges();
            }
        }

        public static IEnumerable<TravelClass> GetTravelClass()         //return the travelclass list from the DataBase 
        {
            using (UserContext userContext = new UserContext())
            {
                List<TravelClass> classes= userContext.TravelClasses.ToList();
                return classes;
            }
        }

        public static FlightTravelClass GetDetailsClass(int id)         //return the FlightTravelClass Value Based on the FlightTravelClass Id 
        {
            using (UserContext userContext = new UserContext())
            {
                FlightTravelClass classes = userContext.FlightTravelClasses.Where(model => model.FlightTravelClassId == id).SingleOrDefault();
                return classes;
            }
        }
        public static Flight GetFlightDetails(int flightId)
        {
            using (UserContext userContext = new UserContext())     //return the Flight Value Based on the Flight Id 
            {
                Flight flight = userContext.FlightEntity.Where(model => model.FlightId == flightId).SingleOrDefault();
                return flight;
            }
        }

        public static void UpdateFlight(Flight flight)      //Modify the flight details in the table flight
        {
            using (UserContext userContext = new UserContext())
            {
                userContext.Entry(flight).State = EntityState.Modified;
                int change = userContext.SaveChanges();
            }
        }

        public static void DeleteFlight(Flight flight)          //Delete the flight details based on the flightId in the table Flight
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
