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
    private readonly RoleManager<Role> _roleManager;

    public UserRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationContext applicationContext, RoleManager<Role> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _applicationContext = applicationContext;
        _roleManager = roleManager;
    }
    public async Task<bool> AddAsync(ApplicationUser user, string password)
    {

        _userManager.CreateAsync(user, password).GetAwaiter().GetResult();
        var addUser = _userManager.CreateAsync(user).GetAwaiter().GetResult();
        if (user.UserName == Admin)
        {
            var userRole = new Role { Name = Admin };
            _roleManager.CreateAsync(userRole).GetAwaiter().GetResult();
        }
        if (addUser.Succeeded)
        {
            await _applicationContext.SaveChangesAsync();
        }
        return addUser.Succeeded;
    }


    public async Task<Role> CheckRoleAsync(ApplicationUser user)
    {
        List<ApplicationUser> allUser = await _applicationContext.Users.ToListAsync();
        var chekRole = _roleManager.Roles.Where(k => k.Id == user.Id);
        foreach (var item in allUser)
        {
            if (user == null)
            {
                return null;
            }
            if (chekRole == null)
            {
                return null;
            }
        }
        return await _applicationContext.Roles.FindAsync(chekRole);
    }

    public async Task<List<ApplicationUser>> ListAllAsync()
    {
        List<ApplicationUser> allUser = await _applicationContext.Users.ToListAsync();
        return allUser;
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

    public async Task<ApplicationUser> GetById(long id)
    {

        List<ApplicationUser> allUser = await _applicationContext.Users.ToListAsync();
        return await _userManager.FindByIdAsync(id.ToString());
    }

    async Task<bool> IUserRepository.RemoveAsync(ApplicationUser user)
    {
        if (user == null)
        {
            return false;
        }
        var deleteUser = await _userManager.DeleteAsync(user);
        return deleteUser.Succeeded;
    }
    public Task Autharisation(ApplicationUser user)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> VerifyAsync(ApplicationUser user,string password)
    {
        if (user == null)
        {
            return false;
        }
               return await _signInManager.UserManager.CheckPasswordAsync(user, password);

    }

    public async Task<ApplicationUser> FindNameAsync(string userName)
    {
        List<ApplicationUser> allUser = await _applicationContext.Users.ToListAsync();

        var appUser = await _userManager.FindByNameAsync(userName);
        return appUser;
    }

    

   

}



