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



        //get
        public ActionResult Schedule()
        {
            string[] Scopes = { CalendarService.Scope.CalendarReadonly };
            string ApplicationName = "EliteK9";


            UserCredential credential;
            string path = Server.MapPath("~/credentials.json");
            using (var stream =
                new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = Server.MapPath("~/token.json"); 
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                //Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Google Calendar API service.
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define parameters of request.
            EventsResource.ListRequest request = service.Events.List("primary");
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            Google.Apis.Calendar.v3.Data.Events events = request.Execute();
            //Console.WriteLine("Upcoming events:");
            //if (events.Items != null && events.Items.Count > 0)
            //{
            //    foreach (var eventItem in events.Items)
            //    {
            //        string when = eventItem.Start.DateTime.ToString();
            //        if (String.IsNullOrEmpty(when))
            //        {
            //            when = eventItem.Start.Date;
            //        }
            //        Console.WriteLine("{0} ({1})", eventItem.Summary, when);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("No upcoming events found.");
            //}
            return View(events);
        }
        //email send
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Schedule(EmailModel e)
        {
            if (ModelState.IsValid)
            {
                await SendGridEmail.SendEmailWithGrid(e);
                ViewBag.sent = "Your email has been sent.";
                 return View();
            }
            
            return View(e);
        }
    }
}