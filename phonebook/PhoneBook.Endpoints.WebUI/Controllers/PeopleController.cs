using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Domain.Contracts.Peoples;
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
    [Authorize]
    public class PeopleController : Controller
    {
        private readonly IPersonRepository _personRepository;
        private readonly ITagRepository _tagRepository;

        public PeopleController(IPersonRepository personRepository, ITagRepository tagRepository)
        {
            _personRepository = personRepository;
            _tagRepository = tagRepository;
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
                    PersonTags = new List<PersonTag>(Model.SelectedTag.Select(c => new PersonTag
                    {
                        TagId = c
                    }).ToList())
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
                    return RedirectToAction("Index");
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

        public IActionResult Update(int personid)
        {
            var result = _personRepository.Get(personid);
            if (result != null)
            {
                UpdatePersonModelView model = new UpdatePersonModelView
                {
                    id = result.Id,
                    Email = result.Email,
                    Address = result.Address,
                    LastName = result.LastName,
                    FirstName = result.FristName,
                    //Image?!

                };
                return View(model);

            }
            return NotFound();
        }
        [HttpPut]
        public IActionResult Update(UpdatePersonModelView updatePerson)
        {
            if (ModelState.IsValid)
            {
                Person person = new Person
                {
                    FristName = updatePerson.FirstName,
                    LastName = updatePerson.LastName,
                    Address = updatePerson.LastName,
                    Email = updatePerson.Email,
                    Id = updatePerson.id
                };
                if (updatePerson?.Image?.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        updatePerson.Image.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        person.Image = Convert.ToBase64String(fileBytes);

                    }
                }
                //Person result=_personRepository.  where is Update method?!!!!
                //if (result != null)
                //{
                //    return RedirectToAction("Index");
                //}
            }
            return View(updatePerson);
        }
        //public IActionResult Detele(int id)
        //{
        //    var person = _personRepository.Get(id);
        //    if (person!=null)
        //    {
        //        e model=new UpdatePersonModelView
        //        {

        //        }
        //    }
        //    return View();
        //}

    }
}
