using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MultyBlog.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
               name: "TagsSearch",
               url: "Tag/{tag}",
               defaults: new { controller = "Tag", action = "Index" }

            );

            routes.MapRoute(
               name: "Profile",
               url: "Profile/{UserName}",
               defaults: new { controller = "Profile", action = "Index" }

           );

            routes.MapRoute(
                name: "Article",
                url: "article/{id}",
                defaults: new { controller = "Article", action = "Index" },
                constraints: new { id = @"\d+" }
            );

            routes.MapRoute(
                name: "ArticleAddComment",
                url: "article/{action}/{id}",
                defaults: new { controller = "Article", action = "AddComment"}
            );
            //routes.MapRoute(
            //    name: "ArticleDefault",
            //    url: "article/{action}/{id}",
            //    defaults: new { controller = "Article", action = "index", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
               name: "AuthenticationRegister",
               url: "Register",
               defaults: new { controller = "Authentication", action = "Register" }

            );

            routes.MapRoute(
               name: "AuthenticationLogIn",
               url: "LogIn",
               defaults: new { controller = "Authentication", action = "LogIn" }

            );

            routes.MapRoute(
               name: "AuthenticationLogOut",
               url: "Logout",
               defaults: new { controller = "Authentication", action = "logOut" }

            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}