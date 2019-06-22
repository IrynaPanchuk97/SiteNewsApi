using AutoMapper;
using GraphQL.Types;
using SiteNewsApi.Models.DTOs;
using SiteNewsApi.Models.Entities;
using SiteNewsApi.Repositories.InterfaceRepository;
using System.Collections.Generic;

namespace SiteNewsApi.Models.GraphQL
{
    public class NewsContextQuery :ObjectGraphType
    {
       public NewsContextQuery(INewsRepository newsRepository, IUserRepository userRepository, IMapper mapper )
        {
            Field<ListGraphType<NewsType>>(
                "newsAll",
                resolve: context => mapper.Map<IEnumerable<News>, IList<NewsDTO>>(newsRepository.GetAllAsync().Result));

            Field<ListGraphType<UserType>>(
                "users",
                resolve: context => mapper.Map<IEnumerable<User>, IList<UserDTO>>(userRepository.GetAllAsync().Result));

            Field<UserType>(
               "user",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" }),      
                resolve: context =>
                {
                    int id = context.GetArgument<int>("id");
                    return mapper.Map<User, UserDTO>(userRepository.GetByIdAsync(id).Result);
                });
        }
    }
}
