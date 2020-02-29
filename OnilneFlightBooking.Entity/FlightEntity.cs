using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnilneFlightBooking.Entity
{
    public class FlightEntity
    {
        [Key]
        public int Flight_Id { get; set; }
        public string FlightName { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime Duration { get; set; }
        public int TotalSeat { get; set; }
    }
}
