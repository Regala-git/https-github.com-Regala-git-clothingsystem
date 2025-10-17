using System;
using System.Net;
using System.Net.Mail;

namespace ClothingSystem.Common
{
    public class EmailService
    {
        private readonly SmtpClient client;

        public EmailService()
        {
            client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("fefc55dcaa50b1", "f6e04a0b73e682"),
                EnableSsl = true
            };
        }

        public bool SendNotification(string toEmail, string subject, string message)
        {
            try
            {
                var from = "store@clothingapp.com"; 
                var mailMessage = new MailMessage(from, toEmail, subject, message);
                client.Send(mailMessage);
                return true; 
            }
            catch (Exception)
            {
                return false; 
            }
        }
    }
}
