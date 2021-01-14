using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Endpoints.WebUI.Models.AAA
{
    public class RoleViewModel
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
    }
}
