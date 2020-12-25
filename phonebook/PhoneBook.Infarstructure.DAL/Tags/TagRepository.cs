using PhoneBook.Domain.Contracts.Tags;
using PhoneBook.Domain.Core.Tags;
using PhoneBook.Infarstructure.DAL.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Infarstructure.DAL.Tags
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(PhoneBookMaryaContext dbContext) : base(dbContext)
        {
        }
    }
}
