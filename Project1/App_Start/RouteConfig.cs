﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Project1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Enter", id = UrlParameter.Optional }
                //defaults: new { controller = "Auto", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Users",
                url: "Users/{action}/{id}",
                defaults: new { action = "Buy", id = UrlParameter.Optional }
            );
            /*routes.MapRoute(
                name: "Home",
                url: "Home/{action}/{id}",
                defaults: new { action = "RegisterEmail", id = UrlParameter.Optional }
            );*/
        }
    }
}
