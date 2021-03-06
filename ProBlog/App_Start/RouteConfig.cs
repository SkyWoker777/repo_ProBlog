﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProBlog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "List",
                "blog/posts/{page}",
                new { controller = "Post", action = "List", page = "" }
            );

            routes.MapRoute(
                "ReadMore",
                "archive/{year}/{month}/{titlePost}",
                new { controller = "Post", action = "ReadMore" }
            );

            routes.MapRoute(
                "ListByCategory",
                "blog/posts-{categoryName}/{categoryId}/page{page}",
                new { controller = "Post", action = "ListByCategory" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
