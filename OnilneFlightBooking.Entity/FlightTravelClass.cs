using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnilneFlightBooking.Entity
{
    public class FlightTravelClass
    {
        [Key]
        public int FlightTravelClass_Id { get; set; }
        public int Flight_Id { get; set; }
        public Flight Flight { get; set; }
        public int Class_Id { get; set; }
        public TravelClass TravelClass { get; set; }
        public  int SeatCount { get; set; }
        public int SeatCost { get; set; }
    }
}
