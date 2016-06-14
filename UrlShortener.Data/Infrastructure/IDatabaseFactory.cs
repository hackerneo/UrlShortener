using System;

namespace UrlShortener.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        UrlShortenerEntities Get();
    }
}
