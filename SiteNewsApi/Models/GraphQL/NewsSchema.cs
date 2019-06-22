using GraphQL;
using GraphQL.Types;

namespace SiteNewsApi.Models.GraphQL
{
    public class NewsSchema:Schema
    {
        public NewsSchema(IDependencyResolver resolver)
            :base(resolver)
        {
            Mutation = resolver.Resolve<NewsContextMutation>();
            Query = resolver.Resolve<NewsContextQuery>();
        }
    }
}
