using System;
using OnilneFlightBooking.Entity;
using OnlineFlightbooking.DAL;

namespace OnlineFlightBooking.BL
{
    public class UserBL
    {
        public static void RegisterUser(User user)
        {
            UserRepository.RegisterUser(user);
        }
        public static string ValidateLogin(User user)
        {
            return UserRepository.ValidateLogin(user);
        }
    }
}
