using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System.Web.Mvc;
using UrlShortener.WebUI.Infrastructure;

namespace UrlShortener.WebUI.App_Start
{
    public static class DependencyResolverConfig
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Register<IUrlShortenerStore, UrlShortenerStore>();
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}