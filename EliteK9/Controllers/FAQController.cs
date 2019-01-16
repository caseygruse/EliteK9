using EliteK9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EliteK9.Controllers
{
    public class FAQController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FAQs
        public ActionResult Index()
        {
            return View(FAQDB.GetAllFAQ(db));
        }
        /// <summary>
        /// creates a FAQ
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FAQ faq)
        {
            if (ModelState.IsValid)
            {
                FAQDB.AddFAQ(db, faq);
                return RedirectToAction("Index");
            }
            return View();
        }

        /// <summary>
        /// delete a FAQ from db
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            FAQ faq = FAQDB.FindFAQ(db, id);
            if(faq != null)
            {
                FAQDB.DeleteFAQ(db, faq);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}