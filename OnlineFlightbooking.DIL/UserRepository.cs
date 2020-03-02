using OnilneFlightBooking.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace OnlineFlightbooking.DAL
{
    public class UserRepository
    {
        public static List<UserEntity>RegisterUser()
        {
            UserContext userContext = new UserContext();
            return userContext.UserEntity.ToList();
        }
        public static void RegisterUser(UserEntity user)
        {
            UserContext userContext = new UserContext();
            userContext.UserEntity.Add(user);
            userContext.SaveChanges();
        }
        public static string ValidateLogin(UserEntity user)
        {
            UserContext userContext = new UserContext();
            UserEntity userDb = userContext.UserEntity.Where(model => model.Mobile == user.Mobile).Where(model=>model.Password==user.Password).SingleOrDefault();
            if (userDb!=null)
            {
                return userDb.Role;
            }
            else
            {
                return "NotFound";
            }
        }

        //public static DataTable ViewFlightDetails()
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        //    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        //    {
        //        sqlConnection.Open();
        //        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from flightdb", sqlConnection);
        //        DataTable dataTable = new DataTable();
        //        sqlDataAdapter.Fill(dataTable);
        //        return dataTable;
        //    }
        //}
    }
}
