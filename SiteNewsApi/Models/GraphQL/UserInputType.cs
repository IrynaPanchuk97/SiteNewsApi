using GraphQL.Types;
using SiteNewsApi.Models.DTOs;

namespace SiteNewsApi.Models.GraphQL
{
    public class UserInputType: InputObjectGraphType<UserDTO>
    {
        public UserInputType()
        {
            Name = "UserInput";
            Field<StringGraphType>("email");
            Field<StringGraphType>("firstName");
            Field<StringGraphType>("lastName");
            Field<StringGraphType>("middleName");
            Field<StringGraphType>("login");
            Field<StringGraphType>("password");
            Field<BooleanGraphType>("isActive");
        }
    }
}
