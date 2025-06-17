using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Portfolio.Models;
using System.Net;
using System.Net.Mail;

namespace Portfolio.Repostory.Service
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration configuration;

        public EmailSender(IConfiguration Configuration)
        {
            configuration = Configuration;
        }

        public async Task<bool> SendEmailAsync(string email, string subject, string message)
        {
            bool status = false;
            try
            {
                GetEmailSettings settings = new GetEmailSettings()
                {
                    SecretKey = configuration.GetValue<string>("AppSettings:SecretKey"),
                    From = configuration.GetValue<string>("AppSettings:EmailSettings:From"),
                    SmtpServer = configuration.GetValue<string>("AppSettings:EmailSettings:SmtpServer"),
                    Port = configuration.GetValue<int>("AppSettings:EmailSettings:Port"),
                    EnableSSl = configuration.GetValue<bool>("AppSettings:EmailSettings:EnableSSl"),
                };

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(settings.From),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true
                };

                // Send to *yourself* (not to the form submitter)
                mailMessage.To.Add(settings.From);

                SmtpClient smtpClient = new SmtpClient(settings.SmtpServer)
                {
                    Port = settings.Port,
                    Credentials = new NetworkCredential(settings.From, settings.SecretKey),
                    EnableSsl = settings.EnableSSl
                };

                await smtpClient.SendMailAsync(mailMessage);
                status = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Email sending failed: " + ex.Message);
                throw; // Re-throw to surface it during testing
            }

            return status;
        }

        Task IEmailSender.SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return SendEmailAsync(email, subject, htmlMessage);
        }
    }
}
