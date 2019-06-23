using Microsoft.EntityFrameworkCore;
using SiteNewsApi.Models.Entities;
using SiteNewsApi.Repositories.InterfaceRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteNewsApi.Repositories.ImplementedRepository
{
    public class NewsRepository : BaseRepository<News>, INewsRepository
    {
        public NewsRepository(DbContext context)
              : base(context)
        {
        }
        public override Task<IEnumerable<News>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<News>>(_entities
                .Include(x=>x.UsersNews));
        }

        public async Task<IEnumerable<News>> GetNewlLikedByUserAsync(int IdUser)
        {
           Task<IEnumerable<News>> result =  Task.FromResult<IEnumerable<News>>(_entities
               .Include(x => x.UsersNews));

            var res = result.Result.Where(i => i.UsersNews.Count != 0).Where(u=>u.UsersNews.Select(o=>o.IdUser).Contains(IdUser));
            return await Task.FromResult(res);
        }
    }
}
