using Microsoft.Extensions.Logging;

namespace Dal.Tests
{
    public class LoggerFixture<T>
    {
        public ILogger Logger {get; private set;}
        public LoggerFixture()
        {
            ILoggerFactory loggerFactory = new LoggerFactory()
                .AddConsole()
                .AddDebug();
            Logger = loggerFactory.CreateLogger<T>();
        }
    }
}
