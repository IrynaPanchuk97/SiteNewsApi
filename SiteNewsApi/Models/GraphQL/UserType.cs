using AutoMapper;
using GraphQL.Types;
using SiteNewsApi.Models.DTOs;
using SiteNewsApi.Models.Entities;
using SiteNewsApi.UnitOfWorks;
using System.Collections.Generic;
using System.Linq;

namespace SiteNewsApi.Models.GraphQL
{
    public class UserType : ObjectGraphType<UserDTO>
    {
        public UserType(IUnitOfWork unitOfWork, IMapper mapper)
        {
            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.Email, type: typeof(StringGraphType));
            Field(x => x.FirstName, type: typeof(StringGraphType));
            Field(x => x.IsActive, type: typeof(BooleanGraphType));
            Field(x => x.LastName, type: typeof(StringGraphType));
            Field(x => x.Login, type: typeof(StringGraphType));
            Field(x => x.MiddleName, type: typeof(StringGraphType));
            Field(x => x.Password, type: typeof(StringGraphType));
            Field<ListGraphType<NewsType>>(
                "newsLiked",
                resolve: context =>
                {
                    var user = context.Source;
                    return mapper.Map<List<News>, List<NewsDTO>>(
                        unitOfWork.NewsRepository.GetNewlLikedByUserAsync(user.Id).Result.ToList(),
                        opt => opt.AfterMap((news, newsDTO) => MapLikedLevel(ref news, ref newsDTO, user.Id)));
                });
            Field<ListGraphType<NewsType>>(
         "allnews",
                 resolve: context =>
                 {
                     var user = context.Source;
                     return mapper.Map<List<News>, List<NewsDTO>>(
                         unitOfWork.NewsRepository.GetAllAsync().Result.ToList(),
                         opt => opt.AfterMap((news, newsDTO) => MapLikedLevel(ref news, ref newsDTO, user.Id)));
                 });
        }
        private void MapLikedLevel(ref List<News> news, ref List<NewsDTO> newsDTO, int idUser)
        {
            for (int i = 0; i < news.Count;i++)
            {
                if(news[i].UsersNews.Count>0)
                {
                    List<UsersNews> usersNews = news[i].UsersNews.Where(x => x.IdUser == idUser).ToList();
                    if(usersNews.Count >0)
                    {
                        newsDTO[i].LikedLevel = usersNews.Select(w => w.LikedLevel).ToList<string>()[0];

                    }

                }
            }
        }
    }
}
