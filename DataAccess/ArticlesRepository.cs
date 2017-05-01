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

        public void DeleteArticle(Article a)
        {
            Entity.Articles.Remove(a);
            Entity.SaveChanges();
        }
    }
}
