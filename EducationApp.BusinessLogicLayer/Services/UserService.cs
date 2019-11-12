using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EducationApp.BusinessLogicLayer.Helpers.Mapping;
using EducationApp.BusinessLogicLayer.Models.Users;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace EducationApp.BusinessLogicLayer.Services
{
    class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> ChangeEmail(ApplicationUser user, string newEmail)
        {
            var token = await _userRepository.GenerateChangeEmailTokenAsync(user, newEmail);
            return await _userRepository.ChangeEmailAsync(user, newEmail, token);
        }

        public async Task<bool> ChangePassword(ApplicationUser user, string oldPassword, string newPassword)
        {
            if (ExcistUser(user)) { return false; }
            var result = await _userRepository.ChangePasswordAsync(user, oldPassword, newPassword);
            return result;
        }

        public async Task<bool> EditProfile(UserItemModel model)
        {
            var user = await _userRepository.GetByEmailAsync(model.Email);
            model = UserMaping.Map(user);
            user = UserMaping.Map(model);
            var result = await _userRepository.EditAsync(user);
            return result;

        }

        public async Task<ApplicationUser> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (ExcistUser(user)) { return null; }
            return user;
        }

        public async Task<ApplicationUser> GetById(long id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (ExcistUser(user)) { return null; }
            return user;
        }

        public async Task<ApplicationUser> GetByName(string name)
        {
            var user = await _userRepository.GetByNameAsync(name);
            if (ExcistUser(user)) { return user; }
            return null; ;
        }

        public async Task<bool> Remove(ApplicationUser user)
        {
            if (ExcistUser(user))
            {
                return false;
            }
            var result = await _userRepository.RemoveAsync(user);
            return result;
        }

        public async Task<bool> BlockUserAsync(long id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (ExcistUser(user)) { user.LockoutEnabled = !user.LockoutEnabled; }
            return user.LockoutEnabled;
        }



        public async Task<UserItemModel> Profile(long id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            var userItemModel = UserMaping.Map(user);
            return userItemModel;
        }

        public bool ExcistUser(ApplicationUser user)
        {
            if (user == null || user.IsRemoved == true)
            {
                return false;
            }
            return true;
        }

        public void FilterUsers()
        {
            throw new NotImplementedException();
        }

        //public void FilterUsers()
        //{
        //    var filterDictionary = new Dictionary<string, ApplicationUser> { }

        //}
    }
}
