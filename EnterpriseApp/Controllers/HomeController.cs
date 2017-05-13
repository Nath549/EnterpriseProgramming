using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnterpriseApp.Models;
using Common;

namespace EnterpriseApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ArticlesBL ab = new ArticlesBL();
            IQueryable<Article> art = (from a in ab.GetArticles()
                                      orderby a.Created descending
                                      select a).Take(5);
            List<Article> artNational = (from a in ab.GetArticles()
                                               where a.Category == 1
                                               orderby a.Created descending
                                               select a).Skip(1).Take(4).ToList();
            List<Article> artOverseas = (from a in ab.GetArticles()
                                         where a.Category == 2
                                         orderby a.Created descending
                                         select a).Skip(1).Take(4).ToList();
            List<Article> artSports = (from a in ab.GetArticles()
                                       where a.Category == 3
                                       orderby a.Created descending
                                       select a).Skip(1).Take(4).ToList();
            List<Article> artOpinion = (from a in ab.GetArticles()
                                        where a.Category == 4
                                        orderby a.Created descending
                                        select a).Skip(1).Take(4).ToList();
            List<Article> artTravel = (from a in ab.GetArticles()
                                       where a.Category == 5
                                       orderby a.Created descending
                                       select a).Skip(1).Take(4).ToList();
            List<Article> artOdd = (from a in ab.GetArticles()
                                    where a.Category == 6
                                    orderby a.Created descending
                                    select a).Skip(1).Take(5).ToList();
            List<Article> latestNational = (from a in ab.GetArticles()
                                              where a.Category == 1
                                              orderby a.Created descending
                                              select a).Take(1).ToList();
            List<Article> latestOverseas =  (from a in ab.GetArticles()
                                              where a.Category == 2
                                              orderby a.Created descending
                                              select a).Take(1).ToList();
            List<Article> latestSports = (from a in ab.GetArticles()
                                          where a.Category == 3
                                          orderby a.Created descending
                                          select a).Take(1).ToList();
            List<Article> latestOpinion = (from a in ab.GetArticles()
                                           where a.Category == 4
                                           orderby a.Created descending
                                           select a).Take(1).ToList();
            List<Article> latestTravel = (from a in ab.GetArticles()
                                          where a.Category == 5
                                          orderby a.Created descending
                                          select a).Take(1).ToList();
            List<Article> latestOdd = (from a in ab.GetArticles()
                                       where a.Category == 6
                                       orderby a.Created descending
                                       select a).Take(1).ToList();
            ViewBag.GetLast5Featured = art;
            ViewBag.Last5National = artNational;
            ViewBag.Last5Overseas = artOverseas;
            ViewBag.Last5Sports = artSports;
            ViewBag.Last5Opinion = artOpinion;
            ViewBag.Last5Travel = artTravel;
            ViewBag.Last5Odd = artOdd;
            ViewBag.LatestNational = latestNational;
            ViewBag.LatestOverseas = latestOverseas;
            ViewBag.LatestSports = latestSports;
            ViewBag.LatestOpinion = latestOpinion;
            ViewBag.LatestTravel = latestTravel;
            ViewBag.LatestOdd = latestOdd;
            return View();
        }
    }
}