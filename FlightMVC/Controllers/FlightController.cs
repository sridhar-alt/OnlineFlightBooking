using OnlineFlightBooking.Models;
using OnilneFlightBooking.Entity;
using System.Collections.Generic;
using System.Web.Mvc;
using OnlineFlightBooking.BL;

namespace OnlineFlightBooking.Controllers
{
    //[Authorize(Roles ="admin")]
    public class FlightController : Controller
    {
        // GET: Flight
        public ActionResult DisplayFlight()
        {
            IEnumerable<Flight> flights = FlightBL.DisplayFlight();
            List<FlightModel> flightModels = new List<FlightModel>();
            foreach(var flight in flights)
            {
                FlightModel flightModel = AutoMapper.Mapper.Map<Flight, FlightModel>(flight);
                flightModels.Add(flightModel);
            }
            return View(flightModels);
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
                Flight flight = AutoMapper.Mapper.Map<FlightModel, Flight>(add);
                FlightBL.AddFlight(flight);
                TempData["message"] = "Flight added successfully";
                TempData["FlightId"] = flight.FlightId;
                return RedirectToAction("CreateClass", "FlightTravelClasses");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditFlight(int Id)
        {
            Flight flight = FlightBL.GetFlightDetails(Id); 
            FlightModel flightModel = AutoMapper.Mapper.Map<Flight,FlightModel>(flight);
            return View(flightModel);
        }
        [HttpPost]
        public ActionResult EditFlight(FlightModel edit)
        {
            if (ModelState.IsValid)
            {
                Flight flight=AutoMapper.Mapper.Map<FlightModel, Flight>(edit);
                FlightBL.UpdateFlight(flight);
                TempData["message"] = "Flight Updated successfully";
                TempData["FlightId"] = flight.FlightId;
                return RedirectToAction("DisplayClass", "FlightTravelClasses");
            }
            return View();
        }
        [HttpGet]
        public ActionResult DeleteFlight(int Id)
        {
            Flight flight = FlightBL.GetFlightDetails(Id);
            FlightModel flightModel = AutoMapper.Mapper.Map<Flight, FlightModel>(flight);
            return View(flightModel);
        }
        [HttpPost]
        public ActionResult DeleteFlight(FlightModel delete)
        {
            Flight flight = AutoMapper.Mapper.Map<FlightModel, Flight>(delete);
            FlightBL.DeleteFlight(flight);
            TempData["message"] = "Flight deleted successfully";
            return RedirectToAction("DisplayFlight");
        }
    }
}