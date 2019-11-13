using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EducationApp.BusinessLogicLayer.Extention.User;
using EducationApp.BusinessLogicLayer.Helpers.Mapping;
using EducationApp.BusinessLogicLayer.Models;
using EducationApp.BusinessLogicLayer.Models.Users;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using static EducationApp.BusinessLogicLayer.Extention.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Services
{
    class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> ChangeEmail(UserItemModel model, string newEmail)
        {
            var user = UserMaping.Map(model);
            var token = await _userRepository.GenerateChangeEmailTokenAsync(user, newEmail);
            return await _userRepository.ChangeEmailAsync(user, newEmail, token);
        }

        public async Task<bool> ChangePassword(UserItemModel model, string oldPassword, string newPassword)
        {
            var user = UserMaping.Map(model);
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

        public async Task<UserItemModel> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (ExcistUser(user)) { return null; }
            var model = UserMaping.Map(user);
            return model;
        }

        public async Task<UserItemModel> GetById(long id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (ExcistUser(user)) { return null; }
            var model = UserMaping.Map(user);
            return model;
        }

        public async Task<ApplicationUser> GetByName(string name)
        {
            var user = await _userRepository.GetByNameAsync(name);
            if (ExcistUser(user)) { return user; }
            return null; ;
        }

        public async Task<bool> Remove(UserItemModel model)
        {
            var user = UserMaping.Map(model);
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

        public List<UserItemModel> SortUsers(SortUser state)
        {

            var sort = UserMaping.Map(state);
            var sortUser = _userRepository.SortUser(sort).ToList();
            List<UserItemModel> model = new List<UserItemModel>();
            for (int i = 0; i < sortUser.Count(); i++)
            {
                model.Add(UserMaping.Map(sortUser[i]));
            }
            return model;
        }



    }
}
