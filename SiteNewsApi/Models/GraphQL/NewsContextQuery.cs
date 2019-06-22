using AutoMapper;
using GraphQL.Types;
using SiteNewsApi.Models.DTOs;
using SiteNewsApi.Models.Entities;
using SiteNewsApi.UnitOfWorks;
using System.Collections.Generic;

namespace SiteNewsApi.Models.GraphQL
{
    public class NewsContextQuery :ObjectGraphType
    {
       public NewsContextQuery(IUnitOfWork unitOfWork, IMapper mapper )
        {
            Field<ListGraphType<NewsType>>(
                "newsAll",
                resolve: context => mapper.Map<IEnumerable<News>, IList<NewsDTO>>(unitOfWork.NewsRepository.GetAllAsync().Result));

            Field<ListGraphType<UserType>>(
                "users",
                resolve: context => mapper.Map<IEnumerable<User>, IList<UserDTO>>(unitOfWork.UserRepository.GetAllAsync().Result));

            Field<UserType>(
               "user",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" }),      
                resolve: context =>
                {
                    int id = context.GetArgument<int>("id");
                    return mapper.Map<User, UserDTO>(unitOfWork.UserRepository.GetByIdAsync(id).Result);
                });
        }
    }
}
