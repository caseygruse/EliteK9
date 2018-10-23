using EliteK9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;

namespace EliteK9.Controllers
{
    public class SchedulingController : Controller
    {
        // GET: Scheduling
        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Schedule()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Schedule(EmailModel email)
        {
            if (ModelState.IsValid)
            {


                //MailAddress from = new MailAddress(email.Email);

                return View(email);
            }
            return View(email);
        }



    }
}