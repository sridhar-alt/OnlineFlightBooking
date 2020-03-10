using OnilneFlightBooking.Entity;
using System.Linq;

namespace OnlineFlightbooking.DAL
{
    public class UserRepository
    {
        public static void RegisterUser(User user)
        {
            UserContext userContext = new UserContext();
            userContext.UserEntity.Add(user);
            userContext.SaveChanges();
        }
        public static string ValidateLogin(User user)
        {
            UserContext userContext = new UserContext();
            User userDb = userContext.UserEntity.Where(model => model.Mobile == user.Mobile).Where(model=>model.Password==user.Password).SingleOrDefault();
            if (userDb!=null)
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
