using Microsoft.EntityFrameworkCore;
using SiteNewsApi.Models.Entities;
using SiteNewsApi.Repositories.InterfaceRepository;
using System.Linq;

namespace SiteNewsApi.Repositories.ImplementedRepository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context)
            : base(context)
        {
        }

        protected override IQueryable<User> ComplexEntities => Entities.
            Include(a => a.Create).
            Include(b => b.Mod).OrderByDescending(u => u.ModDate).ThenByDescending(x => x.CreateDate);
    }
}
