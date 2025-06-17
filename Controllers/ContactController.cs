using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.UI.Services;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class ContactController : Controller
    {
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _configuration;

        public ContactController(IEmailSender emailSender, IConfiguration configuration)
        {
            _emailSender = emailSender;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [Route("Contact/SendJson")]
        public async Task<IActionResult> SendJson([FromBody] ContactFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Invalid input." });
            }

            var subject = "New Contact Form Message";
            var body = $@"
                <strong>Name:</strong> {model.FirstName} {model.LastName}<br />
                <strong>Email:</strong> {model.Email}<br />
                <strong>Phone:</strong> {model.Phone}<br /><br />
                <strong>Message:</strong><br />{model.Message}
            ";

            try
            {
                // Send to your own email
                var toEmail = _configuration.GetValue<string>("AppSettings:EmailSettings:From");

                await _emailSender.SendEmailAsync(toEmail, subject, body);
                return Ok(new { message = "Message sent successfully!" });
            }
            catch (Exception ex)
            {
                Console.WriteLine("SendJson error: " + ex.Message);
                return StatusCode(500, new { message = "Failed to send message." });
            }
        }
    }
}
