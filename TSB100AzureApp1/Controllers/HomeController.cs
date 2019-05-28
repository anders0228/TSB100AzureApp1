using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSB100AzureApp1.Models;

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

            }
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}