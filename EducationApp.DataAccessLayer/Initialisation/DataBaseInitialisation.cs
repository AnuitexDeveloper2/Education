using BookStore.DataAccess.AppContext;
using EducationApp.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EducationApp.DataAccessLayer.Initialisation
{
    public class DataBaseInitialisation
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly ApplicationContext applicationContext;
        public DataBaseInitialisation(UserManager<ApplicationUser> userManager, RoleManager<Role> roleManager, ApplicationContext applicationContext)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.applicationContext = applicationContext;
        }
        public void StartInit()
        {
            //InitializationApplicationUser();
            InitializationAuthors();
            //InitializationPrintingEdition();
        }

        public void InitializationAuthors()
        {
            long amountAuthors = applicationContext.Authors.Count();
            if (amountAuthors == 0)
            {
                var author = new Author
                {
                    Name = "Terry Pratchett"
                };
                applicationContext.Authors.Add(author);
                applicationContext.SaveChanges();
            }
        }

        //    //public void InitializationApplicationUser()
        //    //{
        //    //    var role = new Role();
        //    //    role.Name = "Admin";
        //    //    roleManager.CreateAsync(role).GetAwaiter().GetResult();

        //    //    var role1 = new Role();
        //    //    role1.Name = "User";
        //    //    roleManager.CreateAsync(role1).GetAwaiter().GetResult();

        //    //    List<ApplicationUser> users = new List<ApplicationUser>()
        //    //        {
        //    //            new ApplicationUser { Email = "model.Email4", UserName = "model.Email2"},
        //    //            new ApplicationUser { Email = "model.Email7", UserName = "model.Email3" },
        //    //        };

        //    //    foreach (ApplicationUser item in users)
        //    //    {
        //    //        var result = userManager.CreateAsync(item).GetAwaiter().GetResult();
        //    //        if (result.Succeeded)
        //    //        {
        //    //            userManager.AddToRoleAsync(item, role.Name).GetAwaiter();
        //    //        }
        //    //    }
        //    //}
        //    public void InitializationRoles()
        //    {
        //        var role = new Role();
        //        role.Name = "Admin";
        //        roleManager.CreateAsync(role).GetAwaiter().GetResult();
        //        List<Role> roles = new List<Role>()
        //        {
        //            new Role{Name = "Admin"},
        //            new Role{Name = "User"}
        //        };

        //        var role1 = new Role();
        //        role1.Name = "User";
        //        roleManager.CreateAsync(role1).GetAwaiter().GetResult();
        //        foreach (Role item in roles)
        //        {
        //            roleManager.CreateAsync(item).GetAwaiter().GetResult();
        //        }
        //    }

        //    List<ApplicationUser> users = new List<ApplicationUser>()
        //            {
        //                new ApplicationUser { Email = "model.Email1", UserName = "Name1"},
        //                new ApplicationUser { Email = "model.Email2", UserName = "Name2" },
        //            };
        //    public void InitializationAdmin()
        //    {
        //        ApplicationUser admin = new ApplicationUser { Email = "morgenshtern1988@gmail.com", UserName = "Vladimir Goncharuk"};

        //        foreach (ApplicationUser item in users)
        //        {
        //            var  = userManager.CreateAsync(admin).GetAwaiter().GetResult();
        //            if (result.Succeeded)
        //            {
        //                var result = _userManager.CreateAsync(user).GetAwaiter().GetResult();
        //                if (result.Succeeded)
        //                {
        //                    _userManager.AddToRoleAsync(user, role.Name).GetAwaiter();
        //                }
        //            }
        //            _userManager.AddToRoleAsync(admin, "Admin").GetAwaiter().GetResult();
        //        }
        //    }
        //}

        //public void InitializationAuthors()
        //    {

        //        List<Author> authors = new List<Author>()
        //            {
        //                new Author { Id = 1, Name = "Terry Pratchett" },
        //                new Author { Id = 2, Name = "Jeffrey Richter" }
        //            };

        //        foreach (Author item in authors)
        //            applicationContext.Authors.Add(item);
        //        applicationContext.SaveChanges();

        //    }

        //    public void InitializationPrintingEdition()
        //    {

        //        List<PrintingEdition> printingEditions = new List<PrintingEdition>()
        //            {
        //                new PrintingEdition { Id = 1, Title = "Discword" },
        //                new PrintingEdition{ Id = 2, Title ="CLR via C#" }
        //            };

        //        foreach (PrintingEdition printingEdition in printingEditions)
        //            applicationContext.PrintingEditions.Add(printingEdition);
        //        applicationContext.SaveChanges();
        //    }
    }
}