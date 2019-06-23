using GraphQL.Types;
using SiteNewsApi.Models.Entities;

namespace SiteNewsApi.Models.GraphQL
{
    public class UserNewsType : ObjectGraphType<UsersNews>
    {
        public UserNewsType()
        {
            Field(x => x.IdUser, type: typeof(IdGraphType));
            Field(x => x.IdNews, type: typeof(IdGraphType));
            Field(x => x.LikedLevel, type: typeof(StringGraphType));

        }
    }
}
