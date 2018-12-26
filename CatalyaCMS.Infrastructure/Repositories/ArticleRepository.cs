using CatalyaCMS.Domain.DomainModels;
using CatalyaCMS.Infrastructure.Abstractions;
using CatalyaCMS.Infrastructure.Context;

namespace CatalyaCMS.Infrastructure.Repositories
{
    public class ArticleRepository : GenericRepository<Article>
    {
        public ArticleRepository(SiteDbContext db) : base(db)
        {
        }
    }
}