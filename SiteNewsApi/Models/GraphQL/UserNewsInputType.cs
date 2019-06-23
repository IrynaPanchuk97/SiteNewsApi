using GraphQL.Types;
using SiteNewsApi.Models.Entities;

namespace SiteNewsApi.Models.GraphQL
{
    public class UserNewsInputType : InputObjectGraphType<UsersNews>
    {
        public UserNewsInputType()
        {
            Name = "UserNewsInput";
            Field<IdGraphType>("idUser");
            Field<IdGraphType>("idNews");
            Field<StringGraphType>("likedLevel");
        }
    }
}
