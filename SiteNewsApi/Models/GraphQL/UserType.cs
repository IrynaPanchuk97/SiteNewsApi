using AutoMapper;
using GraphQL.Types;
using SiteNewsApi.Models.DTOs;
using SiteNewsApi.Models.Entities;
using SiteNewsApi.Repositories.InterfaceRepository;
using System.Collections.Generic;

namespace SiteNewsApi.Models.GraphQL
{
    public class UserType : ObjectGraphType<UserDTO>
    {
        public UserType(INewsRepository newsRepository, IMapper mapper)
        {
            Field(x => x.Email);
            Field(x => x.FirstName);
            Field(x => x.IsActive, type: typeof(BooleanGraphType));
            Field(x => x.LastName);
            Field(x => x.Login);
            Field(x => x.MiddleName);
            Field(x => x.Password);
            Field<ListGraphType<NewsType>>(
                "newsAll",
                resolve: context => mapper.Map<IEnumerable<News>, IList<NewsDTO>>(newsRepository.GetAllAsync().Result));

        }
    }
}
