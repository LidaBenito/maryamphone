using Microsoft.AspNetCore.Mvc.Rendering;
using PhoneBook.Domain.Core.Phones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Endpoints.WebUI.Models.Phones
{
    public  class AddPhoneViewModel
    {
        public int PersonId{ get; set; }
        [Required]
        [StringLength(15,MinimumLength =8)]
        public string Number{ get; set; }
        public PhoneType Type { get; set; }

        public List<SelectListItem> PhoneTypes { get; set; }
        public AddPhoneViewModel()
        {
            PhoneTypes = new List<SelectListItem>();
            PhoneTypes.Add(new SelectListItem
            {

                Value = ((int)PhoneType.Family).ToString(),
                Text = PhoneType.Family.ToString()
            });
            PhoneTypes.Add(new SelectListItem
            {
                Value = ((int)PhoneType.Home).ToString(),
                Text = PhoneType.Home.ToString()
            });
            PhoneTypes.Add(new SelectListItem
            {
                Value = ((int)PhoneType.Work).ToString(),
                Text = PhoneType.Work.ToString()
            });
            PhoneTypes.Add(new SelectListItem
            {
                Value = ((int)PhoneType.Friend).ToString(),
                Text = PhoneType.Friend.ToString()
            });
        
        }
    }
}
