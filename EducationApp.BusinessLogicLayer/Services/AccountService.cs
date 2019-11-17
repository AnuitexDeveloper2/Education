using EducationApp.BusinessLogicLayer.Helpers;
using EducationApp.BusinessLogicLayer.Helpers.Mapping;
using EducationApp.BusinessLogicLayer.Models.Base;
using EducationApp.BusinessLogicLayer.Models.Users;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using System;
using System.Threading.Tasks;
using static EducationApp.BusinessLogicLayer.Common.Consts.Consts.EmailConsts;


namespace EducationApp.BusinessLogicLayer.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailSender _emailSender;
        public AccountService(IUserRepository userRepository, IEmailSender emailSender)
        {
            _userRepository = userRepository;
            _emailSender = emailSender;
        }

        public async Task<bool> ConfirmAccountAsync(string email)
        {
            var excistUser = await _userRepository.GetByEmailAsync(email);
            if (excistUser == null)
            {
                return false;
            }
            string token = await _userRepository.GenerateEmailConfirmationTokenAsync(excistUser);


            return true;
        }
      
        public async Task<bool> CreateUserAsync(UserItemModel userItemModel  )
        {
            var user = UserMapper.Map(userItemModel);
            var userCreate = await _userRepository.CreateUserAsync(user);
            if (userCreate)
            {
                _emailSender.SendingEmailAsync(UserEmail, MailSubject, $"Confirm registration by clicking on the link: <a href='{callbackUrl}'>link</a>");
                return true;
            }
            return false;
        }

        public async Task<ApplicationUser> GetUserAsync(string userName, string password)
        {
            return await _userRepository.GetByNameAsync(userName);
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(UserItemModel model)
        {
            var user = UserMapper.Map(model);
            return await _userRepository.GenerateEmailConfirmationTokenAsync(user);
        }


        public async Task<bool> RestorePasswordAsync(UserItemModel model)
        {
            var user = await _userRepository.GetByIdAsync(model.Id);
            if (user == null)
            {
                return false;
            }
            var token = await _userRepository.GeneratePasswordResetTokenAsync(user);
            var result = await _userRepository.ResetPassword(user, token, "Education2019");
            //_emailSender.SendingEmailAsync(user.Email, "Restore Password", newPassword);
            return result.Succeeded;
        }

        public async Task<bool> ConfirmEmailAsync(string email)
        {
            var user = await _userRepository.FindByEmailAsync(email);
            if (user == null)
            {
                return false;
            }
            string token = await _userRepository.GenerateEmailConfirmationTokenAsync(user);
            return await _userRepository.ConfirmEmailAsync(user, token);
        }

        public async Task<ApplicationUser> GetByIdAsync(long id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<UserItemModel> GetByEmailAsync(string email)
        {
            if (email == null)
            {
                return null;
            }
            var user = await _userRepository.FindByEmailAsync(email);
            var model = UserMapper.Map(user);
            model.Role = await _userRepository.GetRoleAsync(user);
            return model;
        }

        public async Task<bool> SignInAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            var passwordValid = await _userRepository.ConfirmPasswordAsync(user, password);
            if (!passwordValid)
            {
                return false;
            }
            var result = await _userRepository.SignInAsync(email, password);
            return result;
        }

        public async Task SignOutAsync()
        {
            await _userRepository.SignOut();
        }


        public async Task<bool> CheckByPassword(string email, string password)
        {
            var result = await _userRepository.SignInAsync(email, password);
            return result;
        }

        public async Task<string> GetRoleAsync(ApplicationUser user)
        {
            if (ExcistUser(user)) { return null; }
            var role = await _userRepository.GetRoleAsync(user);
            return role;
        }

        public async Task<bool> ConfirmPasswordAsync(ApplicationUser user, string password)
        {
            return await _userRepository.ConfirmPasswordAsync(user, password);
        }
        public bool ExcistUser(ApplicationUser user)
        {
            if (user == null || user.IsRemoved == true)
            {
                return true;
            }
            return false;
        }
    }
}
