using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DataAccess
{
    public class ArticlesRepository : Connection
    {
        public ArticlesRepository() : base()
        { }

        public void AddArticle(Article a)
        {
            Entity.Articles.Add(a);
            Entity.SaveChanges();
        }

        public IQueryable<Article> GetArticles()
        {
            return Entity.Articles;
        }

        public void DeleteArticle(Article a)
        {
            Entity.Articles.Remove(a);
            Entity.SaveChanges();
        }

        public Article GetArticle(int articleID)
        {
            return Entity.Articles.SingleOrDefault(x => x.ArticleID == articleID);
        }

        public void EditArticle(Article a)
        {
            Entity.Entry(GetArticle(a.ArticleID)).CurrentValues.SetValues(a);
            Entity.SaveChanges();
        }

        public Category GetCategory(int categoryID)
        {
            return Entity.Categories.SingleOrDefault(x => x.CategoryID == categoryID);
        }

        public Category GetCategoryByName(string categoryName)
        {
            return Entity.Categories.SingleOrDefault(x => x.Category1 == categoryName);
        }
    }
}
