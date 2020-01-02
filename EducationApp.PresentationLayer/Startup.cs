using EducationApp.BusinessLogicLayer.BaseInit;
using EducationApp.PresentationLayer.Helpers.Middlware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using EducationApp.PresentationLayer.Helpers;
using EducationApp.PresentationLayer.Helpers.Interfaces;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;
using EducationApp.BusinessLogicLayer.Models.MyOptions.JWT;
using EducationApp.BusinessLogicLayer.Models.MyOptions.Email;
using EducationApp.BusinessLogicLayer.Models.MyOptions.Swagger;
using settingsOptions = EducationApp.BusinessLogicLayer.Common.Constants.AppSettingsOptions;

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
            services.AddControllers();
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
            });
            services.AddCors();
            
            services.AddTransient<IJwtHelper, JwtHelper>();

            var emailOptions = Configuration.GetSection(settingsOptions.Email).Get<EmailOptions>();
            services.Configure<EmailOptions>(options => Configuration.GetSection(settingsOptions.Email).Bind(options));


            var passwordOptions = Configuration.GetSection(settingsOptions.Password).Get<PasswordOptions>();
            Initializer.InitServices(services, Configuration.GetConnectionString(settingsOptions.ConnectionString), passwordOptions);

            var jwtOptions = Configuration.GetSection(settingsOptions.JWT).Get<JWTOptions>();
            services.Configure<JWTOptions>(options => Configuration.GetSection(settingsOptions.JWT).Bind(options));

            var swaggerOptions = Configuration.GetSection(settingsOptions.Swagger).Get<SwaggerOptions>();

            var tokenValidationParameter = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = JwtHelper.GetSymmetricSecurityKey(jwtOptions.Key),
                ValidIssuer = jwtOptions.Issuer,
                ValidateIssuer = true,
                ValidAudience = jwtOptions.Audience,
                ValidateAudience = true,
                ValidateLifetime = true
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = tokenValidationParameter;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = swaggerOptions.Url, Version = swaggerOptions.Version });
            });
            services.AddMvcCore();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseMiddleware<ErrorMiddlware>();

            app.UseRouting();
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials());


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
