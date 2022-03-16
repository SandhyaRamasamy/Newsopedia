using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newsopedia.Models;
using Newsopedia.Services;
using Newsopedia.Services.NewsopediaOldModels;
using System.Collections.Generic;
using System.Diagnostics;

namespace Newsopedia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INewsopediaService _newsopediaService;
        private readonly IConfiguration _configuration;
        public HomeController(INewsopediaService newsopediaService, ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _newsopediaService = newsopediaService;
            _configuration = configuration;
        }
        /// <summary>
        /// Login Page
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        /// <summary>
        /// Registration Page 
        /// </summary>
        /// <returns></returns>
        public IActionResult Register()
        {
            return View("Register");
        }
        /// <summary>
        /// Regisering the user details into the table in the
        /// database
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Index</returns>
        public IActionResult RegisterFunction(NewsopediaOldUserVm user)
        {
            _newsopediaService.RegisterUser(user);
            return View("Index");
        }
        /// <summary>
        /// Authenticating the User credentials
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Successful login (or) Login failed</returns>
        public IActionResult CheckCredentialsFunction(NewsopediaOldUserVm user)
        {
            var loginStatus = _newsopediaService.AuthenticateUser(user);
            if (loginStatus == true)
            {
                HttpContext.Session.SetString("UserName", user.Email);
                return RedirectToAction("LoginSuccess");
            }
            else
            {
                return RedirectToAction("LoginFailed");
            }
        }
        /// <summary>
        /// Lists the top 5 users (5 users who have searched the
        /// most news items
        /// </summary>
        /// <returns></returns>
        public IActionResult GetTopUsers()
        {
            var topUsersVm = _newsopediaService.GetTopThreeUsers();
            return View(topUsersVm);
        }
        /// <summary>
        /// When the user authentication fails, control gets navigated to this page
        /// </summary>
        /// <returns></returns>
        public IActionResult LoginFailed()
        {
            return View();
        }
        /// <summary>
        /// Retrieves the UserName of the user after successful authentication
        /// </summary>
        /// <returns></returns>
        public IActionResult LoginSuccess()
        {
            if (HttpContext.Session.GetString("UserName") != null)
            {
                ViewBag.sessionVar = HttpContext.Session.GetString("UserName");
                return View();
            }
            else
            {
                return View("Index");
            }
        }
        /// <summary>
        /// Check if the clicked url already exists in the News Table
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CheckExistenceOfNewsInNewsTable(NewsArticleVm newsArticleVm)
        {
            _newsopediaService.CheckNewsTableIfArticleExists(newsArticleVm);
            return View("LoginSuccess");
        }
        /// <summary>
        /// Receives the user email and displays the history dates
        /// visted by the user
        /// </summary>
        /// <param name="emailAddressVm"></param>
        /// <returns>History</returns>
        [HttpPost]
        public PartialViewResult GetEmailAddressOfUserLoggedIn(EmailAddressVm emailAddressVm)
        {
            var userNewsVms = _newsopediaService.DisplayHistoryDatesOfUser(emailAddressVm);
            return PartialView("_History", userNewsVms);
        }
        /// <summary>
        /// Gets the History Date clicked and NewsId, to display the
        /// news that were viewed by the user earlier
        /// </summary>
        /// <param name="userNewsVm"></param>
        /// <returns></returns>
        public PartialViewResult NewsArticlesViewedByUserOnADate(UserNewsVm userNewsVm)
        {
            ViewBag.sessionV = HttpContext.Session.GetString("UserName");
            List<ConcatenatedTableVm> newsViewed = _newsopediaService.RetrieveNewsFromHistory(userNewsVm);
            return PartialView("_HistoryPerDate",newsViewed);
        }
        /// <summary>
        /// Gets the NewsId to be deleted from screen and checks the
        /// UserNewsTable for its existence and deletes the same
        /// </summary>
        /// <param name="userNewsVm"></param>
        /// <returns></returns>
        public IActionResult DeleteNewsItem(UserNewsVm userNewsVm)
        {
            _newsopediaService.DeleteNewsItem(userNewsVm);
            return PartialView("_DeleteAdminItem");
        }
        /// <summary>
        /// When the user clicks logout button, the control gets navigated to this page
        /// </summary>
        /// <returns></returns>
        public IActionResult LogoutPage()
        {
            HttpContext.Session.Remove("UserName");
            return View();
        }
        /// <summary>
        /// Gets the News API url from appsettings.json file.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetNewsApiUrl()
        {
            return Json(_configuration.GetValue<string>("NewsApiUrl"));
        }
        /// <summary>
        /// Gets the API key from appsettings.json file
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetNewsApiKey()
        {
            return Json(_configuration.GetValue<string>("NewsApiKey"));
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}