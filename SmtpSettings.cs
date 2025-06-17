using System.Security;

namespace Portfolio
{
    internal class SmtpSettings
    {
        public string? FromEmail { get; internal set; }
        public SecureString? Password { get; internal set; }
        public bool EnableSsl { get; internal set; }
        public int Port { get; internal set; }
        public string Host { get; internal set; }
        public string? FromName { get; internal set; }
    }
}