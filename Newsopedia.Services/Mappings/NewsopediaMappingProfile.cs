using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Newsopedia.Data.Models;
using Newsopedia.Services.NewsopediaOldModels;

namespace Newsopedia.Services.Mappings
{
    public class NewsopediaMappingProfile : Profile
    {
        public NewsopediaMappingProfile()
        {
            CreateMap<User, NewsopediaOldUserVm>()
                .ForMember(dest =>
                                    dest.UserId,
                                    opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest =>
                                    dest.Email,
                                    opt => opt.MapFrom(src => src.Email))
                .ForMember(dest =>
                                    dest.Password,
                                    opt => opt.MapFrom(src => src.Password))
                .ForMember(dest =>
                                    dest.FirstName,
                                    opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest =>
                                    dest.LastName,
                                    opt => opt.MapFrom(src => src.LastName))
                .ReverseMap();
            CreateMap<NewsArticle, NewsArticleVm>()
              .ForMember(dest =>
                                  dest.Title,
                                  opt => opt.MapFrom(src => src.Title))
              .ForMember(dest =>
                                  dest.Url,
                                  opt => opt.MapFrom(src => src.Url))
              .ForMember(dest =>
                                  dest.UserEmail,
                                  opt => opt.MapFrom(src => src.UserEmail))
              .ForMember(dest => dest.Description,
                                 opt => opt.MapFrom(src => src.Description))
              .ForMember(dest => dest.UrlToImage,
                                 opt => opt.MapFrom(src => src.UrlToImage))
              .ReverseMap();
            CreateMap<NewsTable, NewsTableVm>()
              .ForMember(dest =>
                                  dest.NewsId,
                                  opt => opt.MapFrom(src => src.NewsId))
              .ForMember(dest =>
                                  dest.NewsUrl,
                                  opt => opt.MapFrom(src => src.NewsUrl))
              .ForMember(dest =>
                                  dest.NewsTitle,
                                  opt => opt.MapFrom(src => src.NewsTitle))
              .ForMember(dest => dest.NewsDescription,
                                 opt => opt.MapFrom(src => src.NewsDescription))
              .ForMember(dest => dest.NewsImageUrl,
                                 opt => opt.MapFrom(src => src.NewsImageUrl))
              .ReverseMap();
            CreateMap<EmailAddress, EmailAddressVm>()
               .ForMember(dest =>
                                   dest.UserEmailaddress,
                                   opt => opt.MapFrom(src => src.EmailId))
               .ReverseMap();
            CreateMap<UserNewsTable, UserNewsVm>()
               .ForMember(dest =>
                                   dest.UserNewsId,
                                   opt => opt.MapFrom(src => src.UserNewsId))
               .ForMember(dest =>
                                   dest.UserId,
                                   opt => opt.MapFrom(src => src.UserId))
               .ForMember(dest =>
                                   dest.NewsId,
                                   opt => opt.MapFrom(src => src.NewsId))
               .ForMember(dest =>
                                   dest.Date,
                                   opt => opt.MapFrom(src => src.Date))
               .ReverseMap();
            CreateMap<ConcatenatedTable, ConcatenatedTableVm>()
               .ForMember(dest =>
                                   dest.UserNewsId,
                                   opt => opt.MapFrom(src => src.UserNewsId))
               .ForMember(dest =>
                                   dest.UserId,
                                   opt => opt.MapFrom(src => src.UserId))
               .ForMember(dest =>
                                   dest.NewsId,
                                   opt => opt.MapFrom(src => src.NewsId))
               .ForMember(dest =>
                                   dest.Date,
                                   opt => opt.MapFrom(src => src.Date))
               .ForMember(dest =>
                                  dest.NewsUrl,
                                  opt => opt.MapFrom(src => src.NewsUrl))
              .ForMember(dest =>
                                  dest.NewsTitle,
                                  opt => opt.MapFrom(src => src.NewsTitle))
              .ForMember(dest => dest.NewsDescription,
                                 opt => opt.MapFrom(src => src.NewsDescription))
              .ForMember(dest => dest.NewsImageUrl,
                                 opt => opt.MapFrom(src => src.NewsImageUrl))
               .ReverseMap();
            CreateMap<GetTopUsers, GetTopUsersVm>()
                   .ForMember(dest =>
                                       dest.FirstName,
                                       opt => opt.MapFrom(src => src.FirstName))
                   .ForMember(dest =>
                                       dest.LastName,
                                       opt => opt.MapFrom(src => src.LastName))
                   .ReverseMap();
        }
    }
}

