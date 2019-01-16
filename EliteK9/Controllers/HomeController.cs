using EliteK9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EliteK9.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult HomePage()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
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

        public ActionResult Trainers()
        {
            return View();
        }

        public PartialViewResult UserNotifications()
        {
            return PartialView(NotificationDB.GetNotifications(db));
        }

        public ActionResult FAQ()
        {
            return View(FAQDB.GetAllFAQ(db));
        }
    }
}