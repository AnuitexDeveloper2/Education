using EducationApp.BusinessLogicLayer.Helpers;
using EducationApp.BusinessLogicLayer.Helpers.Mapping;
using EducationApp.BusinessLogicLayer.Models.Base;
using EducationApp.BusinessLogicLayer.Models.Users;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using System.Threading.Tasks;
using error = EducationApp.BusinessLogicLayer.Common.Consts.Constants.Errors;
using emailConst = EducationApp.BusinessLogicLayer.Common.Consts.Constants.EmailRules;
using EducationApp.BusinessLogicLayer.Extention.Mapper.UserMapper;


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

            if (token == null)
            {
                return false;
            }

            return true;
        }

        public async Task<BaseModel> CreateUserAsync(UserModelItem userItemModel)
        {
            var userModel = new BaseModel();

            var user = userItemModel.Map();

            var userCreate = await _userRepository.CreateUserAsync(user,userItemModel.Password);

            if (!userCreate)
            {
                userModel.Errors.Add(error.UserCreate);
                return userModel;
            }

            _emailSender.SendingEmailAsync(emailConst.UserEmail, emailConst.MailSubject, emailConst.MailBody);

            return userModel;
        }



        public async Task<BaseModel> ConfirmEmailAsync(string email)
        {
            var userModel = new BaseModel();

            var user = await _userRepository.FindByEmailAsync(email);
            
            if (user == null)
            {
                userModel.Errors.Add(error.NotFound);
                return userModel;
            
            }
            string token = await _userRepository.GenerateEmailConfirmationTokenAsync(user);
            
            var result = await _userRepository.ConfirmEmailAsync(user, token);
            
            if (!result)
            {
                userModel.Errors.Add(error.ConfirmEmail);
            
            }
            return userModel;
        }

        public async Task<UserModelItem> GetByIdAsync(long id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            var role = await _userRepository.GetRoleAsync(user);

            var userModel = user.Map();

            userModel.Role = role;

            return userModel;
        }

        public async Task<UserModelItem> GetByEmailAsync(string email)
        {
            if (email == null)
            {
                return null;
            }
            var user = await _userRepository.FindByEmailAsync(email);
            var model = user.Map();
            model.Role = await _userRepository.GetRoleAsync(user);
            return model;
        }

        public async Task<BaseModel> SignIn(string email, string password)
        {
             var usersModel = new BaseModel();
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                usersModel.Errors.Add(error.EmptyField);
                return usersModel;
            }
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
            {
                usersModel.Errors.Add(error.NotFound);
                return usersModel;
            }
            var checkPassword = await _userRepository.ConfirmPasswordAsync(user, password);
            if (!checkPassword)
            {
                usersModel.Errors.Add(error.NotValidPassword);
                return usersModel;
            }
            return usersModel;
        }

        public async Task SignOutAsync()
        {
            await _userRepository.SignOut();
        }
    }
}
