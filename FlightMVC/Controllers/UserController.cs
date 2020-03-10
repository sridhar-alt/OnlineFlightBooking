using OnilneFlightBooking.Entity;
using System.Web.Mvc;
using OnlineFlightBooking.Models;
using OnlineFlightBooking.BL;
using System.Collections.Generic;

namespace OnlineFlightBooking.Controllers
{
    [HandleError]
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(SignUpModel signUp)
        {
            if (ModelState.IsValid)
            {
                var user = AutoMapper.Mapper.Map<SignUpModel, User>(signUp);
                UserBL.RegisterUser(user);
                TempData["message"] = "registered successfull..";
                return RedirectToAction("SignIn");
            }
            return View();
        }
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
            //throw new Exception("Error have been occured..");
        }
        [HttpPost]
        public ActionResult SignIn(SignInModel signIn)
        {
            if (ModelState.IsValid)
            {
                var user= AutoMapper.Mapper.Map<SignInModel, User>(signIn);
                string role= UserBL.ValidateLogin(user);
                if (role =="admin" )
                {
                    TempData["message"]= "Admin Login successfull";
                    return RedirectToAction("Displayflight","Flight");
                }
                else if (role =="User")
                {
                    TempData["message"] = "user Login successfull";
                    return RedirectToAction("UserDisplay","User");
                }
                TempData["message"] = "Incorrect mobile number or password";
            }
            return View();
        }
        [HttpGet]
        public ActionResult UserDisplay()
        {
            IEnumerable<Flight> flights = FlightBL.DisplayFlight();
            return View(flights);
        }
    }
}