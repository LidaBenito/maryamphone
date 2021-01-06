using Microsoft.AspNetCore.Mvc;
using PhoneBook.Domain.Contracts.Tags;
using PhoneBook.Domain.Core.Tags;
using PhoneBook.Infarstructure.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Endpoints.WebUI.Controllers
    // 02122676162 shariati balatara az pole sadr k semiari kenare darookhane
{
    public class TagController : Controller
    {
        private readonly ITagRepository _tagRepository;

        public TagController(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public IActionResult List()
        {
            var result = _tagRepository.GetAll().ToList();
            return View(result);
        }
        public IActionResult Add()
        {
            Tag model = new Tag();
            return View(model);


        }
        [HttpPost]
        public IActionResult Add(Tag tagViewModel)
        {
            if (ModelState != null)
            {
                Tag tag = new Tag()
                {
                    Title = tagViewModel.Title

                };
                _tagRepository.Add(tag);
                return RedirectToAction("List");
            }
            Tag addNewTagView = new Tag()
            {
                Title = tagViewModel.Title
            };
            return View(addNewTagView);

        }
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                _tagRepository.Delete(id);

            }

            return RedirectToAction("List");

        }

    }
}
