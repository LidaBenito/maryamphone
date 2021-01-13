using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Domain.Contracts.Peoples;
using PhoneBook.Domain.Contracts.Phones;
using PhoneBook.Domain.Contracts.Tags;
using PhoneBook.Domain.Core.Peoples;
using PhoneBook.Endpoints.WebUI.Models;
using PhoneBook.Endpoints.WebUI.Models.People;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Endpoints.WebUI.Controllers
{
    //[Authorize]
    public class PeopleController : Controller
    {
        private readonly IPersonRepository _personRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IPhoneRepository _phoneRepository;

        public PeopleController(IPersonRepository personRepository, ITagRepository tagRepository, IPhoneRepository phoneRepository)
        {
            _personRepository = personRepository;
            _tagRepository = tagRepository;
            _phoneRepository = phoneRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            var model = _personRepository.GetAll().ToList();
            return View(model);
        }
        public IActionResult Add()
        {
            AddNewPersonDisplayModelView model = new AddNewPersonDisplayModelView();
            model.TagForDisplay = _tagRepository.GetAll().ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(AddNewPersonGetModelView Model)
        {
            if (ModelState.IsValid)
            {
                Person person = new Person
                {
                    Address = Model.Address,
                    FristName = Model.FirstName,
                    LastName = Model.LastName,
                    Email = Model.Email,
                    //PersonTags = new List<PersonTag>(Model.SelectedTag.Select(c => new PersonTag
                    //{
                    //    TagId = c
                    //}).ToList())
                };
                if (Model?.Image?.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        Model.Image.CopyTo(ms);
                        var filebyte = ms.ToArray();
                        person.Image = Convert.ToBase64String(filebyte);
                    }

                }
                Person result = _personRepository.Add(person);
                if (result != null)
                {
                    return RedirectToAction("List");
                }
            }
            ViewBag.SelectedItem = Model.SelectedTag;
            AddNewPersonDisplayModelView modelforDisplay = new AddNewPersonDisplayModelView
            {
                Address = Model.Address,
                Email = Model.Email,
                LastName = Model.LastName,
                FirstName = Model.FirstName
            };
            modelforDisplay.TagForDisplay = _tagRepository.GetAll().ToList();
            return View(modelforDisplay);
        }

        public IActionResult Update([FromRoute] int id)
        {
            var result = _personRepository.Get(id);
            if (result != null)
            {
                UpdatePersonModelView model = new UpdatePersonModelView
                {
                    id = result.Id,
                    Email = result.Email,
                    Address = result.Address,
                    LastName = result.LastName,
                    FirstName = result.FristName,


                };
                return View(model);

            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Update(UpdatePersonModelView updatePerson)
        {
            if (ModelState.IsValid)
            {
                Person person = new Person
                {
                    FristName = updatePerson.FirstName,
                    LastName = updatePerson.LastName,
                    Address = updatePerson.Address,
                    Email = updatePerson.Email,
                    Id = updatePerson.id
                };
                _personRepository.Update(person);
                return RedirectToAction("List");
            }
            return View(updatePerson);
        }
        public IActionResult Delete(int id)
        {
            var person = _personRepository.Get(id);
            if (person != null)
            {
                DetailsPersonViewModel model = new DetailsPersonViewModel()
                {
                    personId = person.Id,
                    FirstName = person.FristName,
                    LastName = person.LastName,
                    Email = person.Email,
                    Address = person.Address,

                };
                return View(model);

            }

            return NotFound();
        }
        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            if (ModelState.IsValid)
            {
                _personRepository.Delete(id);
                return RedirectToAction("List");

            }

            return RedirectToAction("Details", new { id = id });

        }
        public IActionResult Details(int id)
        {
            var result = _personRepository.GetPeronWithPhoneNumber(id);
            if (result != null)
            {
                DetailsPersonViewModel model = new DetailsPersonViewModel()
                {
                    personId = result.Id,
                    Address = result.Address,
                    FirstName = result.FristName,
                    LastName = result.LastName,
                    phone = result.Phones,
                    Email = result.Email

                };
                return View(model);
            }
            return NotFound();
        }
        public IActionResult DeleteNumber(int id)
        {
            var result = _phoneRepository.Get(id);
            _phoneRepository.Delete(id);
            return RedirectToAction("Details",new {id=result.Id });
        }
    }
}


