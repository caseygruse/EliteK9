using EliteK9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Web.Helpers;

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


                MailAddress from = new MailAddress(e.SendersEmail, $"{e.FirstName}, {e.LastName}");
                MailAddress to = new MailAddress("caseygruse.222@gmail.com");
                MailMessage message = new MailMessage(from, to);

                MailAddress bcc = new MailAddress("manager1@contoso.com");
                
                return View();
            }
            return View(e);
        }



    }
}