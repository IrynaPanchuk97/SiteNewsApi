using SiteNewsApi.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteNewsApi.Repositories.InterfaceRepository
{
    public interface INewsRepository : IBaseRepository<News>
    {
        Task<IEnumerable<News>> GetNewlLikedByUserAsync(int IdUser);
    }
}
