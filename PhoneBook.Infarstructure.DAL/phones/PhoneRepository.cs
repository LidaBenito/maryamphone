using PhoneBook.Domain.Contracts.Phones;
using PhoneBook.Domain.Core.Phones;
using PhoneBook.Infarstructure.DAL.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Infarstructure.DAL.phones
{
    public class PhoneTagRepository : BaseRepository<Phone>, IPhoneRepository
    {
        public PhoneTagRepository(PhoneBookContext dbContext) : base(dbContext)
        {
        }
    }
}
