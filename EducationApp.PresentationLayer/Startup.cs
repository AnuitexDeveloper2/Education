using EducationApp.BusinessLogicLayer.BaseInit;
using EducationApp.BusinessLogicLayer.Common;
using EducationApp.BusinessLogicLayer.Common.Interfaces;
using EducationApp.DataAccessLayer.Initialisation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;

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
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataBaseInitialisation initializer,ILoggerFactory logger)
        {
            initializer.StartInit();

            logger.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
            var log = logger.CreateLogger("FileLogger");

            app.Run(async (context) =>
            {
                log.LogInformation("Processing request {0}", context.Request.Path);
                await context.Response.WriteAsync("Hello World!");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
