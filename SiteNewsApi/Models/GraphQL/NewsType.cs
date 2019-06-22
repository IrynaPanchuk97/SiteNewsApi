using GraphQL.Types;
using SiteNewsApi.Models.DTOs;

namespace SiteNewsApi.Models.GraphQL
{
    public class NewsType : ObjectGraphType<NewsDTO>
    {
        public NewsType()
        {
            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.Title, type: typeof(StringGraphType));
            Field(x => x.Author, type: typeof(StringGraphType));
            Field(x => x.Text, type: typeof(StringGraphType));
            Field(x => x.Url, type: typeof(StringGraphType));
            Field(x => x.LikedLevel, type: typeof(StringGraphType));
        }
    }
}
