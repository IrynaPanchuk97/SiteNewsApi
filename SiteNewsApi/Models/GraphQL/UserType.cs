using GraphQL.Types;
using SiteNewsApi.Models.DTOs;

namespace SiteNewsApi.Models.GraphQL
{
    public class UserType : ObjectGraphType<UserDTO>
    {
        public UserType()
        {
            Field(x => x.Email);
            Field(x => x.FirstName);
            Field(x => x.IsActive, type: typeof(BooleanGraphType));
            Field(x => x.LastName);
            Field(x => x.Login);
            Field(x => x.MiddleName);
            Field(x => x.Password);
           // Field(x => x.UsersNews);
        }
    }
}
