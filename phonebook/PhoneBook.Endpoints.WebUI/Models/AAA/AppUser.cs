using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Endpoints.WebUI.Models.AAA
{
    public class AppUser:IdentityUser
    {
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public DateTime? Birthdate{ get; set; }
    }
    public class MyIdentityRole : IdentityRole<int>
    {
        
    }
}
