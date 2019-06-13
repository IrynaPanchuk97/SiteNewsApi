using GraphQL.Types;
using SiteNewsApi.Models.Entities;

namespace SiteNewsApi.Models.GraphQL
{
    public class NewsType : ObjectGraphType<News>
    {
        public NewsType()
        {
            Field(x => x.Title);
            Field(x => x.Author);
            Field(x => x.Text);
            Field(x => x.Url);
            //Field(x => x.UsersNews);
        }
    }
}
