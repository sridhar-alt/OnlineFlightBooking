using OnilneFlightBooking.Entity;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace OnlineFlightbooking.DAL
{
    public class UserRepository
    {
        public static void RegisterUser(User user)
        {
            using (UserContext userContext = new UserContext())
            {
                using (var transaction = userContext.Database.BeginTransaction())
                {
                    try
                    {
                        SqlParameter mobile = new SqlParameter("@Mobile", user.Mobile);
                        SqlParameter name = new SqlParameter("@Name", user.Name);
                        SqlParameter Dob = new SqlParameter("@Dob", user.Dob);
                        SqlParameter mail = new SqlParameter("@Mail", user.Mail);
                        SqlParameter sex = new SqlParameter("@Sex", user.Sex);
                        SqlParameter userAddress = new SqlParameter("@UserAddress", user.UserAddress);
                        SqlParameter password = new SqlParameter("@Password", user.Password);
                        SqlParameter role = new SqlParameter("@Role", user.Role);
                        int result = userContext.Database.ExecuteSqlCommand("sp_InsertUser @Mobile,@Name,@Dob,@Mail,@Sex,@UserAddress,@Password,@Role", mobile, name, Dob, mail, sex, userAddress, password, role);
                        transaction.Commit();
                    }
                    catch(Exception)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }
        public static string ValidateLogin(User user)
        {
            using (UserContext userContext = new UserContext())
            {
                User userDb = userContext.UserEntity.Where(model => model.Mobile == user.Mobile).Where(model => model.Password == user.Password).SingleOrDefault();
                if (userDb != null)
                {
                    return userDb.Role;
                }
                else
                {
                    return "NotFound";
                }
            }
        }

    }
}
