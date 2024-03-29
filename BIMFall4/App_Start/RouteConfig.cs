﻿using System.Web.Mvc;
using System.Web.Routing;

namespace BIMFall4
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{token}",
                defaults: new { controller = "Home", action = "Index", token = UrlParameter.Optional }
            );

        }
    }
}
