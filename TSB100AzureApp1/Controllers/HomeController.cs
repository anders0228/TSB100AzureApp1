using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSB100AzureApp1.Logic;
using TSB100AzureApp1.Models;
using TSB100AzureApp1.UserProfileServiceReference;

namespace TSB100AzureApp1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = new StatsPageViewModel();

            using (var client = new UserProfileServiceReference.UserProfileServiceClient())
            {

                if (client.IsAlive())
                {
                    viewModel.ServiceOnline = "service online";
                }
                else
                {
                    viewModel.ServiceOnline = "service offline";
                }
                //var viewModel = new StatsPageViewModel()
                //{
                //    ServiceOnline = client.IsAlive() ? "service online" : "service offline";
                //}

                var users = client.GetAllUsers();
                var stats = new UserStatistics();
                viewModel.UserCityStats = stats.GetUserCityStats(users);

            }
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }



    }
}