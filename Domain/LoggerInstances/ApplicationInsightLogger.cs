namespace pocBuilder
{
    public class ApplicationInsightLogger : ILoggerTest
    {
        private readonly ILogger _logger;
        private readonly AppInsight _appInsight;

        public ApplicationInsightLogger(IConfiguration configuration, ILogger logger)
        {
            _logger = logger;
            _appInsight = new AppInsight{
                InstrumentationKey = configuration["GeneralLogs:ApplicationInsightLogger:InstrumentationKey"]
            };
        }

        public void LogEvent(string logItem)
        {
            _logger.LogInformation("This log came from ApplicationInsightLogger: " + logItem);
        }

        public void LogException(string logItem)
        {
            _logger.LogError("This log came from ApplicationInsightLogger: " + logItem);
        }

        public void LogRequest(string logItem)
        {
            _logger.LogWarning("This log came from ApplicationInsightLogger: " + logItem);
        }
    }
}
