using PhoneBook.Domain.Core.Peoples;
using PhoneBook.Domain.Core.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Endpoints.WebUI.Models.Tags
{
    public class UpdatePersonTagViewModel
    {
        public int PersonId { get; set; }
        public int TagId { get; set; }
        public Tag Tags { get; set; }
       public Person  Person { get; set; } 
        public List<Tag> TagsForDisplay { get; set; }


    }
}
