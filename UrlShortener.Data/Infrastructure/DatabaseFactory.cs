using System;

namespace UrlShortener.Data.Infrastructure
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private UrlShortenerEntities context;
        private String connectionString;
        public DatabaseFactory(String connectionString)
        {
            this.connectionString = connectionString;
        }

        public UrlShortenerEntities Get()
        {
            return context ?? (context = (connectionString == null ? new UrlShortenerEntities() : new UrlShortenerEntities(connectionString)));
        }

        public void Dispose()
        {
            if (context != null) context.Dispose();
        }
    }
}
