using BookStore.DataAccess.AppContext;
using EducationApp.BusinessLogicLayer.Helpers;
using EducationApp.BusinessLogicLayer.Services;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Initialisation;
using EducationApp.DataAccessLayer.Repositories.EFRepositories;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using EducationApp.DataAccessLayer.Ropositories.EFRepositories;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace EducationApp.BusinessLogicLayer.BaseInit
{
    public class Initializer
    {
        public static void Init(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationContext>(options =>
   options.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, Role>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
            }
            )
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();
            services.AddTransient<TokenValidationParameters>();
            services.AddTransient<UserManager<ApplicationUser>>();
            services.AddTransient<RoleManager<Role>>();
            services.AddTransient<SignInManager<ApplicationUser>>();
            services.AddTransient<DataBaseInitialisation>();
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPrintingEditionRepository, PrintingEditionRepository>();
            services.AddScoped<IPrintingEditionService, PrintingEditionService>();
            services.AddScoped<IAuthorInPrintingEditionRepository, AuthorInPrintingEditionRepository>();

        }
    }
}
