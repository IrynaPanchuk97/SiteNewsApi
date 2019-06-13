using Microsoft.EntityFrameworkCore;
using SiteNewsApi.Models.Entities;
using SiteNewsApi.Repositories.InterfaceRepository;
using System.Linq;

namespace SiteNewsApi.Repositories.ImplementedRepository
{
    public class NewsRepository : BaseRepository<News>, INewsRepository
    {
        public NewsRepository(DbContext context)
              : base(context)
        {
        }
        protected override IQueryable<News> ComplexEntities => Entities
    .Include(e => e.Create)
    .Include(e => e.Mod).OrderByDescending(u => u.ModDate).ThenByDescending(x => x.CreateDate);
    }
}
