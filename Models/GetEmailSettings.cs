namespace Portfolio.Models
{
    public class GetEmailSettings
    {
        public string SecretKey { get; set; }= default!;
        public string From { get; set; }= default!;

        public String SmtpServer  { get; set; }= default!;  
        public int Port { get; set; }
        public bool EnableSSl { get; set; }
        public string Form { get; internal set; }
    }
}
