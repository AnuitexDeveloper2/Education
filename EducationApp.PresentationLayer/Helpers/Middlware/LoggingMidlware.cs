using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;

namespace EducationApp.PresentationLayer.Helpers.Middlware
{
    public class LoggingMidlware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMidlware> _logger;

        public LoggingMidlware(RequestDelegate next, ILogger<LoggingMidlware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exeption)
            {
                _logger.LogError(0, exeption, "");
            }
        }


    }
}