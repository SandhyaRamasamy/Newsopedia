using AutoMapper;
using Microsoft.Extensions.Logging;
using Newsopedia.Data;
using Newsopedia.Data.Models;
using Newsopedia.Services.NewsopediaOldModels;
using System;
using System.Collections.Generic;

namespace Newsopedia.Services
{
    public interface INewsopediaService
    {
        public void RegisterUser(NewsopediaOldUserVm user);
        public bool AuthenticateUser(NewsopediaOldUserVm userVm);
        public void CheckNewsTableIfArticleExists(NewsArticleVm newsArticleVm);
        public List<UserNewsVm> DisplayHistoryDatesOfUser(EmailAddressVm emailAddressVm);
        public List<ConcatenatedTableVm> RetrieveNewsFromHistory(UserNewsVm userNewsVm);
        public void DeleteNewsItem(UserNewsVm userNews);
        public List<GetTopUsersVm> GetTopThreeUsers();
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
        /// <summary>
        /// Register the user details in the database
        /// </summary>
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
        /// <summary>
        /// Authenticates the user with the credentials
        /// </summary>
        /// <param name="userVm"></param>
        /// <returns></returns>
        public bool AuthenticateUser(NewsopediaOldUserVm userVm)
        {
            var loginStatus = false;
            try
            {
               var loginUser = _mapper.Map<User>(userVm);
               loginStatus = _newsopediaRepository.AuthenticateUser(loginUser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return loginStatus;
        }
        /// <summary>
        /// Check the NewsTable if the news item exists already
        /// </summary>
        /// <param name="newsArticleVm"></param>
        public void CheckNewsTableIfArticleExists(NewsArticleVm newsArticleVm)
        {
            try
            {
                var newsItemClicked = _mapper.Map<NewsArticle>(newsArticleVm);
                _newsopediaRepository.CheckIfNewsArticleExistsInDb(newsItemClicked);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }
        /// <summary>
        /// Retrieves all the dates that the user viewed the news
        /// </summary>
        /// <param name="emailAddressVm"></param>
        /// <returns></returns>
        public List<UserNewsVm> DisplayHistoryDatesOfUser(EmailAddressVm emailAddressVm)
        {
            var historyDatesOfUser = new List<UserNewsVm>();
            try
            {
                var loggedInUserEmail = _mapper.Map<EmailAddress>(emailAddressVm);
                historyDatesOfUser = _mapper.Map<List<UserNewsVm>>(_newsopediaRepository.RetrieveUserHistoryDates(loggedInUserEmail));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return historyDatesOfUser;
        }
        /// <summary>
        /// Retrieves all the news articles viewed by the user for a particular date clicked.
        /// </summary>
        /// <param name="userNewsVm"></param>
        /// <returns></returns>
        public List<ConcatenatedTableVm> RetrieveNewsFromHistory(UserNewsVm userNewsVm)
        {
            var  newsArticlesOfUser = new List<ConcatenatedTableVm>();
            try
            {
                var dateClickedByUser = _mapper.Map<UserNewsTable>(userNewsVm);
                newsArticlesOfUser = _mapper.Map<List<ConcatenatedTableVm>>(_newsopediaRepository.RetrieveNewsFromDb(dateClickedByUser));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return newsArticlesOfUser;
        }
        /// <summary>
        /// Admin deletes a news item by clicking delete button that is visible only to the admin
        /// </summary>
        /// <param name="userNews"></param>
        public void DeleteNewsItem(UserNewsVm userNews)
        {
            try
            {
                var itemClickedByAdmin = _mapper.Map<UserNewsTable>(userNews);
                _newsopediaRepository.DeleteNewsItemFromDb(itemClickedByAdmin);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }
        /// <summary>
        /// Retrieves the top five users who have viewed the news articles from the application 
        /// maximum number of times
        /// </summary>
        /// <returns></returns>
        public List<GetTopUsersVm> GetTopThreeUsers()
        {
            var topUsers = new List<GetTopUsersVm>();
            try
            {
                topUsers = _mapper.Map<List<GetTopUsersVm>>(_newsopediaRepository.GetTopThreeUsersFromDb());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return topUsers;
        }        
    }
}




