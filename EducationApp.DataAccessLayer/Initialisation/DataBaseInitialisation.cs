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
            InitializationApplicationUser();
            InitializationAuthors();
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
            _applicationContext.SaveChanges();
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
                if (item.UserName.Equals(Admin))
                {
                    _userManager.AddToRoleAsync(item, Admin).GetAwaiter();
                    continue;
                }
                _userManager.AddToRoleAsync(item, User).GetAwaiter();
            }
        }

        private void InitializationPrintingEdition()
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

        public void InitializationAuthors()
        {

            var author = new Author
            {
                Id = 1,
                Name = "Terry Pratchett"
            };
            _applicationContext.Authors.Add(author);
            _applicationContext.SaveChanges();

        }
    }
}
