using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static PhoneBook.Endpoints.WebUI.Models.AAA.MyUserNameValidator;

namespace PhoneBook.Endpoints.WebUI.Models.AAA
{
    public class UserDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<BadPassword> BadPasswords { get; set; }
        public UserDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
