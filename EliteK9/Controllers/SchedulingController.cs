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
        public ActionResult Schedule(EmailModel e)
        {
            if (ModelState.IsValid)
            {

                SendGridMessage msg = new SendGridMessage();

                msg.SetFrom(new EmailAddress($"{e.SendersEmail}", $"{e.FirstName}, {e.LastName}"));

                var recipients = new EmailAddress("caseygruse1@gmail.com", "Casey Gruse");

                msg.AddTo(recipients);

                msg.SetSubject("RSVP");

                msg.AddContent(MimeType.Text, e.Message);

                msg.MailSettings.SandboxMode = new SandboxMode();

                msg.MailSettings.SandboxMode.Enable = true;

                // https://docs.microsoft.com/en-us/azure/sendgrid-dotnet-how-to-send-email#how-to-create-an-email










                //MailMessage msg = new MailMessage();

                //msg.From = new MailAddress($"{e.SendersEmail}", $"{e.FirstName}, {e.LastName}");

                //MailAddress recipient = new MailAddress("caseygruse1@gmail.com");

                //msg.To.Add(recipient);

                //msg.Subject = "RSVP";

                //msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(e.Message));

                //SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(465));

                //System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("apikey", "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");

                //smtpClient.Credentials = credentials;

                //smtpClient.Send(msg);


                return View();
            }
            return View(e);
        }



    }
}