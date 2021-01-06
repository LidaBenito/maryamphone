using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain.Core.Peoples;
using PhoneBook.Domain.Core.Phones;
using PhoneBook.Domain.Core.Tags;
using PhoneBook.Infarstructure.DAL.Persons;
using PhoneBook.Infarstructure.DAL.phones;
using PhoneBook.Infarstructure.DAL.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Infarstructure.DAL.Common
{
    public class PhoneBookContext : DbContext
    {
        public DbSet<Tag>  Tags{ get; set; }
        public DbSet<Phone> Phones{ get; set; }
        public DbSet<Person> People{ get; set; }
        public DbSet<PersonTag> PersonTags { get; set; }

        public PhoneBookContext(DbContextOptions<PhoneBookContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfig());
            modelBuilder.ApplyConfiguration(new PhoneConfigr());
            modelBuilder.ApplyConfiguration(new PersonTagConfig());
            modelBuilder.ApplyConfiguration(new TagConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
