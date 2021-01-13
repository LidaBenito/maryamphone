using PhoneBook.Domain.Core.Phones;
using PhoneBook.Domain.Core.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Endpoints.WebUI.Models.People
{
    public class DetailsPersonViewModel : NewPersonModelView
    {
        //public int PhoneId { get; set; }
        public int personId { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public List<Phone> phone { get; set; }

    }
}
