using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EliteK9.Models
{
    public static class NotificationDB
    {
        /// <summary>
        /// gets all notifications from DB 
        /// </summary>
        /// <param name="db"></param>
        /// <returns>all notifications in a list</returns>
        public static List<Notifications> GetNotifications(ApplicationDbContext db)
        {
            return (from a in db.Notifications select a).ToList();
        }
        /// <summary>
        /// Adds a notification to the db.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="notifications"></param>
        public static void AddNotification(ApplicationDbContext db, Notifications notifications)
        {
            db.Notifications.Add(notifications);
            db.SaveChanges();
        }
    }
}