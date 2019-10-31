using EducationApp.BusinessLogicLayer.BaseInit;
using EducationApp.BusinessLogicLayer.Common;
using EducationApp.DataAccessLayer.Initialisation;
using EducationApp.PresentationLayer.Helpers.Middlware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataBaseInitialisation initializer, ILoggerFactory logger)
        {
            initializer.StartInit();

            logger.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));

            app.UseMiddleware<RoutingMiddlwareException>();
        }
    }
}
