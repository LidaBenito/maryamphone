using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Domain.Contracts.Peoples;
using PhoneBook.Domain.Contracts.Phones;
using PhoneBook.Domain.Contracts.Tags;
using PhoneBook.Endpoints.WebUI.Models.AAA;
using PhoneBook.Infarstructure.DAL.Common;
using PhoneBook.Infarstructure.DAL.Persons;
using PhoneBook.Infarstructure.DAL.phones;
using PhoneBook.Infarstructure.DAL.Tags;

namespace PhoneBook.Endpoints.WebUI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            int Minpassword = int.Parse(Configuration["MinPasswordChar"]);
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IPhoneRepository, PhoneTagRepository>();
            services.AddDbContext<PhoneBookContext>(c => c.UseSqlServer(Configuration.GetConnectionString("phoneBook")));
            services.AddDbContext<UserDbContext>(c => c.UseSqlServer(Configuration.GetConnectionString("aaa")));
            services.AddScoped<IPasswordValidator<AppUser>, MyPasswordValidator>();
            services.AddScoped<IUserValidator<AppUser>, MyUserNameValidator>();
            services.AddIdentity<AppUser, MyIdentityRole>(c=>
            {
                c.User.RequireUniqueEmail = true;
                c.Password.RequireDigit = false;
                c.Password.RequiredLength = Minpassword;
                c.Password.RequireNonAlphanumeric = false;
                c.Password.RequireUppercase = false;
                c.Password.RequiredUniqueChars = 1;
            }).AddEntityFrameworkStores<UserDbContext>() ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseIdentity();
            app.UseMvc(route=>
            {
                route.MapRoute(
                    name:"Default",
                    template:"{Controller=Home}/{Action=Index}/{Id?}"
                    
                    );
            });
          
        }
    }
}
