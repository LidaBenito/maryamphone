using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Endpoints.WebUI.Models.People
{
    public class UpdatePersonModelView:NewPersonModelView
    {
        public int id{ get; set; }
       
        public string Name{ get; set; }
        public IFormFile UpdateImage{ get; set; }
    }
}
