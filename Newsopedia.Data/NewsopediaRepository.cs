using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newsopedia.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Newsopedia.Data
{
    public interface INewsopediaRepository
    {
        public void RegisterNewUser(User user);
        public bool AuthenticateUser(User user);
        public void CheckIfNewsArticleExistsInDb(NewsArticle newsArticle);
        public List<UserNewsTable> RetrieveUserHistoryDates(EmailAddress emailAddress);
        public List<ConcatenatedTable> RetrieveNewsFromDb(UserNewsTable userNews);
        public void DeleteNewsItemFromDb(UserNewsTable userNews);
        public List<GetTopUsers> GetTopThreeUsersFromDb();        
    }
    public class NewsopediaRepository : INewsopediaRepository
    {        
        NewsopediaOldContext _oldContext;
        public NewsopediaRepository(NewsopediaOldContext newsopediaOldentities)
        {            
            _oldContext = newsopediaOldentities;
        }
        /// <summary>
        ///  Authenticates the user with the credentials entered
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>   
        public bool AuthenticateUser(User user)
        {
            var usr = _oldContext.Users.SingleOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if (usr != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       /// <summary>
       /// Check if the news article was viewed already by the user
       /// </summary>
       /// <param name="jsonModel"></param>        
        public void CheckIfNewsArticleExistsInDb(NewsArticle newsArticle)
        {
            var news = _oldContext.NewsTables.Where(u => u.NewsUrl == newsArticle.Url).SingleOrDefault<NewsTable>();
            if (news == null)
            {
                var newsTable = new NewsTable();
                newsTable.NewsUrl = newsArticle.Url;
                newsTable.NewsTitle = newsArticle.Title;
                newsTable.NewsDescription = newsArticle.Description;
                newsTable.NewsImageUrl = newsArticle.UrlToImage;
                //Update NewsTable
                _oldContext.NewsTables.Add(newsTable);
                _oldContext.SaveChanges();
                //Get NewsId from NewsTable
                var userNewsTable = new UserNewsTable();
                userNewsTable.NewsId = newsTable.NewsId;
                UpdateJunctionTable(userNewsTable,newsArticle);
            }
            else
            {
                //Get NewsId from Junction Table
                var userNewsTable = new UserNewsTable();
                userNewsTable.NewsId = news.NewsId;
                UpdateJunctionTable(userNewsTable,newsArticle);
            }                  
        }
        /// <summary>
        /// Register a new User to the database
        /// </summary>
        /// <param name="user"></param>
        public void RegisterNewUser(User user)
        {
            var newUser = _oldContext.Add(user);
            _oldContext.SaveChanges();
        }      
        /// <summary>
        /// Retrieves all the dates previously visited by the user
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public List<UserNewsTable> RetrieveUserHistoryDates(EmailAddress emailAddress)
        {
            var userLoggedIn = _oldContext.Users.Where(u => u.Email == emailAddress.EmailId).SingleOrDefault();
            var historyDates = new List<UserNewsTable>();
            return _oldContext.UserNewsTables.Where(u => u.UserId == userLoggedIn.UserId).ToList();            
        }
        /// <summary>
        /// Retrieves the news articles that were viewed on a particulate date from database
        /// </summary>
        /// <param name="userNews"></param>
        /// <returns></returns>       
        public List<ConcatenatedTable> RetrieveNewsFromDb(UserNewsTable userNews)
        {
            return _oldContext.NewsTables  
                          .Join(_oldContext.UserNewsTables, 
                      u => u.NewsId,        
                      v => v.NewsId,   
                          (u, v) => new { u, v }) 
                      .Where(x => x.v.Date==userNews.Date && x.v.UserId==userNews.UserId).Select(y => new ConcatenatedTable
                      {
                          UserId = y.v.UserId,
                          UserNewsId = y.v.UserNewsId,
                          Date = y.v.Date,
                          NewsId=y.v.NewsId,
                          NewsUrl = y.u.NewsUrl,
                          NewsDescription = y.u.NewsDescription,
                          NewsTitle = y.u.NewsTitle,
                          NewsImageUrl = y.u.NewsImageUrl
                      }).ToList(); 
        }
        /// <summary>
        /// Admin deletes a news item by clicking delete button that is visible only to the admin
        /// </summary>
        /// <param name="userNews"></param>
        public void DeleteNewsItemFromDb(UserNewsTable userNews)
        {
            var NewsClickedByAdmin = _oldContext.UserNewsTables.SingleOrDefault(u => u.UserNewsId==userNews.UserNewsId);
            _oldContext.UserNewsTables.Remove(NewsClickedByAdmin);
            _oldContext.SaveChanges();
        }
        /// <summary>
        /// Retrieves the top five users who have viewed the news articles from the application 
        /// maximum number of times
        /// </summary>
        /// <returns></returns>
        public List<GetTopUsers> GetTopThreeUsersFromDb()
        {           
            return _oldContext.GetTopUsers.FromSqlRaw<GetTopUsers>("SPGetTopFiveUsers").ToList();       
        }
        /// <summary>
        /// Update the junction table with news article viewed and the current date
        /// </summary>
        /// <param name="userNewsTable"></param>
        /// <param name="newsArticle"></param>
        public void UpdateJunctionTable(UserNewsTable userNewsTable, NewsArticle newsArticle)
        {
            var userLoggedIn = _oldContext.Users.Where(u => u.Email == newsArticle.UserEmail).SingleOrDefault<User>();
            userNewsTable.UserId = userLoggedIn.UserId;
            var dateAndTime = DateTime.Today;
            userNewsTable.Date = dateAndTime.ToShortDateString();
            _oldContext.UserNewsTables.Add(userNewsTable);
            _oldContext.SaveChanges();
        }
    }
}
