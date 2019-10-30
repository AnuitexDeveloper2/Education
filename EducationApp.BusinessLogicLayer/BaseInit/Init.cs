using BookStore.DataAccess.AppContext;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Initialisation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EducationApp.BusinessLogicLayer.BaseInit
{
    public class Initializer
    {
        public static void Init(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationContext>(options =>
   options.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, Role>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<UserManager<ApplicationUser>>();
            services.AddTransient<RoleManager<Role>>();
            services.AddTransient<DataBaseInitialisation>();


        }
    }
}
