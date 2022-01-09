//using Newsopedia.Data.Entities;
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
        public bool LoginCheck(User user);
        public void NewsTableCheckUrl(JsonModel jsonModel);
        public List<UserNewsTable> HistoryDatesDisplay(EmailAddress emailAddress);
        public List<ConcatenatedTable> RetrieveNewsFromDB(UserNewsTable userNews);
        public void DeleteNewsItemFromDB(UserNewsTable userNews);
        public List<GetTopUsers> GetTopFiveUsersFromDB();
        //public void DateURLTableupdate(JsonModel jsonModel);

        //public List<DateUrl> HistoryLinksDisplay(EmailAddress emailAddress);
        //public List<DateUrl> RetrieveNewsLinksFromDB(DateUrl dateUrl);
        //public void DeleteNewsItemFromDB(DateUrl dateUrl);

    }
    public class NewsopediaRepository : INewsopediaRepository

    {
        //NewsopediaContext _context;
        NewsopediaOldContext _oldContext;
        public NewsopediaRepository(/*NewsopediaContext newsopediaEntities,*/ NewsopediaOldContext newsopediaOldentities)
        {
            //_context = newsopediaEntities;
            _oldContext = newsopediaOldentities;
        }
        //------------------------------------------------
        //-This part of code uses tables from 'Test' database.
        //-This is migrated to 'NewsopediaOld' database
        //-----------------------------------------------------
        //[HttpPost]
        //public bool LoginCheck(Entities.User user)
        //{
        //    var usr = _context.User.SingleOrDefault(u => u.Email == user.Email && u.Password == user.Password);
        //    if (usr != null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}

        //---------------------------------------------------
        //- Authenticating the user credentials
        //---------------------------------------------------
        [HttpPost]
        public bool LoginCheck(User user)
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

        //public void NewsTableCheckUrl(JsonModel jsonModel)
        //{
        //    throw new NotImplementedException();
        //}

        //public void RegisterNewUser(User user)
        //{
        //    throw new NotImplementedException();
        //}

        //public void DateURLTableupdate(JsonModel jsonModel)
        //{
        //    Entities.User userLoggedIn = _context.User.Where(u => u.Email == jsonModel.UserEmail).SingleOrDefault<Entities.User>();


        //    //update date table
        //    DateUrl dateUrl = new DateUrl();
        //    var dateAndTime = DateTime.Today;

        //    dateUrl.Date =  dateAndTime.ToShortDateString();
        //    dateUrl.UserID = userLoggedIn;
        //    dateUrl.NewsUrl = jsonModel.URL;
        //    dateUrl.NewsTitle = jsonModel.Title;
        //    dateUrl.NewsDescription = jsonModel.Description;
        //    dateUrl.NewsImageURL = jsonModel.URLToImage;
        //    _context.DateUrls.Add(dateUrl);
        //    _context.SaveChanges();


        //}
        public void NewsTableCheckUrl(JsonModel jsonModel)
        {

            NewsTable news = _oldContext.NewsTables.Where(u => u.NewsUrl == jsonModel.URL).SingleOrDefault<NewsTable>();
            if (news == null)
            {
                NewsTable newsTable = new NewsTable();
                newsTable.NewsUrl = jsonModel.URL;
                newsTable.NewsTitle = jsonModel.Title;
                newsTable.NewsDescription = jsonModel.Description;
                newsTable.NewsImageUrl = jsonModel.URLToImage;
                //Update NewsTable
                _oldContext.NewsTables.Add(newsTable);
                _oldContext.SaveChanges();

                //Update Junction Table
                User userLoggedIn = _oldContext.Users.Where(u => u.Email == jsonModel.UserEmail).SingleOrDefault<User>();
                UserNewsTable userNewsTable = new UserNewsTable();
                userNewsTable.UserId = userLoggedIn.UserId;
                userNewsTable.NewsId = newsTable.NewsId;
                var dateAndTime = DateTime.Today;
                userNewsTable.Date = dateAndTime.ToShortDateString();
                _oldContext.UserNewsTables.Add(userNewsTable);
                _oldContext.SaveChanges();


            }
            else
            {
                //Update Junction Table
                User userLoggedIn = _oldContext.Users.Where(u => u.Email == jsonModel.UserEmail).SingleOrDefault<User>();
                UserNewsTable userNewsTable = new UserNewsTable();
                userNewsTable.UserId = userLoggedIn.UserId;
                userNewsTable.NewsId = news.NewsId;
                var dateAndTime = DateTime.Today;
                userNewsTable.Date = dateAndTime.ToShortDateString();
                _oldContext.UserNewsTables.Add(userNewsTable);
                _oldContext.SaveChanges();

            }
        }
        //----------------------------------------
        //---Migrating to a new database ---------
        //----------------------------------------

        //public void RegisterNewUser(User user)
        //    {
        //        var newUser = _context.Add(user);
        //        _context.SaveChanges();
        //    }

        public void RegisterNewUser(User user)
        {
            var newUser = _oldContext.Add(user);
            _oldContext.SaveChanges();
        }

        //public List<DateUrl> HistoryLinksDisplay(EmailAddress emailAddress)
        //{
        //    Entities.User userLoggedIn = _context.User.Where(u => u.Email == emailAddress.EmailAdd).SingleOrDefault<Entities.User>();
        //    List<DateUrl> historyLinks = new List<DateUrl>();
        //    historyLinks = _context.DateUrls.Where(u => u.UserID.UserId == userLoggedIn.UserId).ToList();
        //    return historyLinks;



        //}
        public List<UserNewsTable> HistoryDatesDisplay(EmailAddress emailAddress)
        {
            User userLogginIn = _oldContext.Users.Where(u => u.Email == emailAddress.EmailAdd).SingleOrDefault();
            List<UserNewsTable> historyDates = new List<UserNewsTable>();
            historyDates = _oldContext.UserNewsTables.Where(u => u.UserId == userLogginIn.UserId).ToList();
            return historyDates;
        }

        //public List<DateUrl> RetrieveNewsLinksFromDB(DateUrl dateUrl)
        //{
        //    List<DateUrl> dateUrls = new List<DateUrl>();
        //    dateUrls = _context.DateUrls.Where(u => u.Date == dateUrl.Date && u.UserID==dateUrl.UserID).ToList();
        //    return dateUrls;
        //}
        public List<ConcatenatedTable> RetrieveNewsFromDB(UserNewsTable userNews)
        {

            List<ConcatenatedTable> result = _oldContext.NewsTables  // your starting point - table in the "from" statement
                          .Join(_oldContext.UserNewsTables, // the source table of the inner join
                      u => u.NewsId,        // Select the primary key (the first part of the "on" clause in an sql "join" statement)
                      v => v.NewsId,   // Select the foreign key (the second part of the "on" clause)
                          (u, v) => new { u, v }) // selection
                      .Where(x => x.v.Date==userNews.Date && x.v.UserId==userNews.UserId/*x.v.NewsId == userNews.NewsId*/).Select(y => new ConcatenatedTable
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

        


            //var historyViewed = _oldContext.UserNewsTables.Where(u => u.Date == userNews.Date && u.UserId == userNews.UserId).Select(v => v.NewsId);
        

            //List<NewsTable> News= _oldContext.NewsTables.Where(u =>historyViewed.Contains(u.NewsId)).ToList();
            
           
            return result;

        }
        //------------------------------------------------
        ///-This part of code uses tables from 'Test' database.
        //-This is migrated to 'NewsopediaOld' database
        //------------------------------------------------

        //public void DeleteNewsItemFromDB(DateUrl dateUrl)
        //{
        //    DateUrl NewsClickedByAdmin = _context.DateUrls.SingleOrDefault(u=>u.DateUrlID==dateUrl.DateUrlID);
        //    _context.DateUrls.Remove(NewsClickedByAdmin);
        //    _context.SaveChanges();
        //}
        //--------------------------------------------------
        //Gets the NewsId to be deleted from screen
        //Checks the UserNewsTable for its existence and deltes the 
        //same
        //--------------------------------------------------


        public void DeleteNewsItemFromDB(UserNewsTable userNews)
        {
            UserNewsTable NewsClickedByAdmin = _oldContext.UserNewsTables.SingleOrDefault(u => u.UserNewsId==userNews.UserNewsId);
            _oldContext.UserNewsTables.Remove(NewsClickedByAdmin);
            _oldContext.SaveChanges();
        }

        public List<GetTopUsers> GetTopFiveUsersFromDB()
        {
            List<GetTopUsers> topUsers = new List<GetTopUsers>();
            topUsers = _oldContext.GetTopUsers.FromSqlRaw<GetTopUsers>("SPGetTopFiveUsers").ToList();
            //var topUsers = _oldContext.Set<GetTopUsers>
            //    ("SPGetTopFiveUsers");

            //return null;
            return topUsers;
        }
    }
}
