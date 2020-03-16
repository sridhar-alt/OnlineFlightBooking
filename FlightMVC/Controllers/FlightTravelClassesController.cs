using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using OnilneFlightBooking.Entity;
using OnlineFlightbooking.DAL;
using OnlineFlightBooking.BL;
using OnlineFlightBooking.Models;

namespace OnlineFlightBooking.Controllers
{
    public class FlightTravelClassesController : Controller
    {

        // GET: FlightTravelClasses
        public ActionResult DisplayClass()
        {
            int flightId = Convert.ToInt32(TempData["FlightId"]);
            IEnumerable<FlightTravelClass> TravelClass = FlightBL.DisplayClass(flightId);
            return View(TravelClass);
        }
        // GET: FlightTravelClasses/GetTravelClass
        [HttpGet]
        public ActionResult CreateClass()
        {
            FlightTravelClass flightTravelClass = new FlightTravelClass();
            flightTravelClass.FlightId = Convert.ToInt32(TempData["FlightId"]);
            ViewBag.ClassId = new SelectList(FlightBL.GetTravelClass(),"ClassId", "ClassName");
            FlightTravelClassModel flightTravelClassModel= AutoMapper.Mapper.Map<FlightTravelClass, FlightTravelClassModel>(flightTravelClass);
            return View(flightTravelClassModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateClass( FlightTravelClassModel flightTravelClassModel)
        {
            if (ModelState.IsValid)
            {
                FlightTravelClass create = AutoMapper.Mapper.Map<FlightTravelClassModel,FlightTravelClass>(flightTravelClassModel);
                FlightBL.CreateClass(create);
                TempData["FlightId"] = create.FlightId;
                return RedirectToAction("DisplayFlight","Flight");
            }
            ViewBag.Class_Id = new SelectList(FlightBL.GetTravelClass(), "ClassId", "ClassName", flightTravelClassModel.ClassId);
            return View(flightTravelClassModel);
        }
        [HttpGet]
        // GET: FlightTravelClasses/Edit/5
        public ActionResult EditClass(int id)
        {
            FlightTravelClass flightTravelClass =FlightBL.GetDetailsClass(id);
            ViewBag.ClassId = new SelectList(FlightBL.GetTravelClass(), "ClassId", "ClassName");
            FlightTravelClassModel flightTravelClassModel = AutoMapper.Mapper.Map<FlightTravelClass, FlightTravelClassModel>(flightTravelClass);
            return View(flightTravelClassModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditClass(FlightTravelClass flightTravelClass)
        {
            if (ModelState.IsValid)
            {
                FlightBL.EditClass(flightTravelClass);
                return RedirectToAction("DisplayFlight","Flight");
            }
            ViewBag.Flight_Id = new SelectList(FlightBL.DisplayFlight(), "FlightId", "FlightName", flightTravelClass.FlightId);
            ViewBag.Class_Id = new SelectList(FlightBL.GetTravelClass(), "ClassId", "ClassName", flightTravelClass.ClassId);
            return View(flightTravelClass);
        }

        [HttpGet]
        // GET: FlightTravelClasses/Delete/5
        public ActionResult DeleteClass(int id)
        {
            FlightTravelClass flightTravelClass = FlightBL.GetDetailsClass(id);
            FlightTravelClassModel delete = AutoMapper.Mapper.Map<FlightTravelClass,FlightTravelClassModel>(flightTravelClass);
            return View(delete);
        }

        // POST: FlightTravelClasses/Delete/5
        [HttpPost]
        public ActionResult DeleteClass(FlightTravelClassModel delete)
        {
            FlightTravelClass flightTravelClass = AutoMapper.Mapper.Map<FlightTravelClassModel, FlightTravelClass>(delete);
            FlightBL.DeleteFlightTravelClass(flightTravelClass);
            return RedirectToAction("DisplayFlight","Flight");
        }
    }
}
