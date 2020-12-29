using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Domain.Core.Peoples;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Infarstructure.DAL.Persons
{
    internal class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(c => c.FristName).HasMaxLength(50).IsRequired(true);
            builder.Property(c => c.LastName).HasMaxLength(50).IsRequired(true);
            builder.Property(c => c.Address).HasMaxLength(550).IsRequired(true);
            builder.Property(c => c.Email).HasMaxLength(250).IsRequired(true);
            builder.Property(c => c.Image).IsUnicode(false);
        }
    }
}
