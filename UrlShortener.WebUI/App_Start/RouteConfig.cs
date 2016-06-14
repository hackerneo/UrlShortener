using System.Web.Mvc;
using System.Web.Routing;

namespace UrlShortener.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "UserLinks",
            //    url: "MyLinks",
            //    defaults: new { controller = "Link", action = "Index"}
            //);

            routes.MapRoute(
                name: "UserLinks",
                url: "MyLinks/{action}",
                defaults: new { controller = "Link", action = "Index" }
            );

            routes.MapRoute(
                name: "ShortLink",
                url: "{shortLink}",
                defaults: new { controller = "Home", action = "RedirectTo" },
                constraints: new { shortLink = @"^[a-zA-Z0-9].+$" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
