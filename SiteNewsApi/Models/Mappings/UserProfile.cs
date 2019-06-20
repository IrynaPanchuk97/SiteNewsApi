using AutoMapper;
using SiteNewsApi.Models.DTOs;
using SiteNewsApi.Models.Entities;
using System.Linq;

namespace SiteNewsApi.Models.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, User>()
                .ForMember(u => u.ModDate, opt => opt.Ignore())
                .ForMember(u => u.CreateDate, opt => opt.Ignore());

            CreateMap<User, UserDTO>()
                .ForMember(u => u.Password, opt => opt.Ignore())
                .ForMember(u => u.NewsList, opt => opt.MapFrom(x => x.UsersNews.Where(y => y.IdUser == x.Id).Select(r=>r.News)));
            CreateMap<UsersNews, NewsDTO>()
                .ForMember(x=>x.LikedLevel, opt=>opt.MapFrom(y=>y.LikedLevel));
        }
    }
}
