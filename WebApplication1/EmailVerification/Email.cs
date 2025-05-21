using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace WebApplication1.EmailVerification
{
    public class Email : IEmailSender
    {
        async Task IEmailSender.SendEmailAsync(string email, string subject, string htmlMessage)
        {
            string mail = "nizamabdulbari13@gmail.com";
            string password = "xkemgzazxzbfizfq";
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(email);
            msg.To.Add(email);
            msg.Subject = subject;
            msg.Body = "<html><body><h5>" + htmlMessage + "</h5></body></html>";
            msg.IsBodyHtml = true;

            var smtp = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(mail, password),
                EnableSsl = true,
            };

            smtp.Send(msg);


        }
    }
}
