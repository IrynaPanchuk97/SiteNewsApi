using Microsoft.EntityFrameworkCore;
using SiteNewsApi.Models.Entities;
using SiteNewsApi.Repositories.InterfaceRepository;
using System.Collections.Generic;
using System.Linq;
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
        public override Task<IEnumerable<User>> GetAllAsync()
        {
            var c = Task.FromResult<IEnumerable<User>>(context.Set<User>()
                .Include(x => x.UsersNews)
                .ThenInclude(y=>y.News));
            return c;
        }
    }
}
