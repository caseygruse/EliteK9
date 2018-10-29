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

        //get
        public ActionResult Schedule()
        {
            return View();
        }
        //email send
        [HttpPost]
        public ActionResult Schedule(EmailModel e)
        {
            if (ModelState.IsValid)
            {


                //MailAddress from = new MailAddress(email.Email);

                return View();
            }
            return View(e);
        }



    }
}