using EducationApp.BusinessLogicLayer.BaseInit;
using EducationApp.BusinessLogicLayer.Common;
using EducationApp.BusinessLogicLayer.Helpers;
using EducationApp.DataAccessLayer.Initialisation;
using EducationApp.PresentationLayer.Helpers.Middlware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using static EducationApp.BusinessLogicLayer.Common.Consts.Consts.JWTConsts;
using EducationApp.PresentationLayer.Helpers;
using EducationApp.PresentationLayer.Helpers.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace EducationApp.PresentationLayer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            Initializer.Init(services, Configuration.GetConnectionString("DefaultConnection"));
            services.AddTransient<ITokenFactory, TokenFactory>();
           
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; 
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = Issuer,
                    ValidateAudience = true,
                    ValidAudience = Audience,
                    ValidateLifetime = true,
                    IssuerSigningKey = TokenFactory.GetSymmetricSecurityKey(),
                    ValidateIssuerSigningKey = true,
                };
            });
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataBaseInitialisation initializer, IEmailSender emailSender)
        {
            initializer.StartInit();

            app.UseMiddleware<ErrorMiddlware>();


            app.UseHttpsRedirection();

            app.UseRouting();

          
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwagger();
            app.UseSwaggerUI();

        }
    }
}
