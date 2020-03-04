using OnilneFlightBooking.Entity;
using System.Web.Mvc;
using OnlineFlightbooking.DAL;
using System.Collections.Generic;
using System;
using FlightMVC.Models;

namespace FlightMVC.Controllers
{
    [HandleError]
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult SignUp()
        {
            IEnumerable<UserEntity> con = UserRepository.RegisterUser();
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(SignUpModel signUp)
        {
            if (ModelState.IsValid)
            {
                var user = AutoMapper.Mapper.Map<SignUpModel, UserEntity>(signUp);
                UserRepository.RegisterUser(user);
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
                var user= AutoMapper.Mapper.Map<SignInModel, UserEntity>(signIn);
                string role= UserRepository.ValidateLogin(user);
                if (role =="admin" )
                {
                    TempData["message"]= "Admin Login successfull";
                    return RedirectToAction("DisplayFlight","Flight");
                }
                else if (role =="user")
                {
                    TempData["message"] = "user Login successfull";
                    return RedirectToAction("UserDisplay");
                }
                TempData["message"] = "Incorrect mobile number or password";
            }
            return View();
        }
        [HttpGet]
        public ActionResult UserDisplay()
        {
            return View();
        }
    }
}