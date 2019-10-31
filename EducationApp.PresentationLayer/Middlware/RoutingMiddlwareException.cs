using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace EducationApp.PresentationLayer.Helpers.Middlware
{
    public class RoutingMiddlwareException
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;

        public RoutingMiddlwareException(RequestDelegate next, ILoggerFactory logger)
        {
            _next = next;
            _logger = logger.CreateLogger("Logger");
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "Error");
                await HandleExceptionAsync(context, exp.GetBaseException());
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exp)
        {
            var code = HttpStatusCode.InternalServerError; 
            var result = JsonConvert.SerializeObject(new { Code = code, Message = exp.Message, StackTrace = exp.StackTrace });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }
}
