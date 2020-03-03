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
                UserEntity user = new UserEntity();
                user.Name = signUp.Name;
                user.Dob = signUp.Dob;
                user.Mobile = signUp.Mobile;
                user.Sex = signUp.Sex;
                user.Role = "user";
                user.Mail = signUp.Mail;
                user.UserAddress = signUp.UserAddress;
                user.Password = signUp.Password;
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
                UserEntity user = new UserEntity();
                user.Mobile = signIn.Mobile;
                user.Password = signIn.Password;
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