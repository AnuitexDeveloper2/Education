using EducationApp.BusinessLogicLayer.Helpers;
using EducationApp.BusinessLogicLayer.Models.Users;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


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
            //await _userManager.ConfirmEmailAsync(excistUser, token);

            return true;
        }

        public async Task<ApplicationUser> RegisterAsync(string name,string email,string password)
        {
            var user = new ApplicationUser { UserName = name,Email = email ,Password = password};

            await _userRepository.AddAsync(user, password);
            string mail = await _userRepository.GenerateEmailConfirmationTokenAsync(user);
            _emailSender.SendingEmailAsync(user.Email, "Theme", "Body");
            return user;
        }
       
        public async Task<ApplicationUser> GetUserAsync(string userName, string password)
        {
           return await _userRepository.GetByNameAsync(userName);
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user)
        {
           return await _userRepository.GenerateEmailConfirmationTokenAsync(user);
        }
       

        public Task RestorePassword(string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task ConfirmEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

    }
}
