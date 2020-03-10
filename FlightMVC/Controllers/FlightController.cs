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
        public ActionResult Displayflight()
        {
            IEnumerable<Flight> flights = FlightBL.DisplayFlight();
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
                var flight = AutoMapper.Mapper.Map<FlightModel, Flight>(add);
                FlightBL.AddFlight(flight);
                TempData["message"] = "Flight added successfully";
                return RedirectToAction("Displayflight");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditFlight(int Id)
        {
            Flight flight = FlightBL.GetDetails(Id);
            return View(flight);
        }
        [HttpPost]
        public ActionResult EditFlight(FlightModel edit)
        {
            if (ModelState.IsValid)
            {
                var flight=AutoMapper.Mapper.Map<FlightModel, Flight>(edit);
                FlightBL.UpdateFlight(flight);
                TempData["message"] = "Flight Updated successfully";
                return RedirectToAction("Displayflight");
            }
            return View();
        }
        [HttpGet]
        public ActionResult DeleteFlight(int Id)
        {
            Flight flight = FlightBL.GetDetails(Id);
            return View(flight);
        }
        [HttpPost]
        public ActionResult DeleteFlight(FlightModel delete)
        {
            var flight = AutoMapper.Mapper.Map<FlightModel, Flight>(delete);
            FlightBL.DeleteFlight(flight);
            TempData["message"] = "Flight deleted successfully";
            return RedirectToAction("Displayflight");
        }
    }
}