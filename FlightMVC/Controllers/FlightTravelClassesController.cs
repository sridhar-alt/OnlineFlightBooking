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
        private UserContext db = new UserContext();

        // GET: FlightTravelClasses
        public ActionResult DisplayClass()
        {
            int flightId = Convert.ToInt32(TempData["FlightId"]);
            IEnumerable<FlightTravelClass> TravelClass = FlightBL.DisplayClass(flightId);
            return View(TravelClass);
        }
        // GET: FlightTravelClasses/GetClass
        [HttpGet]
        public ActionResult CreateClass()
        {
            FlightTravelClass flightTravelClass = new FlightTravelClass();
            flightTravelClass.FlightId = Convert.ToInt32(TempData["FlightId"]);
            ViewBag.ClassId = new SelectList(FlightBL.GetClass(),"ClassId", "ClassName");
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
            ViewBag.Class_Id = new SelectList(FlightBL.GetClass(), "ClassId", "ClassName", flightTravelClassModel.ClassId);
            return View(flightTravelClassModel);
        }

        // GET: FlightTravelClasses/Edit/5
        public ActionResult EditClass(int id)
        {
            FlightTravelClass flightTravelClass =FlightBL.GetDetailsClass(id);
            ViewBag.ClassId = new SelectList(FlightBL.GetClass(), "ClassId", "ClassName");
            FlightTravelClassModel flightTravelClassModel = AutoMapper.Mapper.Map<FlightTravelClass, FlightTravelClassModel>(flightTravelClass);
            return View(flightTravelClassModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditClass(FlightTravelClass flightTravelClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flightTravelClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DisplayFlight","Flight");
            }
            ViewBag.Flight_Id = new SelectList(db.FlightEntity, "FlightId", "FlightName", flightTravelClass.FlightId);
            ViewBag.Class_Id = new SelectList(db.TravelClasses, "ClassId", "ClassName", flightTravelClass.ClassId);
            return View(flightTravelClass);
        }

        // GET: FlightTravelClasses/Delete/5
        public ActionResult DeleteClass(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightTravelClass flightTravelClass = db.FlightTravelClasses.Find(id);
            if (flightTravelClass == null)
            {
                return HttpNotFound();
            }
            return View(flightTravelClass);
        }

        // POST: FlightTravelClasses/Delete/5
        [HttpPost, ActionName("DeleteClass")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FlightTravelClass flightTravelClass = db.FlightTravelClasses.Find(id);
            db.FlightTravelClasses.Remove(flightTravelClass);
            db.SaveChanges();
            return RedirectToAction("DisplayClass");
        }
    }
}
