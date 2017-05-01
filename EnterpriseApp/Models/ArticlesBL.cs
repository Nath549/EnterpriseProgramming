﻿using System;
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

        public void DeleteArticle(Article a)
        {
            ar.DeleteArticle(a);
        }
    }
}