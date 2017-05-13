using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;
using DataAccess;

namespace EnterpriseApp.Models
{
    public class ArticlesBL
    {
        ArticlesRepository ar = new ArticlesRepository();

        public void AddArticle(Article a)
        {
            ar.AddArticle(a);
        }

        public IQueryable<Article> GetArticles()
        {
            return ar.GetArticles();
        }

        public Article GetArticle(int articleID)
        {
            return ar.GetArticle(articleID);
        }

        public void DeleteArticle(int articleID)
        {
            ar.DeleteArticle(ar.GetArticle(articleID));
        }

        public void EditArticle(Article a)
        {
            ar.EditArticle(a);
        }

        public Category GetCategory(int categoryID)
        {
            return ar.GetCategory(categoryID);
        }
    }
}