using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class ContactFormModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Message must be between 10 and 1000 characters.")]

        public string Message { get; set; }
    }
}
