using EducationApp.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Ropositories.Interfaces
{
    interface IUserRepository
    {
        Task<bool> AddAsync(ApplicationUser user,string password);
        Task<bool> EditAsync(ApplicationUser user);
        Task<bool> RemoveAsync(ApplicationUser user);
        Task<Role> CheckRoleAsync(ApplicationUser user);
        Task<bool> VerifyAsync(ApplicationUser user,string password);
        Task Autharisation(ApplicationUser user);
        Task<ApplicationUser> GetById(long id);
        Task<List<ApplicationUser>> ListAllAsync();
        Task<ApplicationUser> FindNameAsync(string userName);
    }
}
