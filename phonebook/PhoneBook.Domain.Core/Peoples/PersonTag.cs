using PhoneBook.Domain.Core.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Domain.Core.Peoples
{
    public class PersonTag:BaseEntity
    {
        public int TagId { get; set; }
        public Tag Tag{ get; set; }
        public int PersonId{ get; set; }
        public Person  Person{ get; set; }
    }
}
