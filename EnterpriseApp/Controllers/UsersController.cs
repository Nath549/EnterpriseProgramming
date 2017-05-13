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

        [Authorize]
        public ActionResult Index()
        {
            UsersBL ub = new UsersBL();
            IQueryable<User> um = ub.GetUsers(); 
            return View(um);
        }

        [Authorize]
        public ActionResult Delete(string username)
        {
            UsersBL ub = new UsersBL();
            try
            {
                ub.DeleteUser(username);
            }
            catch(Exception e)
            {
                ViewBag.ErrorMessage = e;
            }

            ViewBag.Success = "User succesfully deleted!";
            return View("Index");
        }

        [Authorize]
        public ActionResult EditUser(string username)
        {
            UsersBL ub = new UsersBL();
            User um = ub.GetUser(username); 
            return View(um);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditUser(User u)
        {
            UsersBL ub = new UsersBL();
            try
            {
                u.Password = Hashing.HashString(u.Password);
                ub.EditUser(u);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e;
                return View();
            }

            ViewBag.Success = "User succesfully edited!";
            return View();
        }

        public ActionResult Author(string username)
        {
            UsersBL ub = new UsersBL();
            ArticlesBL ab = new ArticlesBL();

            User um = ub.GetUser(username);
            List<Article> PreLatestArticles = (from a in ab.GetArticles()
                                         where a.Username == username
                                         orderby a.Created descending
                                         select a).Skip(1).Take(4).ToList();
            List<Article> PreLatestArticle = (from a in ab.GetArticles()
                                               where a.Username == username
                                               orderby a.Created descending
                                               select a).Take(1).ToList();

            ViewBag.LatestArticles = PreLatestArticles;
            ViewBag.FirstArticle = PreLatestArticle;
            return View(um);
        }
    }
}