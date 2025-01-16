

using System.Net;
using System.Net.Mail;
using System.Text;
using BookHive.Application.Abstracts.Services;
using Microsoft.Extensions.Configuration;

namespace BookHive.Infrastructure.Services.Mail
{
    public class MailService : IMailService
    {
        private readonly IConfiguration configuration;
        public MailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        public async Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true)
        {
            await SendMailAsync(new[] { to }, subject, body, isBodyHtml);
        }

        public async Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
        {
            MailMessage mail = new();
            mail.IsBodyHtml = isBodyHtml;
            foreach (var to in tos)
            {
                mail.To.Add(to);
            }
                
            mail.Subject = subject;
            mail.Body = body;
            mail.From = new(configuration["Mail:Username"], "NG E-Ticaret", System.Text.Encoding.UTF8);

            SmtpClient smtp = new();
            smtp.Credentials = new NetworkCredential(configuration["Mail:Username"], configuration["Mail:Password"]);
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Host = configuration["Mail:Host"];
            await smtp.SendMailAsync(mail);
        }

        public async Task SendPasswordResetMailAsync(string to, Guid userId, string resetToken)
        {
            SmtpClient client = new SmtpClient("smtp.yandex.com", 587);
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("bahruz.a@itbrains.edu.az", "yeymbfptscnarvqt");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailMessage message = new MailMessage("bahruz.a@itbrains.edu.az", to);

            string resetLink = $"https://yourwebsite.com/reset-password?userId={userId}&token={resetToken}";
            message.Subject = "Password Reset";
            message.Body = $"<p>Click the link below to reset your password:</p><a href=\"{resetLink}\">Reset Password</a>";
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;

            await client.SendMailAsync(message);

        }
    }
}
