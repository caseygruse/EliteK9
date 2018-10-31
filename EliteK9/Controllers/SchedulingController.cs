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
        public async System.Threading.Tasks.Task<ActionResult> Schedule(EmailModel e)
        {
            if (ModelState.IsValid)
            {

                
  /*  needs Key
                SendGridMessage msg = new SendGridMessage();

                msg.SetFrom(new EmailAddress($"{e.SendersEmail}", $"{e.FirstName}, {e.LastName}"));

                var recipients = new EmailAddress("caseygruse1@gmail.com", "Casey Gruse");

                msg.AddTo(recipients);

                msg.SetSubject("RSVP");

                msg.PlainTextContent = e.Message;

                //var transportWeb = new SendGrid.Web("SENDGRID_APIKEY");

                var apiKey = System.Configuration.ConfigurationManager.AppSettings.Get("sendGridKey");
                var client = new SendGridClient(apiKey);
                Console.WriteLine(apiKey);

                await client.SendEmailAsync(msg);

                // https://docs.microsoft.com/en-us/azure/sendgrid-dotnet-how-to-send-email#how-to-create-an-email
        */
                return View();
            }
            return View(e);
        }



    }
}