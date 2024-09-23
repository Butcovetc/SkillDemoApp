using Microsoft.Extensions.Logging;
namespace DemoApp.MSTests.Common.Mocks
{
    internal class TraceLogger : ILogger
    {
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        //all levels enabled
        public bool IsEnabled(LogLevel logLevel) => true;
        

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            
        }
    }
}
