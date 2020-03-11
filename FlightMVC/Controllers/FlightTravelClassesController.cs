using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnilneFlightBooking.Entity;
using OnlineFlightbooking.DAL;
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
            var flightTravelClasses = db.FlightTravelClasses.Where(x => x.Flight_Id == flightId).Include(f => f.Flight).Include(f => f.TravelClass);
            return View(flightTravelClasses.ToList());
        }
        // GET: FlightTravelClasses/CreateClass
        public ActionResult CreateClass()
        {
            FlightTravelClass flightTravelClass = new FlightTravelClass();
            flightTravelClass.Flight_Id = Convert.ToInt32(TempData["FlightId"]);
            ViewBag.Class_Id = new SelectList(db.TravelClasses, "Class_Id", "ClassName");
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
                db.FlightTravelClasses.Add(create);
                db.SaveChanges();
                TempData["FlightId"] = create.Flight_Id;
                return RedirectToAction("Displayflight","Flight");
            }
            ViewBag.Class_Id = new SelectList(db.TravelClasses, "Class_Id", "ClassName", flightTravelClassModel.Class_Id);
            return View(flightTravelClassModel);
        }

        // GET: FlightTravelClasses/Edit/5
        public ActionResult EditClass(int? id)
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
            ViewBag.Flight_Id = new SelectList(db.FlightEntity, "Flight_Id", "FlightName", flightTravelClass.Flight_Id);
            ViewBag.Class_Id = new SelectList(db.TravelClasses, "Class_Id", "ClassName", flightTravelClass.Class_Id);
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
                return RedirectToAction("DisplayClass");
            }
            ViewBag.Flight_Id = new SelectList(db.FlightEntity, "Flight_Id", "FlightName", flightTravelClass.Flight_Id);
            ViewBag.Class_Id = new SelectList(db.TravelClasses, "Class_Id", "ClassName", flightTravelClass.Class_Id);
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
