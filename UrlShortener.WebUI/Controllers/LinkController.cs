using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrlShortener.Model.Models;
using UrlShortener.WebUI.Helpers;
using UrlShortener.WebUI.Infrastructure;

namespace UrlShortener.WebUI.Controllers
{
    public class LinkController : Controller
    {
        private IUrlShortenerStore store;

        public LinkController(IUrlShortenerStore store)
        {
            this.store = store;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Get()
        {
            // Получить Identity пользователя из Cookies.
            Guid appUserIdentity;
            AppUser appUser = null;
            List<Link> links = new List<Link>();

            if (Guid.TryParse(Request.Cookies.Get("userIdentity")?.Value ?? "", out appUserIdentity))
            {
                appUser = store.AppUserService.GetByIdentity(appUserIdentity);
            }

            if (appUser != null)
            {
                // Получить все ссылки пользователя.
                links = store.LinkService.GetAllByAppUser(appUser).ToList();
            }

            var res = new List<Object>(links.Count);

            foreach (var link in links)
            {
                res.Add(new
                {
                    Short = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/" + ShortLinkHelper.GuidToShortLinkConverter(link.Short),
                    link.Original,
                    CreatedDate = link.CreatedDate.ToString(),
                    link.Visitors
                });
            }

            return Json(new
            {
                Links = res
            }, JsonRequestBehavior.AllowGet);
        }
    }
}