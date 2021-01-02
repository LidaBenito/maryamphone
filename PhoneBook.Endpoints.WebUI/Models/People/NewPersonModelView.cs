using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Endpoints.WebUI.Models
{
    public abstract class NewPersonModelView
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
        [StringLength(500)]
        public string Address { get; set; }
        [StringLength(150)]
        [EmailAddress]
        public string Email { get; set; }
        public IFormFile Image { get; set; }
    }
}
