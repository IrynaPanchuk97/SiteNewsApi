using GraphQL.Types;
using SiteNewsApi.Repositories.InterfaceRepository;

namespace SiteNewsApi.Models.GraphQL
{
    public class UserQuery : ObjectGraphType
    {
        public UserQuery(IUserRepository userRepository)
        {
            Field<ListGraphType<UserType>>(
                "users",
                resolve: context => userRepository.GetAllAsync());
        }
    }
}
