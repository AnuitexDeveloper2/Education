using Microsoft.Extensions.Logging;
using System;

namespace EducationApp.BusinessLogicLayer.Common.Interfaces
{
    public interface ILogger
    {

        IDisposable BeginScope<TState>(TState state);
      
        bool IsEnabled(LogLevel logLevel);
        
        void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter);
        void AddFile(string v);
        void CreateLogger(string p);
    }
}
