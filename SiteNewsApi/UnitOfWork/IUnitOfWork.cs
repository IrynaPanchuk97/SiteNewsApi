using SiteNewsApi.Repositories.InterfaceRepository;
using System.Threading.Tasks;

namespace SiteNewsApi.UnitOfWork
{
    public interface IUnitOfWork
    {
        INewsRepository NewsRepository { get; }
        IUserRepository UserRepository { get; }
        Task<int> SaveAsync();
    }
}
