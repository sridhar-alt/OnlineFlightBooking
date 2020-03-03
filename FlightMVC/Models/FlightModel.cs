using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlightMVC.Models
{
    public class FlightModel
    {
        [Required]
        public int Flight_Id { get; set; }
        [Required(ErrorMessage = "Name required")]
        [StringLength(30, ErrorMessage = "Name cannot be longer than 30 characters.")]
        [RegularExpression(@"(^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$)", ErrorMessage = "Invalid flightId")]
        public string FlightName { get; set; }
        [Required(ErrorMessage = " From Location required")]
        [StringLength(30, ErrorMessage = "Name cannot be longer than 30 characters.")]
        [RegularExpression(@"(^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$)", ErrorMessage = "Invalid FlightName")]
        public string FromLocation { get; set; }
        [Required(ErrorMessage = "To Location required")]
        [StringLength(30, ErrorMessage = "Name cannot be longer than 30 characters.")]
        [RegularExpression(@"(^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$)", ErrorMessage = "Invalid ToLocation")]
        public string ToLocation { get; set; }
        [Required(ErrorMessage = "Arrivel Time required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm}")]
        public DateTime ArrivalTime { get; set; }
        [Required(ErrorMessage = "Dutation Time required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm}")]
        public DateTime Duration { get; set; }
        [Required(ErrorMessage = "Total seat required")]
        public int TotalSeat { get; set; }
    }
}