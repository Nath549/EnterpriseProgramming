using Common;
using EnterpriseApp.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnterpriseApp.Models;

namespace DistProg.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(User u)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsersBL bl = new UsersBL();

                    u.Password = Hashing.HashString(u.Password);
                    RegistrationEnum register = bl.RegisterUser(u);

                    if (register == RegistrationEnum.Success)
                    {
                        ViewBag.Message = "User Registered successfully!";
                    }

                    else if (register == RegistrationEnum.UserNameExists)
                    {
                        ViewBag.Message = "Username already exists!";
                    }

                    else if (register == RegistrationEnum.ErrorOccurred)
                    {
                        ViewBag.Message = "Error occured. Please try again later";
                    }
                    ModelState.Clear();
                }

                else
                {
                    ViewBag.Message = "Check your inputs";
                }
            }

            catch (Exception e)
            {
                ViewBag.Message = "Error occurred: " + e.ToString();
            }
            return View();
        }
    }
}