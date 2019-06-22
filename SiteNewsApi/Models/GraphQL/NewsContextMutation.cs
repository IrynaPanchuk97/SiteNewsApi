using AutoMapper;
using GraphQL.Types;
using SiteNewsApi.Models.DTOs;
using SiteNewsApi.Models.Entities;
using SiteNewsApi.Repositories.InterfaceRepository;

namespace SiteNewsApi.Models.GraphQL
{
    public class NewsContextMutation : ObjectGraphType
    {
        public NewsContextMutation(IUserRepository userRepository, IMapper mapper)
        {
            Field<UserType>(
                "createUser",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserInputType>>{ Name = "user"}
                    ),
                resolve: context =>
                {
                    var user = context.GetArgument<UserDTO>("user");      
                     return mapper.Map<User,UserDTO>(userRepository.AddAsync(mapper.Map<UserDTO, User>(user)).Result);
                   
                });
        }
    }
}
