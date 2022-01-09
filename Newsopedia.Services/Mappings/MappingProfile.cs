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
            CreateMap<DateUrl, DateUrlVm>()
                .ForMember(dest =>
                                    dest.DateUrlIDVm,
                                    opt => opt.MapFrom(src => src.DateUrlID))
                .ForMember(dest =>
                                    dest.UserIDVm,
                                    opt => opt.MapFrom(src => src.UserID))
                .ForMember(dest =>
                                    dest.DateVm,
                                    opt => opt.MapFrom(src => src.Date))
                .ForMember(dest =>
                                    dest.NewsTitleVm,
                                    opt => opt.MapFrom(src => src.NewsTitle))
                .ForMember(dest =>
                                    dest.NewsUrlVm,
                                    opt => opt.MapFrom(src => src.NewsUrl))
                .ForMember(dest =>
                                    dest.NewsDescriptionvM,
                                    opt => opt.MapFrom(src => src.NewsDescription))
                .ForMember(dest =>
                                    dest.NewsImageURLVm,
                                    opt => opt.MapFrom(src => src.NewsImageURL))
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
                                  opt => opt.MapFrom( src=> src.Description))
               .ForMember(dest => dest.URLToImageVm,
                                  opt => opt.MapFrom(src => src.URLToImage))

               .ReverseMap();
            CreateMap<EmailAddress, EmailAddressVm>()
               .ForMember(dest =>
                                   dest.UserEmailaddressVm,
                                   opt => opt.MapFrom(src => src.EmailAdd))
               .ReverseMap();
          



        }
    }
}
