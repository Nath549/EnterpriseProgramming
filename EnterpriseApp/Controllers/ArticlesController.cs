using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnterpriseApp.Models;
using Common;
using System.IO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using EnterpriseApp.Azure;

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
        public ActionResult AddArticle()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddArticle(ArticleUploadModel a, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (file != null)
                    {
                        ArticlesBL ab = new ArticlesBL();
                        Article ar = new Article();
                        ar.Category = a.Category;
                        ar.Content = a.Content;
                        ar.Heading = a.Heading;
                        if (a.SubHeading != null)
                        {
                            ar.SubHeading = a.SubHeading;
                        }
                        ar.Username = HttpContext.User.Identity.Name;
                        CloudStorageAccount cloudStorageAccount = ConnectionString.GetConnectionString();
                        CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                        CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("nathanielgrech");

                        if(cloudBlobContainer.CreateIfNotExists())
                        {
                            cloudBlobContainer.SetPermissions(
                                new BlobContainerPermissions
                                {
                                   PublicAccess = BlobContainerPublicAccessType.Blob
                                });
                        }

                        string imageName = Guid.NewGuid().ToString() + "-" + Path.GetExtension(file.FileName);

                        CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(imageName);
                        cloudBlockBlob.Properties.ContentType = file.ContentType;
                        cloudBlockBlob.UploadFromStream(file.InputStream);
                        ar.Image = cloudBlockBlob.Uri.ToString();                  

                        ab.AddArticle(ar);

                        ModelState.Clear();

                        ViewBag.Success = "Article succesfully uploaded!";
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "An image must be uploaded!";
                    }
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "Error occurred: " + e.ToString();
            }

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
                Article b = ab.GetArticle(a.ArticleID);
                a.Image = b.Image;
                a.Username = b.Username;
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

        [Authorize]
        public ActionResult Details(int articleID)
        {
            ArticlesBL ab = new ArticlesBL();

            Article at = ab.GetArticle(articleID);

            Category ct = ab.GetCategory(at.Category);
            ViewBag.Category = ct;
            
            return View(at);
        }

        [Authorize]
        public ActionResult Category(string categoryName)
        {
            ArticlesBL ab = new ArticlesBL();

            Category ct = ab.GetCategoryByName(categoryName);

            List<Article> at = (from a in ab.GetArticles()
                                where a.Category == ct.CategoryID
                                orderby a.ArticleID descending
                                select a).Skip(1).Take(4).ToList();

            List<Article> tm = (from a in ab.GetArticles()
                                where a.Category == ct.CategoryID
                                orderby a.ArticleID descending
                                select a).Take(1).ToList();

            ViewBag.LatestArticles = at;
            ViewBag.LastFeatured = tm;
            ViewBag.Category = ct;
            return View();
        }

        [Authorize]
        public ActionResult ArticlesArchive()
        {
            ArticlesBL ab = new ArticlesBL();
            IQueryable<Article> am = ab.GetArticles();
            return View(am);
        }

        [Authorize]
        public ActionResult DeleteArticle(int articleID)
        {
            ArticlesBL ab = new ArticlesBL();

            try
            {
                ab.DeleteArticle(articleID);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e;
                return View();
            }

            ViewBag.Success = "Article deleted succesfully!";
            return View("ArticlesArchive");
        }
    }
}