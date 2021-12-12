using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CinemaProject.Services
{
    public class SendEmailService
    {
        public void SendEmailTicket(string userEmail, string movieName)
        {
            MailMessage mailMessage = new MailMessage("yourfavouritecinema@gmail.com", userEmail);
            mailMessage.Subject = "Ticket";
            mailMessage.Body = "Thank you for buying ticket for <b>" + movieName + "</b>. See your account to look at all your tickets.";
            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "yourfavouritecinema@gmail.com",
                Password = "Niepodamhasla77"
            };
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
        }
    }
}
