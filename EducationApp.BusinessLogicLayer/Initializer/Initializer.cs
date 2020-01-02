using EducationApp.BusinessLogicLayer.Helpers;
using EducationApp.BusinessLogicLayer.Services;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using EducationApp.DataAccessLayer.InitRepositories;
using EducationApp.DataAccessLayer.Initialisation;
using Microsoft.AspNetCore.Identity;
using EducationApp.BusinessLogicLayer.Models.MyOptions.Email;

namespace EducationApp.BusinessLogicLayer.BaseInit
{
    public class Initializer
    {
        public static void InitServices(IServiceCollection services, string connectionString, PasswordOptions passwordOptions)
        {
            DataAccessInitialisation.InitRepositories(services, connectionString,passwordOptions);

            services.AddTransient<EmailOptions>();

            services.AddTransient<TokenValidationParameters>();

            services.AddTransient<DataBaseInitialisation>();

            services.AddTransient<IEmailSender, EmailSender>();

            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped<IAuthorService, AuthorService>();

            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IPrintingEditionService, PrintingEditionService>();
        }
    }
}
