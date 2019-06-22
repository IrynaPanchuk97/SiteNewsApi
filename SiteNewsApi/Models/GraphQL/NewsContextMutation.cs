using AutoMapper;
using GraphQL.Types;
using SiteNewsApi.Models.DTOs;
using SiteNewsApi.Models.Entities;
using SiteNewsApi.Repositories.InterfaceRepository;
using SiteNewsApi.UnitOfWorks;

namespace SiteNewsApi.Models.GraphQL
{
    public class NewsContextMutation : ObjectGraphType
    {
        public NewsContextMutation(IUnitOfWork unitOfWork, IMapper mapper)
        {
            Field<UserType>(
                "createUser",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserInputType>>{ Name = "user"}
                    ),
                resolve: context =>
                {
                    var user = context.GetArgument<UserDTO>("user");      
                     return mapper.Map<User,UserDTO>(unitOfWork.UserRepository.AddAsync(mapper.Map<UserDTO, User>(user)).Result);
                   
                });
        }
    }
}
