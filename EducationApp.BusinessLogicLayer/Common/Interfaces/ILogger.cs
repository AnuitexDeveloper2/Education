using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicLayer.Common.Interfaces
{
    public interface ILoggerFile
    {

       
        IDisposable BeginScope<TState>(TState state);
    
        bool IsEnabled(LogLevel logLevel);
       
       
        Task Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter);
    }
}
