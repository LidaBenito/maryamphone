
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Endpoints.WebUI.Models.AAA
{
    public class MyPasswordValidator : PasswordValidator<AppUser>
    {
        private readonly UserDbContext _context;

        public MyPasswordValidator(UserDbContext context)
        {
            _context = context;
        }
        public override Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {
            var parentResult = base.ValidateAsync(manager, user, password).Result;
            List<IdentityError> errors = new List<IdentityError>();
            if (!parentResult.Succeeded)
            {
                errors = parentResult.Errors.ToList();

            }
            if (user.UserName == password || user.UserName.Contains(password))
            {
                errors.Add(new IdentityError
                {
                    Code = "password",
                    Description = "UserName and Password can not be equal"
                });
            }
            if (_context.BadPasswords.Any(c => c.Password == password))
            {
                errors.Add(new IdentityError
                {
                    Code = "password",
                    Description = "Enter Another Password pz"
                });

            }
            return Task.FromResult(errors.Any() ?
               IdentityResult.Failed(errors.ToArray()) :
                IdentityResult.Success
                );
        }

    }



}
