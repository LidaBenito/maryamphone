using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PhoneBook.Domain.Contracts.Phones;
using PhoneBook.Domain.Core.Phones;
using PhoneBook.Endpoints.WebUI.Models.Phones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Endpoints.WebUI.Controllers
{
    public class PhoneController : Controller
    {
        private readonly IPhoneRepository _phoneRepository;

        public PhoneController(IPhoneRepository phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {

            return View();
        }
        public IActionResult Add([FromRoute] int id)
        {
            AddPhoneViewModel model = new AddPhoneViewModel();
            model.Personid = id;
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(AddPhoneViewModel model)
        {
            if (ModelState.IsValid)
            {
                Phone phone = new Phone
                {
                    PersonId = model.Personid,
                    PhoneNumber = model.Number,
                    PhoneType = model.Type
                };
                _phoneRepository.Add(phone);
                return RedirectToAction("Details", "People", new { id = phone.PersonId });
            }
            else
            {

                return View(model);
            }

        }
        public IActionResult Update()
        {
            return View();
        }

    }

}
