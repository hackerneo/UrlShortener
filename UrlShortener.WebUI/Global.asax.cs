using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using UrlShortener.WebUI.App_Start;

namespace UrlShortener.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DependencyResolverConfig.Initialize();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}