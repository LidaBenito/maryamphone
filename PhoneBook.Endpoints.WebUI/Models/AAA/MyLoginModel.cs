using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Endpoints.WebUI.Models.AAA
{
    public class MyLoginModel
    {
        [Required]
        [Display(Name ="Username or Email")]
        public string Name{ get; set; }
        [Required]
        [UIHint("password")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; } = "/";
    }
}
