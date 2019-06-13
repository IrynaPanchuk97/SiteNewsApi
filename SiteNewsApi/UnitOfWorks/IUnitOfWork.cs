using SiteNewsApi.Repositories.InterfaceRepository;
using System.Threading.Tasks;

namespace SiteNewsApi.UnitOfWorks
{
    public interface IUnitOfWork
    {
        INewsRepository NewsRepository { get; }
        IUserRepository UserRepository { get; }
        Task<int> SaveAsync();
    }
}
