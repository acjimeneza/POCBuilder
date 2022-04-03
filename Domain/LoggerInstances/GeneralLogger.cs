namespace pocBuilder
{

    public class GeneralLogger : ILoggerTest
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly List<ILoggerTest> _configLogs;

        public GeneralLogger(IConfiguration configuration, ILogger logger)
        {
            _configuration = configuration;
            _logger = logger;
            var configLogs = new ConfigureLoggers(configuration, logger);
            _configLogs = configLogs.ConfigLogs;
        }

        public void LogEvent(string logItem)
        {

            foreach (var log in _configLogs)
            {
                log.LogEvent(logItem);
            }
        }

        public void LogException(string logItem)
        {
            foreach (var log in _configLogs)
            {
                log.LogEvent(logItem);
            }
        }

        public void LogRequest(string logItem)
        {
            foreach (var log in _configLogs)
            {
                log.LogEvent(logItem);
            }
        }
    }
}
