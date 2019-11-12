using BookStore.DataAccess.AppContext;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EducationApp.DataAccessLayer.Entities.Constants.Constants.Roles;

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
        public async Task<bool> AddAsync(string email, string password, string firstName, string lastName)
        {
            var excistUser = _userManager.FindByEmailAsync(email);
            if (excistUser.Result != null)
            {
                return false;
            }
            var user = new ApplicationUser { Email = email, UserName = lastName };
            var createUser = _userManager.CreateAsync(user, password).GetAwaiter().GetResult();
            if (createUser.Succeeded == true)
            {
                _userManager.AddToRoleAsync(user, User).GetAwaiter().GetResult();
                await _applicationContext.SaveChangesAsync();
            }
            return createUser.Succeeded;
        }
        public async Task<bool> EditAsync(ApplicationUser user)
        {
            if (user == null)
            {
                return false;
            }
            try
            {

                var edit = await _userManager.UpdateAsync(user);
                var result = await _applicationContext.SaveChangesAsync();
            }
            catch (Exception exp)
            {

            }
            return true;
        }

        public async Task<bool> RemoveAsync(ApplicationUser user)
        {
            if (user == null)
            {
                return false;
            }
            user.IsRemoved = true;
            await _userManager.UpdateAsync(user);
            return user.IsRemoved;

        }
        public async Task<Role> CheckRoleAsync(string email)
        {
            var userEntity = await _userManager.FindByEmailAsync(email);
            var userRole = await _userManager.GetRolesAsync(userEntity);
            return await _applicationContext.Roles.FindAsync(userRole);
        }


        public async Task<ApplicationUser> GetByIdAsync(long id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }

        public async Task<ApplicationUser> GetByNameAsync(string userName)
        {
            var userEntity = _userManager.FindByNameAsync(userName);

            return await userEntity;
        }

        public async Task<bool> ChangePasswordAsync(ApplicationUser user, string oldPassword, string newPassword)
        {
            var changePassword = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            return changePassword.Succeeded;
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
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
        }
        public async Task<bool> ChangeEmailAsync(ApplicationUser user, string newEmail, string token)
        {
            var result = await _userManager.FindByEmailAsync(newEmail);
            if (result != null)
            {
                return false;
            }
            var changePassword = await _userManager.ChangeEmailAsync(user, newEmail, token);
            return changePassword.Succeeded;
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
            var check = _userManager.CheckPasswordAsync(user, password);
            var checkPassword = await _signInManager.CheckPasswordSignInAsync(user, password, lockoutOnFailure: true);
            return checkPassword.Succeeded;
        }

        public async Task<bool> SignInAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return false;
            }
            await _signInManager.SignInAsync(user, isPersistent: true);
            return true;
        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task<IdentityResult> ResetPassword(ApplicationUser user, string token, string newPassword)
        {
            var resetPassword = await _userManager.ResetPasswordAsync(user, token, newPassword);
            return resetPassword;
        }

        public async Task<string> GenerateChangeEmailTokenAsync(ApplicationUser user, string newEmail)
        {
            return await _userManager.GenerateChangeEmailTokenAsync(user, newEmail);
        }

        public async Task<string> GetRoleAsync(ApplicationUser user)
        {
            var role = await _userManager.GetRolesAsync(user);
            foreach (var item in role)
            {
                if (item == "Admin")
                {
                    return item;
                }
                if (item == "User")
                {
                    return item;
                }
            }
            return null;
        }

        //public async Task<IEnumerable<ApplicationUser>> Sort()
        //{

        //}
    }

}



