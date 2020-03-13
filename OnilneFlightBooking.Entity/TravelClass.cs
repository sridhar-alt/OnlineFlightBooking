using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnilneFlightBooking.Entity
{
    public class TravelClass
    {
        [Key]
        [Required]
        public int ClassId { get; set; }
        [Required]
        public string ClassName { get; set; } 
    }
}
