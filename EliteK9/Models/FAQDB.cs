using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EliteK9.Models
{
    public static class FAQDB
    {
        /// <summary>
        /// returns a list of FAQs
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<FAQ> GetAllFAQ(ApplicationDbContext db)
        {
            return (from a in db.FAQs select a).ToList();
        }

        public static void AddFAQ(ApplicationDbContext db, FAQ faq)
        {
            db.FAQs.Add(faq);

            db.SaveChanges();
        }

        /// <summary>
        /// deletes a FAQ from db 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="faq"></param>
        public static void DeleteFAQ(ApplicationDbContext db, FAQ faq)
        {
            db.FAQs.Remove(faq);
            db.SaveChanges();
        }

        /// <summary>
        /// finds a FAQ using an ID
        /// </summary>
        /// <param name="db"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static FAQ FindFAQ(ApplicationDbContext db, int id)
        {
            return db.FAQs.Find(id);
        }
    }
}