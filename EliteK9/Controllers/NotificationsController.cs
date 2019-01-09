using EliteK9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EliteK9.Controllers
{
    public class NotificationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        /// <summary>
        /// lists all notifications with buttons to create and delete
        /// </summary>
        /// <returns></returns>
        public ActionResult Notifications()
        {
            return View(NotificationDB.GetNotifications(db));
        }

        /// <summary>
        /// creates a notification
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Notifications notifications)
        {
            if (ModelState.IsValid)
            {
                NotificationDB.AddNotification(db, notifications);
                return RedirectToAction("Notifications");
            }
            return View(notifications);   
        }
        /// <summary>
        /// Deletes the selected Notification from the notifications page
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Notifications Notification = NotificationDB.FindNotification(db, id);

            if (Notification != null)
            {
                NotificationDB.DeleteNotification(db, Notification);
                return RedirectToAction("Notifications");
            }
            return View();
        }
    }
}