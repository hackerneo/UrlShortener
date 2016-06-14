using System;
using System.Collections.Generic;
using System.Linq;
using UrlShortener.Data.Repository;
using UrlShortener.Model.Models;
using UrlShortener.Service.Abstract;

namespace UrlShortener.Service.Concrete
{
    public class LinkService : ILinkService
    {
        private ILinkRepository linkRepository;
        private IAppUserRepository appUserRepository;

        public LinkService(ILinkRepository linkRepository, IAppUserRepository appUserRepository)
        {
            this.linkRepository = linkRepository;
            this.appUserRepository = appUserRepository;
        }

        public void Create(Link link)
        {
            linkRepository.Add(link);
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Link Get(long id)
        {
            throw new NotImplementedException();
        }

        public Link GetByOriginalLink(String url)
        {
            return linkRepository.Get(link => link.Original == url);
        }

        public Link GetByShortLink(Guid @short)
        {
            return linkRepository.Get(link => link.Short == @short);
        }

        public IEnumerable<Link> GetAllByAppUser(AppUser appUser)
        {
            return appUserRepository.GetById(appUser.Id).Links.ToList();
        }

        public void Save()
        {
            linkRepository.Commit();
        }
    }
}
