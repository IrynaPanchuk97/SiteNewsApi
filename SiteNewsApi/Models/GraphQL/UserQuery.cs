using GraphQL.Types;
using SiteNewsApi.UnitOfWorks;

namespace SiteNewsApi.Models.GraphQL
{
    public class UserQuery : ObjectGraphType
    {
        public UserQuery(UnitOfWork unitOfWork)
        {
            Field<ListGraphType<NewsType>>(
                "users",
                resolve: context => unitOfWork.UserRepository.GetAllAsync());
        }
    }
}
