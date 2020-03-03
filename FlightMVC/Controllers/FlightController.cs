using FlightMVC.Models;
using OnilneFlightBooking.Entity;
using OnlineFlightbooking.DAL;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FlightMVC.Controllers
{
    public class FlightController : Controller
    {
        // GET: Flight
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
            if (ModelState.IsValid)
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
                TempData["message"] = "Flight added successfully";
                return RedirectToAction("Displayflight");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditFlight(int Id)
        {
            FlightEntity flight = FlightRepository.GetDetails(Id);
            return View(flight);
        }
        [HttpPost]
        public ActionResult EditFlight(FlightModel edit)
        {
            if (ModelState.IsValid)
            {
                FlightEntity flight = new FlightEntity();
                flight.Flight_Id = edit.Flight_Id;
                flight.FlightName = edit.FlightName;
                flight.FromLocation = edit.FromLocation;
                flight.ArrivalTime = edit.ArrivalTime;
                flight.Duration = edit.Duration;
                flight.ToLocation = edit.ToLocation;
                flight.TotalSeat = edit.TotalSeat;
                FlightRepository.UpdateFlight(flight);
                TempData["message"] = "Flight Updated successfully";
                return RedirectToAction("Displayflight");
            }
            return View();
        }
        [HttpGet]
        public ActionResult DeleteFlight(int Id)
        {
            FlightEntity flight = FlightRepository.GetDetails(Id);
            return View(flight);
        }
        [HttpPost]
        public ActionResult DeleteFlight(FlightModel delete)
        {
            FlightEntity flight = new FlightEntity();
            flight.Flight_Id=delete.Flight_Id;
            FlightRepository.DeleteFlight(flight);
            TempData["message"] = "Flight deleted successfully";
            return RedirectToAction("Displayflight");
        }
    }
}