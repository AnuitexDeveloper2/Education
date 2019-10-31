using BookStore.DataAccess.AppContext;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using static EducationApp.DataAccessLayer.Entities.Constants.Constants;
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
    public async Task<bool> Add(ApplicationUser user, string password)
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

    public Task Autharisation(ApplicationUser user)
    {
        throw new NotImplementedException();
    }

    //public async Task<bool> AuthenticationAsync(string password)
    //{
    //    List<ApplicationUser> listUsers = await ListAll();
    //    //listUsers.Where(k => k.PasswordHash.ToString() == password);
    //    foreach (var item in listUsers)
    //    {
    //        if (item.PasswordHash.ToString() == password)
    //        {
    //            await _userManager.GenerateUserTokenAsync();
    //            ApplicationUser user = item;
    //            var authentitication = await _signInManager.CheckPasswordSignInAsync(user, password,)
    //                return authentitication.
    //        }
    //    }




    public async Task<List<ApplicationUser>> ListAll()
    {

        List<ApplicationUser> allUser = await _applicationContext.Users.ToListAsync<ApplicationUser>();
        return allUser;
    }

    public async Task<bool> EditAsync(ApplicationUser user)
    {
        var edit = await _userManager.UpdateAsync(user);
        return edit.Succeeded;
    }

    public async Task<ApplicationUser> FindNameAsync(string userName)
    {
        var appUser = await _userManager.FindByNameAsync(userName);
        return appUser;
    }

    public Task<Role> CheckRole(ApplicationUser user)
    {
        throw new NotImplementedException();
    }

    public Task<ApplicationUser> GetById(long id)
    {
        throw new NotImplementedException();
    }

     async Task<bool> IUserRepository.RemoveAsync(ApplicationUser user)
    {
        var deleteUser = await _userManager.DeleteAsync(user);
        return deleteUser.Succeeded;
    }

    public Task<Role> CheckRole(ApplicationUser user, string password)
    {
        throw new NotImplementedException();
    }

    public Task<string> ChangeRole(Role role)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AuthenticationAsync(string password)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Add(ApplicationUser user)
    {
        throw new NotImplementedException();
    }

    
}

