using UrlShortener.Data.Infrastructure;
using UrlShortener.Model.Models;

namespace UrlShortener.Data.Repository
{
    public interface ILinkRepository : IRepository<Link>
    {
    }

    public class EFLinkRepository : RepositoryBase<Link>, ILinkRepository
    {
        public EFLinkRepository(IDatabaseFactory factory)
            :base(factory)
        {
        }
    }
}