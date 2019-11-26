using BookStore.DataAccess.AppContext;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Helpers;
using EducationApp.DataAccessLayer.Models;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using static EducationApp.DataAccessLayer.Entities.Constants.Constants.Roles;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.DataAccessLayer.Ropositories.EFRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationContext _applicationContext;

        public UserRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationContext applicationContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _applicationContext = applicationContext;
        }
        public async Task<bool> CreateUserAsync(ApplicationUser user, string password)
        {
            var excistUser = await _userManager.FindByEmailAsync(user.Email);
            if (excistUser != null)
            {
                return false;
            }
            user.UserName = user.FirstName /*+ user.LastName*/;
            var createUser = await _userManager.CreateAsync(user, password);
            if (!createUser.Succeeded)
            {
                return false;
            }
            var result = await _userManager.AddToRoleAsync(user, User);
            return result.Succeeded;
        }
        public async Task<bool> EditAsync(ApplicationUser user)
        {
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> RemoveAsync(ApplicationUser user)
        {
            user.IsRemoved = true;
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }
        public async Task<string> CheckRoleAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return null;
            }
            var userRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            return userRole;
        }


        public async Task<ApplicationUser> GetByIdAsync(long id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            return user;
        }

        public async Task<ApplicationUser> GetByNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return user;
        }

        public async Task<bool> ChangePasswordAsync(ApplicationUser user, string oldPassword, string newPassword)
        {
            var changePasswordResult = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            return changePasswordResult.Succeeded;
        }

        public async Task<ApplicationUser> GetByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user)
        {
            var result = await _userManager.GeneratePasswordResetTokenAsync(user);
            return result;
        }


        public async Task<bool> ChangeEmailAsync(ApplicationUser user, string newEmail)
        {
            var token = await _userManager.GenerateChangeEmailTokenAsync(user, newEmail);
            var changeEmailResult = await _userManager.ChangeEmailAsync(user, newEmail, token);
            return changeEmailResult.Succeeded;
        }

        public async Task<bool> ConfirmEmailAsync(ApplicationUser user, string token)
        {
            var result = await _userManager.ConfirmEmailAsync(user, token);
            return result.Succeeded;
        }

        public async Task<ApplicationUser> FindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<bool> ConfirmPasswordAsync(ApplicationUser user, string password)
        {
            var result = await _userManager.CheckPasswordAsync(user, password);
            return result;
        }


        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task<bool> ResetPasswordAsync(ApplicationUser user, string newPassword)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            if (token == null)
            {
                return false;
            }
            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
            return result.Succeeded;
        }

        public async Task<string> GetRoleAsync(ApplicationUser user)
        {
            var role = await _userManager.GetRolesAsync(user);

            return role.FirstOrDefault();
        }

        public async Task<bool> BlockUserAsync(ApplicationUser user)
        {
            user.LockoutEnabled = !user.LockoutEnabled;
            var result = await _applicationContext.SaveChangesAsync();
            if (result < 1)
            {
                return false;
            }
            return true;
        }

        public async Task<UserPresentationModel> GetUserAsync(UserFilterModel usersFilter)
        {
            var users = _applicationContext.Users.Where(k => k.IsRemoved== false).AsQueryable();
            if (!string.IsNullOrWhiteSpace(usersFilter.SearchString))
            {
                users = users.Where(k => k.UserName.Contains(usersFilter.SearchString));
            }

            if (usersFilter.UsersSortType == UserSortType.Email)
            {
                users = usersFilter.SortType == SortType.Increase ? users.OrderBy(k => k.Email) : users.OrderByDescending(k => k.Email);
            }
            if (usersFilter.UsersSortType == UserSortType.Name)
            {
                users = usersFilter.SortType == SortType.Increase ? users.OrderBy(k => k.UserName) : users.OrderByDescending(k => k.UserName);
            }
            if (usersFilter.UsersFilterType == usersFilter.UsersFilterType)
            {
                users = users.Where(k => k.LockoutEnabled == true);
            }
            if (usersFilter.UsersFilterType == UserFilterType.Blocked)
            {
                users = users.Where(k => k.LockoutEnabled == true);
            }
            var count = await users.CountAsync();
            users = users.Skip((usersFilter.PageNumber - 1) * usersFilter.PageSize).Take(usersFilter.PageSize);
            var presentationModel = new UserPresentationModel { Data = users.ToList(), Count = count };
            return presentationModel;
        }

      
    }
}



