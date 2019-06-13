using GraphQL.Types;
using SiteNewsApi.Models.Entities;

namespace SiteNewsApi.Models.GraphQL
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Field(x => x.Email);
            Field(x => x.FirstName);
            //Field(x => x.IsActive);
            Field(x => x.LastName);
            Field(x => x.Login);
            Field(x => x.MiddleName);
           // Field(x => x.UsersNews);
           // Field(x => x.Password);
        }
    }
}
