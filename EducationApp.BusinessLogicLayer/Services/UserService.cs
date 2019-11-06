using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;

namespace EducationApp.BusinessLogicLayer.Services
{
    class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> ChangeEmail(ApplicationUser user,string newEmail)
        {
            var token = await _userRepository.GenerateChangeEmailTokenAsync(user,newEmail);
            return await _userRepository.ChangeEmailAsync(user, newEmail, token);
        }

        public async Task<bool> ChangePassword(ApplicationUser user, string oldPassword, string newPassword)
        {
            var result = await _userRepository.ChangePasswordAsync(user, oldPassword, newPassword);
            return result;
        }

        public void FilterUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            return user;
        }

        public async Task<ApplicationUser> GetById(long id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user;
        }

        public async Task<ApplicationUser> GetByName(string name)
        {
            var user = await _userRepository.GetByNameAsync(name);
            return user;
        }

        public async Task<bool> Remove(ApplicationUser user)
        {
            var result = await _userRepository.RemoveAsync(user);
            return result;
        }


    }
}
