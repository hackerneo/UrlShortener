using UrlShortener.Data.Infrastructure;
using UrlShortener.Model.Models;

namespace UrlShortener.Data.Repository
{
    public interface IAppUserRepository : IRepository<AppUser>
    {
    }

    public class EFAppUserRepository : RepositoryBase<AppUser>, IAppUserRepository
    {
        public EFAppUserRepository(IDatabaseFactory factory)
            : base(factory)
        {
        }
    }
}