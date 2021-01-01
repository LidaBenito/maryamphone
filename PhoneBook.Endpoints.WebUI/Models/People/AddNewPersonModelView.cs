using PhoneBook.Domain.Core.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Endpoints.WebUI.Models
{
    public class AddNewPersonDisplayModelView : NewPersonModelView
    {
        public List<Tag> TagForDisplay { get; set; }

    }
    public class AddNewPersonGetModelView : NewPersonModelView
    {
        public List<int> SelectedTag { get; set; }
    }
}
