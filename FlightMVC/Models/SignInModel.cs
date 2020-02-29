using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlightMVC.Models
{
    public class SignInModel
    {
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string Password { get; set; }
    }
}