using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain.Contracts.Peoples;
using PhoneBook.Domain.Core.Peoples;
using PhoneBook.Infarstructure.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBook.Infarstructure.DAL.Persons
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(PhoneBookMaryaContext dbContext) : base(dbContext)
        {
        }

        //public List<Person> GetActivePerson()
        //{
        //    var result = dbContext.People.Where(c => c.Status == true).ToList();
        //    return result;
        //}

        public Person GetPeronWithPhoneNumber(int id)
        {
            var result = dbContext.People.Where(c => c.Id == id).Include(c => c.Phones).FirstOrDefault();
            return result;
        }
       
        public void Update(Person person)
        {
            var result = dbContext.People.Find(person.Id);
            result.Address = person.Address;
            result.Email = person.Email;
            result.FristName = person.FristName;
            result.LastName = person.LastName;
            dbContext.SaveChanges();
        }
    }
}
