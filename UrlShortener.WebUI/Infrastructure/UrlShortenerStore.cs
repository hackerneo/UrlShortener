using System;
using System.Configuration;
using UrlShortener.Data.Infrastructure;
using UrlShortener.Data.Repository;
using UrlShortener.Service.Abstract;
using UrlShortener.Service.Concrete;

namespace UrlShortener.WebUI.Infrastructure
{
    public class UrlShortenerStore : IUrlShortenerStore
    {
        private IAppUserService appUserService;
        private IDatabaseFactory factory;
        private ILinkService linkService;

        public UrlShortenerStore()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["UrlShortenerStore"].ConnectionString;
            factory = new DatabaseFactory(connectionString);
        }

        public IAppUserService AppUserService
        {
            get { return appUserService ?? (appUserService = new AppUserService(new EFAppUserRepository(factory))); }
        }

        public ILinkService LinkService
        {
            get
            {
                return linkService ?? (
                    linkService = new LinkService(
                        new EFLinkRepository(factory),
                        new EFAppUserRepository(factory)
                    ));
            }
        }

        //public void Dispose()
        //{
        //    factory?.Dispose();
        //}
    }
}