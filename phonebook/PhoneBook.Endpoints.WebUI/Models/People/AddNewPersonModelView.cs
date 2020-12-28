using Microsoft.AspNetCore.Http;
using PhoneBook.Domain.Core.Tags;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Endpoints.WebUI.Models
{
    public abstract class AddNewPersonModelView
    {
        [Required]
        [StringLength(50,MinimumLength =2)]
        public string FirstName{ get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName{ get; set; }
        [StringLength(500)]
        public string Address { get; set; }
        [StringLength(150)]
        [EmailAddress]
        public string Email { get; set; }
        public IFormFile Image { get; set; }
    }
    public class AddNewPersonDisplayModelView : AddNewPersonModelView
    {
        public List<Tag> TagForDisplay { get; set; }

    }
    public class AddNewPersonGetModelView : AddNewPersonModelView
    {
        public List<int> SelectedTag { get; set; }
    }
}
