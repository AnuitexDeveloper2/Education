using BookStore.DataAccess.AppContext;
using EducationApp.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using static EducationApp.DataAccessLayer.Entities.Constants.Constants.InitialData;

namespace EducationApp.DataAccessLayer.Initialisation
{
    public class DataBaseInitialisation
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ApplicationContext _applicationContext;

        public DataBaseInitialisation(UserManager<ApplicationUser> userManager, RoleManager<Role> roleManager, ApplicationContext applicationContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _applicationContext = applicationContext;
        }
        public void StartInit()
        {
            InitialisationRole();
            InitializationApplicationUser();
            InitializationPrintingEdition();
            InitializationAuthors();
        }


        private void InitialisationRole()
        {
            List<Role> roles = new List<Role>()
            {
                new Role{Name = Admin},
                new Role{Name = User}
            };

            foreach (var item in roles)
            {
                _roleManager.CreateAsync(item).GetAwaiter().GetResult();
            }
        }

        private void InitializationApplicationUser()
        {
            var user = new ApplicationUser { FirstName = FirstName, LastName = LastName, UserName = Admin, Email = UserEmail, EmailConfirmed = true };
            var createUser = _userManager.CreateAsync(user).GetAwaiter().GetResult();
            if (createUser.Succeeded == true)
            {
                _userManager.AddToRoleAsync(user, Admin).GetAwaiter().GetResult();
                _applicationContext.SaveChanges();
            }
        }

        private void InitializationPrintingEdition()
        {
            int printingEditionCount = _applicationContext.PrintingEditions.Count();
            if (printingEditionCount == 0)
            {
                var printingEdition = new List<PrintingEdition>()
            {
                new PrintingEdition {Title = PrintingEditionName,Date = DateTime.Now,ProductType = Entities.Enums.Enums.TypeProduct.Book },
                new PrintingEdition {Title = PrintingEditionName1, Date = DateTime.Now, ProductType = Entities.Enums.Enums.TypeProduct.Book}
            };
                foreach (var item in printingEdition)
                {
                    _applicationContext.PrintingEditions.Add(item);
                    _applicationContext.SaveChangesAsync().GetAwaiter();
                }
            }
        }

        public void InitializationAuthors()
        {
            var authorcount = _applicationContext.Authors.Count();
            if (authorcount == 0)
            {

                var author = new List<Author>()
            {
               new Author{Name = AuthorName }
            };
                foreach (var item in author)
                {
                    _applicationContext.Authors.Add(item);
                    _applicationContext.SaveChangesAsync().GetAwaiter();
                }
            }
        }

    }
}
