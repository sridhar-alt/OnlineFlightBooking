using OnilneFlightBooking.Entity;
using System.Data.Entity;

namespace OnlineFlightbooking.DAL
{
    public class UserContext: DbContext
    {
        public UserContext():base("DBConnection")
        {

        }
        public DbSet<User> UserEntity { get; set; }
        public DbSet<Flight> FlightEntity { get; set; }
    }
}
