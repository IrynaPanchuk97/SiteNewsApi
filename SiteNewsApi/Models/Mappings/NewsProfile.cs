using AutoMapper;
using SiteNewsApi.Models.DTOs;
using SiteNewsApi.Models.Entities;

namespace SiteNewsApi.Models.Mappings
{
    public class NewsProfile : Profile
    {
        public NewsProfile()
        {
            CreateMap<NewsDTO, News>()
                .ForMember(u => u.CreateDate, opt => opt.Ignore())
                .ForMember(u => u.ModDate, opt => opt.Ignore())
                .ForMember(u => u.UsersNews, opt => opt.Ignore());

            CreateMap<News, NewsDTO>()
                .ForMember(u => u.LikedLevel, opt => opt.Ignore());


        }
    }
}
