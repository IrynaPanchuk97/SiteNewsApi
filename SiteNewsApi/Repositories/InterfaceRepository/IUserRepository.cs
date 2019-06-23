using SiteNewsApi.Models.Entities;
using System.Threading.Tasks;

namespace SiteNewsApi.Repositories.InterfaceRepository
{    public interface IUserRepository : IBaseRepository<User>
    {
        Task<UsersNews> AddLikedNewsAsync(UsersNews entity);
    }
}
