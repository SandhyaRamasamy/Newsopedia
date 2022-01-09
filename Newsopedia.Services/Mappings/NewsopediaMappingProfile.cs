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
                                    dest.UserIdVm,
                                    opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest =>
                                    dest.EmailVm,
                                    opt => opt.MapFrom(src => src.Email))
                .ForMember(dest =>
                                    dest.PasswordVm,
                                    opt => opt.MapFrom(src => src.Password))
                .ForMember(dest =>
                                    dest.FirstNameVm,
                                    opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest =>
                                    dest.LastNameVm,
                                    opt => opt.MapFrom(src => src.LastName))
                .ReverseMap();
            CreateMap<JsonModel, JsonModelVm>()
              .ForMember(dest =>
                                  dest.TitleVm,
                                  opt => opt.MapFrom(src => src.Title))
              .ForMember(dest =>
                                  dest.URLVm,
                                  opt => opt.MapFrom(src => src.URL))
              .ForMember(dest =>
                                  dest.UserEmailVm,
                                  opt => opt.MapFrom(src => src.UserEmail))
              .ForMember(dest => dest.DescriptionVm,
                                 opt => opt.MapFrom(src => src.Description))
              .ForMember(dest => dest.URLToImageVm,
                                 opt => opt.MapFrom(src => src.URLToImage))

              .ReverseMap();
            CreateMap<NewsTable, NewsTableVm>()
              .ForMember(dest =>
                                  dest.NewsIdVm,
                                  opt => opt.MapFrom(src => src.NewsId))
              .ForMember(dest =>
                                  dest.NewsUrlVm,
                                  opt => opt.MapFrom(src => src.NewsUrl))
              .ForMember(dest =>
                                  dest.NewsTitleVm,
                                  opt => opt.MapFrom(src => src.NewsTitle))
              .ForMember(dest => dest.NewsDescriptionVm,
                                 opt => opt.MapFrom(src => src.NewsDescription))
              .ForMember(dest => dest.NewsImageUrlVm,
                                 opt => opt.MapFrom(src => src.NewsImageUrl))

              .ReverseMap();
            CreateMap<EmailAddress, EmailAddressVm>()
               .ForMember(dest =>
                                   dest.UserEmailaddressVm,
                                   opt => opt.MapFrom(src => src.EmailAdd))
               .ReverseMap();
            CreateMap<UserNewsTable, UserNewsVm>()
               .ForMember(dest =>
                                   dest.UserNewsIdVm,
                                   opt => opt.MapFrom(src => src.UserNewsId))
               .ForMember(dest =>
                                   dest.UserIdVm,
                                   opt => opt.MapFrom(src => src.UserId))
               .ForMember(dest =>
                                   dest.NewsIdVm,
                                   opt => opt.MapFrom(src => src.NewsId))
               .ForMember(dest =>
                                   dest.DateVm,
                                   opt => opt.MapFrom(src => src.Date))
               .ReverseMap();
            CreateMap<ConcatenatedTable, ConcatenatedTableVm>()
               .ForMember(dest =>
                                   dest.UserNewsIdVm,
                                   opt => opt.MapFrom(src => src.UserNewsId))
               .ForMember(dest =>
                                   dest.UserIdVm,
                                   opt => opt.MapFrom(src => src.UserId))
               .ForMember(dest =>
                                   dest.NewsIdVm,
                                   opt => opt.MapFrom(src => src.NewsId))
               .ForMember(dest =>
                                   dest.DateVm,
                                   opt => opt.MapFrom(src => src.Date))
               .ForMember(dest =>
                                  dest.NewsUrlVm,
                                  opt => opt.MapFrom(src => src.NewsUrl))
              .ForMember(dest =>
                                  dest.NewsTitleVm,
                                  opt => opt.MapFrom(src => src.NewsTitle))
              .ForMember(dest => dest.NewsDescriptionVm,
                                 opt => opt.MapFrom(src => src.NewsDescription))
              .ForMember(dest => dest.NewsImageUrlVm,
                                 opt => opt.MapFrom(src => src.NewsImageUrl))
               .ReverseMap();





            CreateMap<GetTopUsers, GetTopUsersVm>()
                
                //.ForMember(dest =>
                //                       dest.UserIdVm,
                //                       opt => opt.MapFrom(src => src.UserId))
                //   .ForMember(dest =>
                //                       dest.JunctionUserIdVm,
                //                       opt => opt.MapFrom(src => src.JunctionUserId))
                   .ForMember(dest =>
                                       dest.FirstNameVm,
                                       opt => opt.MapFrom(src => src.FirstName))
                   .ForMember(dest =>
                                       dest.LastNameVm,
                                       opt => opt.MapFrom(src => src.LastName))
                   //.ForMember(dest =>
                   //                    dest.TotalVm,
                   //                    opt => opt.MapFrom(src => src.Total))
               
                                  
                   .ReverseMap();


        }

    }
}

