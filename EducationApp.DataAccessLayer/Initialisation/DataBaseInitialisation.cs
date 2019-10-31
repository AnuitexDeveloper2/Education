using BookStore.DataAccess.AppContext;
using EducationApp.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using static EducationApp.DataAccessLayer.Entities.Constants.Constants;

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
            InitializationAuthors();
            InitializationApplicationUser();
            InitializationPrintingEdition();
            InitialisationAuthorInPrintingEdition();
        }

        private void InitialisationAuthorInPrintingEdition()
        {
            var authoirIn = new AuthorInPrintingEdition()
            {
                AuthorId = 1,
                PrintingEditionId = 1
            };
            _applicationContext.AuthorInPrintingEditions.Add(authoirIn);
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
            List<ApplicationUser> users = new List<ApplicationUser>()
            {
                new ApplicationUser{ FirstName = "I" ,LastName = "am",UserName = Admin},
                new ApplicationUser{ FirstName = "He",LastName = "is",UserName = User}
            };
            foreach (var item in users)
            {
                _userManager.CreateAsync(item).GetAwaiter().GetResult();
                if (item.UserName == Admin)
                {
                    _userManager.AddToRoleAsync(item, Admin).GetAwaiter();
                    continue;
                }
                if (item.UserName == User)
                {
                    _userManager.AddToRoleAsync(item, User).GetAwaiter();
                }
            }
        }

        private void InitializationPrintingEdition()
        {
            int printingEditionCount = _applicationContext.PrintingEditions.Count();
            if (printingEditionCount == 0)
            {

                var printingEdition = new List<PrintingEdition>()
            {
                new PrintingEdition {Title = "Discword"},
                new PrintingEdition {Title = "CLR via C#"}
            };
                foreach (var item in printingEdition)
                {
                    _applicationContext.PrintingEditions.Add(item);
                    _applicationContext.SaveChanges();
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
               new Author{Name = "Terry Pratchett" }
            };
                foreach (var item in author)
                {
                    _applicationContext.Authors.Add(item);
                    _applicationContext.SaveChanges();
                }
            }

        }
    }
}
