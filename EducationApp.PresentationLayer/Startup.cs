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
            Initializer.InitServices(services, Configuration.GetConnectionString("DefaultConnection"));

            services.AddTransient<IJwtHelper, JwtHelper>();

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
                    IssuerSigningKey = JwtHelper.GetSymmetricSecurityKey(),
                    ValidateIssuerSigningKey = true,
                };
            });

            services.AddMvc();

            services.AddCors();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
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

           
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
