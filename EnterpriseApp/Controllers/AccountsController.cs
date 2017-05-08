using EnterpriseApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EnterpriseApp.Models;

namespace EnterpriseApp.Controllers
{
    public class AccountsController : Controller
    {
        [HttpGet]//Render page
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]//on Login to submit details(user&pass)
        public ActionResult Login(string username, string password)
        {
            try
            {
                password = Hashing.HashString(password);
                LoginEnum response = new UsersBL().Login(username, password);
                if (response == LoginEnum.Success)
                {
                    //HttpContext.User.IsInRole("admin");
                    FormsAuthentication.SetAuthCookie(username, true);
                    return RedirectToAction("Index", "Home");
                }
                else if (response == LoginEnum.InvalidCredentials)
                {
                    ViewBag.Message = "Invalid Credentials";
                }
                else
                {
                    ViewBag.Message = "Login failed. Try again..";
                }
            }
            catch (Exception e)
            {
                ViewBag.Message = "Error occured while logging in. Try again later.. " + e.ToString();
            }

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}