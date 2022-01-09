using AutoMapper;
using Microsoft.Extensions.Logging;
using Newsopedia.Data;
//using Newsopedia.Data.Entities;
using Newsopedia.Data.Models;
//using Newsopedia.Services.Models;
using Newsopedia.Services.NewsopediaOldModels;
using System;
using System.Collections.Generic;

namespace Newsopedia.Services
{
    public interface INewsopediaService
    {
        public void RegisterUser(NewsopediaOldUserVm user);
        public bool CheckLogin(NewsopediaOldUserVm userVm);
        public void CheckNewsTable(JsonModelVm jsonModelVm);
        public List<UserNewsVm> DisplayHistoryDates(EmailAddressVm emailAddressVm);
        public List<ConcatenatedTableVm> RetrieveNewsHistory(UserNewsVm userNewsVm);
        public void DeleteNewsItem(UserNewsVm userNews);
        public List<GetTopUsersVm> GetTopFiveUsers();

        //public void updateDateuRLTable(JsonModelVm jsonModelVm);
        //public List<DateUrlVm> DisplayHistoryLinks(EmailAddressVm emailAddressVm);
        //public List<DateUrlVm> RetrieveNewsLinks(DateUrlVm dateUrlVm);
        //public void DeleteNewsItem(DateUrlVm dateUrlVm);

    }

    public class NewsopediaService : INewsopediaService
    {
        private INewsopediaRepository _newsopediaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public NewsopediaService(INewsopediaRepository newsopediaRepository, IMapper mapper, ILogger logger)
        {
            _newsopediaRepository = newsopediaRepository;
            _mapper = mapper;
            _logger = logger;

        }
        //-------------------------------------
        //-This part of code uses tables from 'Test' database.
        //-This is migrated to 'NewsopediaOld' database
        //-------------------------------------
        //public void RegisterUser(UserVm userVm)
        //{
        //    try
        //    {
        //     var newUser = _mapper.Map<User>(userVm);
        //        _newsopediaRepository.RegisterNewUser(newUser);
        //    }
        //    catch (Exception e)
        //    {

        //        _logger.LogError(e.ToString());
        //    }

        //}
        //------------------------------------------
        //Registering the user details to the new --
        // database NewsopediaOld                 --
        //------------------------------------------
        public void RegisterUser(NewsopediaOldUserVm userVm)
        {
            try
            {
                var newUser = _mapper.Map<User>(userVm);
                _newsopediaRepository.RegisterNewUser(newUser);
            }
            catch (Exception e)
            {

                _logger.LogError(e.ToString());
            }

        }
        //-----------------------------------------------
        //-This part of code uses tables from 'Test' database.
        //-This is migrated to 'NewsopediaOld' database
        //-
        //------------------------------------------------
        //public bool CheckLogin(UserVm userVm)
        //{
        //    var loginUser = _mapper.Map<Data.Entities.User>(userVm);
        //    return _newsopediaRepository.LoginCheck(loginUser);
        //}
        public bool CheckLogin(NewsopediaOldUserVm userVm)
        {
            var loginUser = _mapper.Map<User>(userVm);
            return _newsopediaRepository.LoginCheck(loginUser);
        }
        //------------------------------------------------
        ///-This part of code uses tables from 'Test' database.
        //-This is migrated to 'NewsopediaOld' database
        //------------------------------------------------    

        //public void updateDateuRLTable(JsonModelVm jsonModelVm)
        //{
        //    var newsClicked = _mapper.Map<JsonModel>(jsonModelVm);
        //    _newsopediaRepository.DateURLTableupdate(newsClicked);
        //}

        //------------------------------------------------
        //-Check if the clicked url already exists in the
        //News Table
        //----------------------------------------------
        public void CheckNewsTable(JsonModelVm jsonModelVm)
        {
            var newsClicked = _mapper.Map<JsonModel>(jsonModelVm);
            _newsopediaRepository.NewsTableCheckUrl(newsClicked);

        }
        //------------------------------------------------
        ///-This part of code uses tables from 'Test' database.
        //-This is migrated to 'NewsopediaOld' database
        //------------------------------------------------ 

        //public List<DateUrlVm> DisplayHistoryLinks(EmailAddressVm emailAddressVm)
        //{
        //    var loggedInUserEmail = _mapper.Map<EmailAddress>(emailAddressVm);
        //    List<DateUrlVm> dateUrls = _mapper.Map<List<DateUrlVm>>(_newsopediaRepository.HistoryLinksDisplay(loggedInUserEmail));
        //    return dateUrls;
        //}
        //--------------------------------------------------------
        //Receives the user email and displays the history of dates visted 
        //by the user
        //----------------------------------------------------------
        public List<UserNewsVm> DisplayHistoryDates(EmailAddressVm emailAddressVm)
        {
            var loggedInUserEmail = _mapper.Map<EmailAddress>(emailAddressVm);
            List<UserNewsVm> historyDates = _mapper.Map<List<UserNewsVm>>(_newsopediaRepository.HistoryDatesDisplay(loggedInUserEmail));
            return historyDates;
        }
        //------------------------------------------------
        ///-This part of code uses tables from 'Test' database.
        //-This is migrated to 'NewsopediaOld' database
        //------------------------------------------------
        //public List<DateUrlVm> RetrieveNewsLinks(DateUrlVm dateUrlVm)
        //{
        //    var dateClickedByUser = _mapper.Map<DateUrl>(dateUrlVm);
        //   List<DateUrlVm> dateUrlVms =_mapper.Map<List<DateUrlVm>>(_newsopediaRepository.RetrieveNewsLinksFromDB(dateClickedByUser));

        //    return dateUrlVms;
        //}
        //------------------------------------------------------
        //-Gets the user date and news Id, to display the news that were 
        //viewed by the user earlier
        //----------------------------------------------------

        public List<ConcatenatedTableVm> RetrieveNewsHistory(UserNewsVm userNewsVm)
        {
            var dateClickedByUser = _mapper.Map<UserNewsTable>(userNewsVm);
            List<ConcatenatedTableVm> newsViewed = _mapper.Map<List<ConcatenatedTableVm>>(_newsopediaRepository.RetrieveNewsFromDB(dateClickedByUser));
            return newsViewed;
    }
        //------------------------------------------------
        ///-This part of code uses tables from 'Test' database.
        //-This is migrated to 'NewsopediaOld' database
        //------------------------------------------------
        //public void DeleteNewsItem(DateUrlVm dateUrlVm)
        //{
        //    var itemClickedByAdmin = _mapper.Map<DateUrl>(dateUrlVm);
        //    _newsopediaRepository.DeleteNewsItemFromDB(itemClickedByAdmin);
        //}
        //--------------------------------------------
        //Gets the NewsId to be deleted from screen
        //Checks the UserNewsTable for its existence and deltes the 
        //same
        //--------------------------------------------------

        public void DeleteNewsItem(UserNewsVm userNews)
        {
            var itemClickedByAdmin = _mapper.Map<UserNewsTable>(userNews);
            _newsopediaRepository.DeleteNewsItemFromDB(itemClickedByAdmin);
        }
        public List<GetTopUsersVm> GetTopFiveUsers()
        {
            List<GetTopUsersVm> users = _mapper.Map <List<GetTopUsersVm>>(_newsopediaRepository.GetTopFiveUsersFromDB());
          
            return users;
        }

    }

}
