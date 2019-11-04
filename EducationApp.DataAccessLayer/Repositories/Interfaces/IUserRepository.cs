using EducationApp.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Ropositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> AddAsync(ApplicationUser user, string password);
        Task<bool> EditAsync(ApplicationUser user);
        Task<bool> RemoveAsync(ApplicationUser user);
        Task<Role> CheckRoleAsync(string email);
        Task<bool> VerifyAsync(ApplicationUser user, string password);
        Task<ApplicationUser> GetByIdAsync(long id);
        Task<ApplicationUser> GetByNameAsync(string userName);
        Task<bool> ChangePassword(ApplicationUser user, string oldPasswor, string newPassword);
        Task<bool> ChangeEmailAsync(ApplicationUser user, string newEmail, string token);
        Task<ApplicationUser> GetByEmailAsync(string email);
        Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user);
        Task SignInAsync(ApplicationUser user, bool isPersistent);
        Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user);
    }
}
