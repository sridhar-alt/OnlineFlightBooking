using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnilneFlightBooking.Entity
{
    public enum sex
    {
        male,
        female
    }
    public class UserEntity
    {
        public string Name { get; set; }
        [Key]
        public string Mobile { get; set; }
        public DateTime Dob { get; set; }
        public string Mail { get; set; }
        public sex Sex { get; set; }
        public string UserAddress { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public UserEntity()
        { }
    }
    
}
