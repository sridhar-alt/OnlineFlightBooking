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
                var flight = AutoMapper.Mapper.Map<FlightModel, FlightEntity>(add);
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
                var flight=AutoMapper.Mapper.Map<FlightModel, FlightEntity>(edit);
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
            var flight = AutoMapper.Mapper.Map<FlightModel, FlightEntity>(delete);
            FlightRepository.DeleteFlight(flight);
            TempData["message"] = "Flight deleted successfully";
            return RedirectToAction("Displayflight");
        }
    }
}