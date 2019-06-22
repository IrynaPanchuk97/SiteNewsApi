using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using SiteNewsApi.Models.Entities;
using SiteNewsApi.Repositories.InterfaceRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteNewsApi.Repositories.ImplementedRepository
{
    public class NewsRepository : BaseRepository<News>, INewsRepository
    {
        private readonly DbContext context;
        public NewsRepository(DbContext context)
              : base(context)
        {
            this.context = context;
        }
        public override Task<IEnumerable<News>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<News>>(context.Set<News>()
                .Include(x=>x.UsersNews));
        }

        public async Task<IEnumerable<News>> GetNewlLikedByUserAsync(int IdUser)
        {
           Task<IEnumerable<News>> result =  Task.FromResult<IEnumerable<News>>(context.Set<News>()
               .Include(x => x.UsersNews));

            var res = result.Result.Where(i => i.UsersNews.Count != 0).Where(u=>u.UsersNews.Select(o=>o.IdUser).Contains(IdUser));
            return await Task.FromResult(res);
        }
    }
}
