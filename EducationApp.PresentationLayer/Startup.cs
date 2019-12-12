using EducationApp.BusinessLogicLayer.BaseInit;
using EducationApp.BusinessLogicLayer.Helpers;
using EducationApp.PresentationLayer.Helpers.Middlware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using static EducationApp.BusinessLogicLayer.Common.Consts.Consts.JWTConsts;
using EducationApp.PresentationLayer.Helpers;
using EducationApp.PresentationLayer.Helpers.Interfaces;
using Microsoft.OpenApi.Models;

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
            Initializer.InitServices(services, Configuration.GetConnectionString("DefaultConnection"));

            var tokenValidationParameter = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = JwtHelper.GetSymmetricSecurityKey(),

                ValidIssuer = Issuer,
                ValidateIssuer = true,

                ValidAudience = Audience,
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

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            //});
            services.AddMvcCore();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
         
            app.UseMiddleware<ErrorMiddlware>();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();      

            app.UseDefaultFiles();
            app.UseStaticFiles();


            app.UseCors(builder => builder.WithOrigins("http://localhost:4200"));


            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            //    c.RoutePrefix = string.Empty;
            //});

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
