using FlightMVC.Models;
using OnilneFlightBooking.Entity;
using OnlineFlightbooking.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlightMVC.Controllers
{
    public class FlightController : Controller
    {
        // GET: Flight
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Displayflight()
        {
            IEnumerable<FlightEntity> flights = FlightRepository.DisplayFlight();
            return View(flights);
        }
        [HttpGet]
        public ActionResult AddFlight()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddFlight(FlightModel add)
        {
            FlightEntity flight = new FlightEntity();
            flight.Flight_Id = add.Flight_Id;
            flight.FlightName = add.FlightName;
            flight.FromLocation = add.FromLocation;
            flight.ArrivalTime = add.ArrivalTime;
            flight.Duration = add.Duration;
            flight.ToLocation = add.ToLocation;
            flight.TotalSeat = add.TotalSeat;
            FlightRepository.AddFlight(flight);
            return View();
        }
        //public ActionResult EditFlight(int Id)
        //{
        //        FlightEntity flight = FlightRepository.GetDetails(Id);
        //        return View(flight);
        //}
        //[HttpPost]
        //public ActionResult EditFlight(FlightModel edit)
        //{
        //    return RedirectToAction("Displayflight");
        //}
        //public ActionResult DeleteFlight(int flightId)
        //{
        //    FlightEntity flight=FlightRepository.GetDetails(flightId);

        //    return View(flight);
        //}
    }
}