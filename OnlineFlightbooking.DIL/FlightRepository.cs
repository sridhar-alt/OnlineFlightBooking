using OnilneFlightBooking.Entity;
using OnlineFlightbooking.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //public static void DeleteFlight(int id)
        //{
        //    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            sqlConnection.Open();
        //            SqlCommand sqlCommand = new SqlCommand("SP_DELETE_FLIGHTDETAILS", sqlConnection);
        //            sqlCommand.CommandType = CommandType.StoredProcedure;
        //            SqlParameter param = new SqlParameter("@FLIGHTID", id);
        //            sqlCommand.Parameters.Add(param);
        //            sqlCommand.ExecuteNonQuery();
        //        }
        //        catch (Exception)
        //        {
        //        }
        //        finally
        //        {
        //            sqlConnection.Close();
        //        }
        //    }
        //}

        //public static void UpdateFlight(int id, string flightName, string flightNumber)
        //{
        //    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            sqlConnection.Open();
        //            SqlCommand sqlCommand = new SqlCommand("SP_UPDATE_FLIGHTDB", sqlConnection);
        //            sqlCommand.CommandType = CommandType.StoredProcedure;
        //            sqlCommand.Parameters.AddWithValue("@FLIGHTID", id);
        //            sqlCommand.Parameters.AddWithValue("@FLIGHTNAME", flightName);
        //            sqlCommand.Parameters.AddWithValue("@FLIGHTNUMBER", flightNumber);
        //            int i = sqlCommand.ExecuteNonQuery();
        //        }
        //        catch (Exception)
        //        {
        //        }
        //        finally
        //        {
        //            sqlConnection.Close();
        //        }
        //    }
        //}

    }
}
