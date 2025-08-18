using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace testdemo.Models
{
    public class clsEmailacaonfirm : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {   

            var fMail = "heyeelali33@gmail.com";
            var fPassword = "heyeelali442006.";


            var theMsg = new MailMessage();
            theMsg.From = new MailAddress(fMail);
            theMsg.Subject = subject;
            theMsg.To.Add(email);
            theMsg.Body = $"<html><body>{htmlMessage}</body></html>";
            theMsg.IsBodyHtml = false;


            var smtpClint = new SmtpClient("smtp-mail.outlook.com")
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(fMail, fPassword),
                Port = 587
            };
            smtpClint.Send(theMsg);
            return Task.CompletedTask;

        }
    }
}
