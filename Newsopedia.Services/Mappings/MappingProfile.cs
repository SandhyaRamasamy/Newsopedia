using AutoMapper;
using Newsopedia.Data.Entities;
using Newsopedia.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsopedia.Services.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserVm>()
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
            CreateMap<DateUrl, DateUrlVm>()
                .ForMember(dest =>
                                    dest.DateUrlId,
                                    opt => opt.MapFrom(src => src.DateUrlId))
                .ForMember(dest =>
                                    dest.UserId,
                                    opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest =>
                                    dest.Date,
                                    opt => opt.MapFrom(src => src.Date))
                .ForMember(dest =>
                                    dest.NewsTitle,
                                    opt => opt.MapFrom(src => src.NewsTitle))
                .ForMember(dest =>
                                    dest.NewsUrl,
                                    opt => opt.MapFrom(src => src.NewsUrl))
                .ForMember(dest =>
                                    dest.NewsDescription,
                                    opt => opt.MapFrom(src => src.NewsDescription))
                .ForMember(dest =>
                                    dest.NewsImageUrl,
                                    opt => opt.MapFrom(src => src.NewsImageUrl))
                .ReverseMap();
            CreateMap<NewsArticle, NewsArticleVm>()
               .ForMember(dest =>
                                   dest.Title,
                                   opt => opt.MapFrom(src => src.Title))
               .ForMember(dest =>
                                   dest.Url,
                                   opt => opt.MapFrom(src => src.URL))
               .ForMember(dest =>
                                   dest.UserEmail,
                                   opt => opt.MapFrom(src => src.UserEmail))
               .ForMember(dest => dest.Description,
                                  opt => opt.MapFrom( src=> src.Description))
               .ForMember(dest => dest.UrlToImage,
                                  opt => opt.MapFrom(src => src.URLToImage))
               .ReverseMap();
            CreateMap<EmailAddress, EmailAddressVm>()
               .ForMember(dest =>
                                   dest.UserEmailaddress,
                                   opt => opt.MapFrom(src => src.EmailAdd))
               .ReverseMap();          
        }
    }
}
