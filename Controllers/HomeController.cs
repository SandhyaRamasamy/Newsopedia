using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newsopedia.Models;
using Newsopedia.Services;
//using Newsopedia.Services.Models;
using Newsopedia.Services.NewsopediaOldModels;
using System.Collections.Generic;
using System.Diagnostics;


namespace Newsopedia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INewsopediaService _newsopediaService;
       

        public HomeController(INewsopediaService newsopediaService, ILogger<HomeController> logger)
        {
            _logger = logger;
            _newsopediaService = newsopediaService;
        }

        public IActionResult Index()
        {
            //HttpContext.Session.SetString("UserName", "sandhya9028@gmail.com");

            //return RedirectToAction("LoginSuccess");
            return View();
        }
        

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View("Register");
        }
        /***********************************/
        /*Migrated to a new database        */
        /***********************************/
        //public IActionResult RegisterFunction(UserVm user)
        //{
        //    _newsopediaService.RegisterUser(user);
        //    return View("Index");
        //}
        /****************************************/
        /* Regisering the user details into a new table in the 
        /* new database
        //****************************************/
        public IActionResult RegisterFunction(NewsopediaOldUserVm user)
        {
            _newsopediaService.RegisterUser(user);
            return View("Index");
        }

        //-----------------------------------------------------
        //-This part of code uses tables from 'Test' database.
        //-This is migrated to 'NewsopediaOld' database
        //----------------------------------------------------
        //public IActionResult CheckCredentialsFunction(UserVm user)
        //{

        //   var loginStatus= _newsopediaService.CheckLogin(user);
        //   if (loginStatus == true)
        //   {

        //        HttpContext.Session.SetString("UserName", user.EmailVm);

        //       return RedirectToAction("LoginSuccess");
        //    }
        //    else
        //   {
        //       return RedirectToAction("LoginFailed");
        //   }
        //}

        //-------------------------------------------------
        //-Authenticating the User credentials
        //-----------------------------------------------
        public IActionResult CheckCredentialsFunction(NewsopediaOldUserVm user)
        {

            var loginStatus = _newsopediaService.CheckLogin(user);
            if (loginStatus == true)
            {

                HttpContext.Session.SetString("UserName", user.EmailVm);

                return RedirectToAction("LoginSuccess");
            }
            else
            {
                return RedirectToAction("LoginFailed");
            }
        }
        public IActionResult GetTopUsers()
        {
            List<GetTopUsersVm> topUsersVm = new List<GetTopUsersVm>();
            topUsersVm=_newsopediaService.GetTopFiveUsers(); 
            return View(topUsersVm);
        }
        public IActionResult LoginFailed()
        {
            return View();
        }


        public IActionResult LoginSuccess()

        {
            if (HttpContext.Session.GetString("UserName") != null)
            {

                ViewBag.sessionV = HttpContext.Session.GetString("UserName");
                return View();
            }
            else
            {
                return View("Index");
            }
        }
        //------------------------------------------------
        ///-This part of code uses tables from 'Test' database.
        //-This is migrated to 'NewsopediaOld' database
        //------------------------------------------------
        //[HttpPost]
        //public IActionResult GetJsonData(JsonModelVm jsonModelVm)
        //{

        //    _newsopediaService.updateDateuRLTable(jsonModelVm);


        //    return View("
        //
        //    Success");
        //}
        //------------------------------------------------
        //-Check if the clicked url already exists in the 
        //News Table
        //----------------------------------------------
        [HttpPost]
        public IActionResult CheckUrlInNewsTable(JsonModelVm jsonModelVm)
        {

            _newsopediaService.CheckNewsTable(jsonModelVm);


            return View("LoginSuccess");
        }
        //------------------------------------------------
        ///-This part of code uses tables from 'Test' database.
        //-This is migrated to 'NewsopediaOld' database
        //------------------------------------------------

        //[HttpPost]
        //public PartialViewResult GetEmail(EmailAddressVm emailAddressVm)
        //{

        //    List<DateUrlVm> dateUrlsVm = _newsopediaService.DisplayHistoryLinks(emailAddressVm);
        //    return PartialView("_History", dateUrlsVm);
        //}

        //--------------------------------------------------------
        //Receives the user email and displays the history of dates visted 
        //by the user
        //----------------------------------------------------------
        [HttpPost]
        public PartialViewResult GetEmail(EmailAddressVm emailAddressVm)
        {

            List<UserNewsVm> userNewsVms = _newsopediaService.DisplayHistoryDates(emailAddressVm);
           return PartialView("_History", userNewsVms);
        }
        //------------------------------------------------
        ///-This part of code uses tables from 'Test' database.
        //-This is migrated to 'NewsopediaOld' database
        //------------------------------------------------
        //public PartialViewResult _HistoryPerDate(DateUrlVm dateUrlVm)
        //{
        //    ViewBag.sessionV = HttpContext.Session.GetString("UserName");
        //    List<DateUrlVm> dateUrlsVm= _newsopediaService.RetrieveNewsLinks(dateUrlVm);
        //    return PartialView(dateUrlsVm);
        //}
        //------------------------------------------------------
        //-Gets the user date and news Id, to display teh news that were 
        //viewed by the user earlier
        //----------------------------------------------------
        public PartialViewResult _HistoryPerDate(UserNewsVm userNewsVm)
        {
            ViewBag.sessionV = HttpContext.Session.GetString("UserName");
            List<ConcatenatedTableVm> newsViewed =_newsopediaService.RetrieveNewsHistory(userNewsVm);
            return PartialView(newsViewed);
        }
        //------------------------------------------------
        ///-This part of code uses tables from 'Test' database.
        //-This is migrated to 'NewsopediaOld' database
        //------------------------------------------------

        //public IActionResult DeleteItem(DateUrlVm dateUrlVm)
        //{
        //    _newsopediaService.DeleteNewsItem(dateUrlVm);
        //    return PartialView("_DeleteAdminItem");
        //}
        //--------------------------------------------
        //Gets the NewsId to be deleted from screen
        //Checks the UserNewsTable for its existence and deltes the 
        //same
        //--------------------------------------------------
        public IActionResult DeleteItem(UserNewsVm userNewsVm)
        {
            _newsopediaService.DeleteNewsItem(userNewsVm);
            return PartialView("_DeleteAdminItem");
        }

        public IActionResult LogoutPage()
        {
            HttpContext.Session.Remove("UserName");
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
