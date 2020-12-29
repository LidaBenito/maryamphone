
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Endpoints.WebUI.Models.AAA
{
    public partial class MyUserNameValidator : UserValidator<AppUser>

    {
        private readonly UserDbContext _dbContext;

        public MyUserNameValidator(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public override Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {
            var parentResult = base.ValidateAsync(manager, user).Result;
            List<IdentityError> errors = new List<IdentityError>();
            if (!parentResult.Succeeded)
            {
                errors = parentResult.Errors.ToList();
            }
            ///?????????????????????????????????????????????????????
            ///
            if (!user.Email.EndsWith(".com") || !user.Email.EndsWith(".ir"))
            {
                errors.Add(new IdentityError
                {
                    Code = "Username",
                    Description = "Enter a correct Email address plz"

                });

            }
            return Task.FromResult(errors.Any() ?
                IdentityResult.Failed(errors.ToArray()):
                IdentityResult.Success
                );
         }
    }



}
