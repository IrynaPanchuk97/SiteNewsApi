using Microsoft.EntityFrameworkCore;
using SiteNewsApi.Models.Entities;
using SiteNewsApi.Repositories.InterfaceRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteNewsApi.Repositories.ImplementedRepository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DbContext context;

        public UserRepository(DbContext context)
            : base(context)
        {
            this.context = context;
        }

        public  Task<UsersNews> AddLikedNewsAsync(UsersNews entity)
        {
            context.Set<UsersNews>().AddAsync(entity);
            return Task.FromResult(entity);
        }

        public  Task<UsersNews> DeleteLikedNewsAsync(UsersNews entity)
        {
            context.Set<UsersNews>().Remove(entity);
            return Task.FromResult(entity);
        }

        public override Task<IEnumerable<User>> GetAllAsync()
        {
            var c = Task.FromResult<IEnumerable<User>>(_entities
                .Include(x => x.UsersNews)
                .ThenInclude(y=>y.News));
            return c;
        }
    }
}
