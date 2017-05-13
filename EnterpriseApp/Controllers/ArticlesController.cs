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

        public ActionResult Details(int articleID)
        {
            ArticlesBL ab = new ArticlesBL();

            Article at = ab.GetArticle(articleID);

            Category ct = ab.GetCategory(at.Category);
            ViewBag.Category = ct;
            
            return View(at);
        }

        public ActionResult Category(int categoryID)
        {
            ArticlesBL ab = new ArticlesBL();

            List<Article> at = (from a in ab.GetArticles()
                                where a.Category == categoryID
                                orderby a.Created descending
                                select a).Skip(1).Take(4).ToList();

            List<Article> tm = (from a in ab.GetArticles()
                                where a.Category == categoryID
                                orderby a.Created descending
                                select a).Take(1).ToList();

            ViewBag.LatestArticles = at;
            ViewBag.LastFeatured = tm;
            ViewBag.Category = ab.GetCategory(categoryID);
            return View();
        }
    }
}