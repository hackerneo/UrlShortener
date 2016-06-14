using UrlShortener.Service.Abstract;

namespace UrlShortener.WebUI.Infrastructure
{
    public interface IUrlShortenerStore
    {
        ILinkService LinkService { get; }
        IAppUserService AppUserService { get; }
    }
}
