using System;
using UrlShortener.Model.Models;

namespace UrlShortener.Service.Abstract
{
    public interface IAppUserService
    {
        AppUser GetByIdentity(Guid identity);
        void Create(AppUser appUser);
        void Save();
    }
}
