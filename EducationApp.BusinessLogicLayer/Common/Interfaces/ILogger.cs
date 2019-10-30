using Microsoft.Extensions.Logging;
using System;

namespace EducationApp.BusinessLogicLayer.Common.Interfaces
{
    public interface ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
           
        }
    }
}
