﻿using AutoMapper;
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
                .ForMember(u => u.Mod, opt => opt.Ignore())
                .ForMember(u => u.ModId, opt => opt.Ignore())
                .ForMember(u => u.ModDate, opt => opt.Ignore())
                .ForMember(u => u.Create, opt => opt.Ignore())
                .ForMember(u => u.CreateId, opt => opt.Ignore())
                .ForMember(u => u.CreateDate, opt => opt.Ignore());
            CreateMap<User, UserDTO>()
                .ForMember(u => u.Password, opt => opt.Ignore())
                .ForMember(u => u.NewsList, opt => opt.MapFrom(x => x.UsersNews.Select(y => y.News).ToList()));
            CreateMap<UsersNews, NewsDTO>();
        }
    }
}