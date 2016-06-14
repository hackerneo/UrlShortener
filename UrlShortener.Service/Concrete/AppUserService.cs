using System;
using UrlShortener.Data.Repository;
using UrlShortener.Model.Models;
using UrlShortener.Service.Abstract;

namespace UrlShortener.Service.Concrete
{
    public class AppUserService : IAppUserService
    {
        private IAppUserRepository appUserRepository;

        public AppUserService(IAppUserRepository appUserRepository)
        {
            this.appUserRepository = appUserRepository;
        }

        public void Create(AppUser appUser)
        {
            appUserRepository.Add(appUser);
        }

        public AppUser GetByIdentity(Guid identity)
        {
            return appUserRepository.Get(appUser=>appUser.Identity == identity);
        }

        public void Save()
        {
            appUserRepository.Commit();
        }
    }
}
