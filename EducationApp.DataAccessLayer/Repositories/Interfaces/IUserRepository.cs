using EducationApp.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Ropositories.Interfaces
{
    interface IUserRepository
    {
        Task<Role> CheckRole(ApplicationUser user,string password);
        Task<string> ChangeRole(Role role);
        Task<bool> AuthenticationAsync(string password);
        Task Autharisation(ApplicationUser user);
        Task<ApplicationUser> GetById(long id);
        Task<List<ApplicationUser>> ListAll();
        Task<bool> Add(ApplicationUser user);
        Task<bool> EditAsync(ApplicationUser user);
        Task<bool> RemoveAsync(ApplicationUser user);
        Task<ApplicationUser> FindNameAsync(string userName);
    }
}
