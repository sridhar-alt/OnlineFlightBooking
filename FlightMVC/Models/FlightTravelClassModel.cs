using OnilneFlightBooking.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineFlightBooking.Models
{
    public class FlightTravelClassModel
    {
        public int FlightTravelClass_Id { get; set; }
        [Required(ErrorMessage = "Flight id required")]
        public int Flight_Id { get; set; }
        [Required(ErrorMessage = "class id required")]
        public int Class_Id { get; set; }
        [Required(ErrorMessage = "seat count required")]
        public int SeatCount { get; set; }
        [Required(ErrorMessage = "seat cost required")]
        public int SeatCost { get; set; }
    }
}