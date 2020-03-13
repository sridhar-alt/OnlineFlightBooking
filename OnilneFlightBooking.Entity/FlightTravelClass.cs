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
        public int FlightTravelClassId { get; set; }
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
        public int ClassId { get; set; }
        public TravelClass TravelClass { get; set; }
        public  int SeatCount { get; set; }
        public int SeatCost { get; set; }
    }
}
