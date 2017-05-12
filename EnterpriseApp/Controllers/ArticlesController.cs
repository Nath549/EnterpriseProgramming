using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnterpriseApp.Models;
using Common;

namespace EnterpriseApp.Controllers
{
    public class ArticlesController : Controller
    {
        // GET: Articles
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult CreateArticle()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateArticle(Article a)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ArticlesBL ab = new ArticlesBL();
                    ab.AddArticle(a);
                    ModelState.Clear();
                }
            }
            catch (Exception e)
            {
                ViewBag.Message = "Error occurred: " + e.ToString();
            }

            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult DeleteArticle(int articleID)
        {
            ArticlesBL ab = new ArticlesBL();

            try
            {
                ab.DeleteArticle(articleID);
            }
            catch(Exception e)
            {
                ViewBag.ErrorMessage = e;
                return View();
            }

            ViewBag.Success = "Article deleted succesfully!";
            return View();
        }

        [Authorize]
        public ActionResult EditArticle(int articleID)
        {
            ArticlesBL ab = new ArticlesBL();
            Article ar= ab.GetArticle(articleID);
            return View(ar);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditArticle(Article a)
        {
            ArticlesBL ab = new ArticlesBL();
            try
            {
                ab.EditArticle(a);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e;
                return View();
            }

            ViewBag.Success = "Article succesfully edited!";
            return View();
        }
    }
}