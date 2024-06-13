using BackEnd.Entity;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;

namespace BackEnd.DAL
{
 

    public class DALEmail
    {
        public void SendEmail(EmailDto request)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Your Name", request.From));
            message.To.Add(new MailboxAddress("Recipient", request.To));
            message.Subject = request.Subject;
            message.Body = new TextPart("plain")
            {
                Text = request.Body
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.your-email-provider.com", 587, false);
                client.Authenticate("your-email@example.com", "your-email-password");
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }

}
