using PhoneBook.Domain.Core.Phones;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Domain.Core.Peoples
{
    public class Person : BaseEntity
    {
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public List<Phone> Phones { get; set; }
        public List<PersonTag> PersonTags { get; set; }
    }
}
