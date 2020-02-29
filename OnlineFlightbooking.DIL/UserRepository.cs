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
            List<UserEntity> userList = userContext.UserEntity.ToList();
            foreach(var value in userList)
            {
                if(user.Mobile==value.Mobile&& user.Password==value.Password)
                {
                    return value.Role;
                }
            }
            return "NotFound";
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
