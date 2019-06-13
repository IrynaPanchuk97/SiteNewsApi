using GraphQL.Types;
using SiteNewsApi.Repositories.InterfaceRepository;
using SiteNewsApi.UnitOfWorks;

namespace SiteNewsApi.Models.GraphQL
{
    public class NewsQuery :ObjectGraphType
    {
       // public NewsQuery(UnitOfWork unitOfWork )
       public NewsQuery(INewsRepository newsRepository)
        {
            Field<ListGraphType<NewsType>>(
                "newsAll",
                resolve: context => newsRepository.GetAllAsync());
        }
    }
}
