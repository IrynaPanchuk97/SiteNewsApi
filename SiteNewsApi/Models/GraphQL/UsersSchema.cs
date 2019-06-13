using GraphQL;
using GraphQL.Types;

namespace SiteNewsApi.Models.GraphQL
{
    public class UsersSchema : Schema
    {
        public UsersSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<NewsQuery>();
        }
    }
}
