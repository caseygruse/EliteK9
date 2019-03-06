using EliteK9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net.Http;
using System.Web.Helpers;
using SendGrid;
using SendGrid.Helpers.Mail;
using Google.Apis.Calendar.v3;
using Google.Apis.Auth.OAuth2;
using System.IO;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Services;

namespace EliteK9.Controllers
{
    public class SchedulingController : Controller
    {
        // GET: Scheduling
        public ActionResult Services()
        {           
            return View();
        }

        public PartialViewResult CalendarEvents()
        {
            Google.Apis.Calendar.v3.Data.Events events = Calendar.GetCalendarEvents();
           
            return PartialView(events);
        }

        //get
        public ActionResult Schedule()
        {
           
            return View();
        }
        //email send
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Schedule(EmailModel e)
        {
            if (ModelState.IsValid)
            {
                await SendGridEmail.SendEmailWithGrid(e);
                ViewBag.sent = "Your email has been sent!";
                 return View();
            }
            
            return View(e);
        }
    }
}