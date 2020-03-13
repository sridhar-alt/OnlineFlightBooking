﻿using OnilneFlightBooking.Entity;
using System.Data.Entity;

namespace OnlineFlightbooking.DAL
{
    public class UserContext : DbContext
    {
        public UserContext() : base("DBConnection")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .MapToStoredProcedures(p => p.Insert(sp => sp.HasName("sp_InsertUser"))
                .Update(sp => sp.HasName("sp_UpdateUser"))
                .Delete(sp => sp.HasName("sp_DeleteUser"))
                );
        }
        public DbSet<User> UserEntity { get; set; }
        public DbSet<Flight> FlightEntity { get; set; }
        public DbSet<FlightTravelClass> FlightTravelClasses{get;set;}
        public DbSet<TravelClass> TravelClasses { get; set; }
    }
}
