using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;

public class EmailService
{
    private readonly EmailSettings _emailSettings;

    public EmailService(IOptions<EmailSettings> emailSettings) => _emailSettings = emailSettings.Value;

    public async Task SendEmailAsync(string subject, string message)
    {
        using (var client = new SmtpClient(_emailSettings.MailServer, _emailSettings.MailPort))
        {
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(
                _emailSettings.SenderEmail,
                _emailSettings.Password);

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_emailSettings.SenderEmail, _emailSettings.SenderName),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };

            mailMessage.To.Add(_emailSettings.ReceiverEmail);

            await client.SendMailAsync(mailMessage);
        }
    }
}

public class EmailSettings
{
    public string MailServer { get; set; }
    public int MailPort { get; set; }
    public string SenderName { get; set; }
    public string SenderEmail { get; set; }
    public string Password { get; set; }
    public string ReceiverEmail { get; set; }
}