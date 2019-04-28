using SBlogA.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SBlogA
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            var namespaces = new[] { typeof(PostsController).Namespace };

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //HomePage route defined. This request was responed by Posts Controller Index Action 
            routes.MapRoute("Home", "", new { controller = "Posts", action = "Index" }, namespaces);
            routes.MapRoute("Login", "login", new { controller = "Auth", action = "Login" });
            routes.MapRoute("Logout", "logout", new { controller = "Auth", action = "Logout" });

        }
    }
}
