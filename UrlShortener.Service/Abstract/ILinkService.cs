using System;
using System.Collections.Generic;
using UrlShortener.Model.Models;

namespace UrlShortener.Service.Abstract
{
    public interface ILinkService
    {
        IEnumerable<Link> GetAllByAppUser(AppUser appUser);
        Link Get(Int64 id);
        Link GetByShortLink(Guid @short);
        Link GetByOriginalLink(String url);
        void Create(Link link);
        void Delete(Int64 id);
        void Save();
    }
}