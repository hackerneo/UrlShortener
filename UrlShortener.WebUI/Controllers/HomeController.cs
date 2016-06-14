using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrlShortener.Model.Models;
using UrlShortener.WebUI.Helpers;
using UrlShortener.WebUI.Infrastructure;
using UrlShortener.WebUI.Models.View.Home;

namespace UrlShortener.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IUrlShortenerStore store;

        public HomeController(IUrlShortenerStore store)
        {
            this.store = store;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RedirectTo(String shortLink)
        {
            if (shortLink.Length > 8)
            {
                TempData["Error"] = "Превышен размер короткой ссылки";
                return RedirectToAction("Index");
            }
            if (shortLink != null)
            {
                var link = store.LinkService.GetByShortLink(ShortLinkHelper.ShortLinkToGuidConverter(shortLink));
                if (link != null)
                {
                    ++link.Visitors;
                    store.LinkService.Save();
                    return Redirect(link.Original);
                }
            }
            TempData["Error"] = "Ссылка не существует";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Shorten(ShortenInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    Success = false
                });
            }

            var shortLink = String.Empty;

            Guid appUserIdentity;
            AppUser appUser = null;

            if (Guid.TryParse(Request.Cookies.Get("userIdentity")?.Value ?? "", out appUserIdentity))
            {
                appUser = store.AppUserService.GetByIdentity(appUserIdentity);
            }
            else
            {
                appUserIdentity = Guid.NewGuid();
            }

            if (appUser == null)
            {
                appUser = new AppUser
                {
                    Identity = appUserIdentity
                };
                store.AppUserService.Create(appUser);
                store.AppUserService.Save();
            }

            var link = store.LinkService.GetByOriginalLink(inputModel.Url.Trim());

            // Если ссылка не существует в БД.
            if (link == null)
            {
                link = new Link
                {
                    CreatedDate = DateTime.Now,
                    Original = inputModel.Url.Trim(),
                    Short = ShortLinkHelper.NewShortLink(8),
                    Visitors = 0,
                    AppUsers = new List<AppUser>() { appUser }
                };
                store.LinkService.Create(link);
                store.LinkService.Save();
            }

            Response.SetCookie(new HttpCookie("userIdentity", appUserIdentity.ToString("N")));
            return Json(new
            {
                Success = true,
                ShortLink = ShortLinkHelper.GuidToShortLinkConverter(link.Short),
                textlink = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/" 
            });
        }
    }
}