namespace Portfolio.Repostory.Interface
{
    public interface IEmailSender
    {
        Task <bool> SendEmailAsync(string subject, string message);
    }
}
