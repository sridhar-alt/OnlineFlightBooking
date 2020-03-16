using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineFlightBooking.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage = "Phone number required")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }
    }
}