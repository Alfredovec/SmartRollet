﻿using System.Web.Mvc;
using System.Web.Routing;

namespace LighterEmul.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{id}",
                defaults: new { controller = "Lighter", action = "Manage" }
            );
        }
    }
}
