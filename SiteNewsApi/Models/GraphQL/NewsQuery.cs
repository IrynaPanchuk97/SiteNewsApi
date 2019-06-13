using GraphQL.Types;
using SiteNewsApi.Repositories.InterfaceRepository;

namespace SiteNewsApi.Models.GraphQL
{
    public class NewsQuery :ObjectGraphType
    {
       public NewsQuery(INewsRepository newsRepository)
        {
            Field<ListGraphType<NewsType>>(
                "newsAll",
                resolve: context => newsRepository.GetAllAsync());
        }
    }
}
