using BookStore.DataAccess.AppContext;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Helpers;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
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
        public async Task<bool> CreateUserAsync(ApplicationUser user) //todo rename createUserAsync
        {
            var excistUser = await _userManager.FindByEmailAsync(user.Email);
            if (excistUser != null)
            {
                return false;
            }

            var createUser = await _userManager.CreateAsync(user);
            if (!createUser.Succeeded)
            {
                return false;
            }
            var result = await _userManager.AddToRoleAsync(user, User); //todo check res
            if (result == null)
            {
                return false;
            }
            var saveResult = await _applicationContext.SaveChangesAsync(); //return res
            if (saveResult < 1)
            {
                return false;
            }
            return createUser.Succeeded;
        }
        public async Task<bool> EditAsync(ApplicationUser user)
        {
            if (user == null) //todo check for null at service
            {
                return false;
            }
            await _userManager.UpdateAsync(user);
            var result = await _applicationContext.SaveChangesAsync(); //todo results
            if (result < 1)
            {
                return false;
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
            await _userManager.UpdateAsync(user); //todo return result
            return user.IsRemoved;

        }
        public async Task<string> CheckRoleAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email); //todo check null
            var userRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            return userRole; //todo return string role
        }


        public async Task<ApplicationUser> GetByIdAsync(long id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
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
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task SignInAsync(ApplicationUser user, bool isPersistent) //todo remove
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
        }
        public async Task<bool> ChangeEmailAsync(string oldEmail, string newEmail, string token) //todo param with emails and token
        {
            var user = await FindByEmailAsync(oldEmail); //todo use oldEmail to get user from DB
            if (user == null)
            {
                return false;
            }
            var changePasswordResult = await _userManager.ChangeEmailAsync(user, newEmail, token);
            return changePasswordResult.Succeeded;
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
            var check = _userManager.CheckPasswordAsync(user, password); //todo check result
            var checkPassword = await _signInManager.CheckPasswordSignInAsync(user, password, lockoutOnFailure: true); //todo Check logic
            return checkPassword.Succeeded;
        }

        public async Task<bool> SignInAsync(string email, string password) //todo check if need
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
            return resetPassword; //todo return bool
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



        public List<ApplicationUser> FilterUsers(UsersFilter usersFilter)
        {
            var users = _applicationContext.Users.Where(u => !u.IsRemoved).AsQueryable();
            //Dictionary<SortState, IQueryable<ApplicationUser>> filterUser = new Dictionary<SortState, IQueryable<ApplicationUser>>();
            //filterUser.Add(state.SortState, _userManager.Users.Where(k => k.IsRemoved == false));
            //filterUser.Add(state, _userManager.Users.Where(k => k.IsRemoved == true));
            //filterUser.Add(state, _userManager.Users.Where(k => k.LockoutEnabled == false));
            //filterUser.Add(state, _userManager.Users.Where(k => k.LockoutEnabled == false));
            users = usersFilter.UsersSortType == UsersSortType.EmailAsc ? users.OrderBy(k => k.Email) : users.OrderByDescending(k => k.Email);
            users = usersFilter.UsersSortType == UsersSortType.NameAsc ? users.OrderBy(k => k.UserName) : users.OrderByDescending(k => k.UserName);
            


            users = users.Skip((usersFilter.PageCount - 1) * usersFilter.PageSize).Take(usersFilter.PageSize);
            //todo add skip and take, and then ToListAsync()
            //todo read about IEnumerable and IQueryable
            return null;

        }


    }
}



