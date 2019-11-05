using BookStore.DataAccess.AppContext;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using static EducationApp.DataAccessLayer.Entities.Constants.Constants.Roles;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace EducationApp.DataAccessLayer.Ropositories.EFRepositories
{
}
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
    public async Task<bool> AddAsync(string email, string password)
    {
        var excistUser = _userManager.FindByEmailAsync(email);
        if (excistUser != null)
        {
            return false;
        }
        var user = new ApplicationUser { Email = email, Password = password };
        _userManager.CreateAsync(user, password).GetAwaiter().GetResult();
        var createUser = _userManager.CreateAsync(user).GetAwaiter().GetResult();
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
        var edit = await _userManager.UpdateAsync(user);
        return edit.Succeeded;
    }

    async Task<bool> IUserRepository.RemoveAsync(ApplicationUser user)
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

    public async Task<bool> VerifyAsync(ApplicationUser user, string password)
    {
        if (user == null)
        {
            return false;
        }
        return await _signInManager.UserManager.CheckPasswordAsync(user, password);
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
        await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        return await _userManager.CheckPasswordAsync(user, newPassword);
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
        var changePassword = await _userManager.ChangeEmailAsync(user, newEmail, token);
        return changePassword.Succeeded;
    }

    public async Task<bool> ConfirmEmailAsync(ApplicationUser user, string token)
    {
        await _userManager.ConfirmEmailAsync(user, token);
        user.EmailConfirmed = true;
        var result = user.EmailConfirmed;
        _applicationContext.SaveChangesAsync().GetAwaiter().GetResult();
        return result;
    }

    public async Task<ApplicationUser> FindByEmailAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }

    public async Task<bool> ConfirmPasswordAsync(ApplicationUser user,string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }

    public async Task SignInAsync(string email,string password)
    {
       var user = await _userManager.FindByEmailAsync(email);
        _signInManager.SignInAsync(user,);
    }

    public async Task<ApplicationUser> SignOut()
    {
        var user = await _signInManager.SignOutAsync();

    }
}



