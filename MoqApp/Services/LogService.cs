using Microsoft.Extensions.Logging;

namespace MoqApp.Services
{
    public class LogService : ILogService
    {
        private readonly ILogger _logger;

        public LogService(ILogger<LogService> logger)
        {
            _logger = logger;
        }

        public void LogInformation(string message, params object[] parameters)
        {
            _logger.LogInformation(message, parameters);
        }
    }
}