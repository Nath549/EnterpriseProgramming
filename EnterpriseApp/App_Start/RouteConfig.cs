﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EnterpriseApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               "Author",
               "author/{username}",
               defaults: new { controller = "Users", action = "Author" }
           );

            routes.MapRoute(
               "Category",
               "category/{categoryName}",
               defaults: new { controller = "Articles", action = "Category" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Users", action = "Register", id = UrlParameter.Optional }
            );

            
        }
    }
}
