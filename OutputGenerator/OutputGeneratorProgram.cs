using Microsoft.Extensions.Logging;

namespace ProcessOutputTest
{
    public class OutputGeneratorProgram
    {
        static void Main(string[] args)
        {
            LoggerFactory loggerFactory = new LoggerFactory();
            loggerFactory.
                AddConsole(LogLevel.Debug);
            ILogger logger = loggerFactory.CreateLogger("test");

            for (int i = 0; i < 1000; i++)
            {
                logger.LogDebug("{0} test test test test test test test test test test test", i);
            }

            loggerFactory.Dispose();
        }
    }
}