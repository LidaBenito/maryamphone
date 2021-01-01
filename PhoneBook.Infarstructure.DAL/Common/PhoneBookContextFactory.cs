using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Infarstructure.DAL.Common
{
    public class PhoneBookContextFactory : IDesignTimeDbContextFactory<PhoneBookMaryaContext>
    {
        public PhoneBookMaryaContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PhoneBookMaryaContext>();
            builder.UseSqlServer("Server=.;Database=PhoneBookMaryaDb;Integrated Security=True;MultipleActiveResultSets=true");
            return new PhoneBookMaryaContext(builder.Options);
        }
    }
}
