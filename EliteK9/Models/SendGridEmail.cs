using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using SendGrid.Helpers.Mail;
using SendGrid;

namespace EliteK9.Models
{
    public static class SendGridEmail
    {
        /// <summary>
        /// creates a and sends a email based on the model passed.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static async Task SendEmailWithGrid(EmailModel e)
        {
            SendGridMessage msg = new SendGridMessage();

            msg.SetFrom(new EmailAddress($"{e.SendersEmail}", $"{e.FirstName}, {e.LastName}"));

            var recipients = new EmailAddress("caseygruse1@gmail.com", "Hanna Myers");
            //hannamyers @hotmail.com

            msg.AddTo(recipients);

            msg.SetSubject("RSVP");

            msg.PlainTextContent = e.Message;

            var apiKey = System.Configuration.ConfigurationManager.AppSettings.Get("sendGridKey");
            var client = new SendGridClient(apiKey);
            Console.WriteLine(apiKey);

            await client.SendEmailAsync(msg);
        }

    }
}