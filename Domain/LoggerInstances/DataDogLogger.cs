namespace pocBuilder
{
    public class DataDogLogger : ILoggerTest
    {
        private readonly ILogger _logger;
        private readonly DataDog _dataDog;

        public DataDogLogger(IConfiguration configuration, ILogger logger)
        {
            _logger = logger;
            _dataDog = new DataDog{
                DD_Trace = configuration["GeneralLogs:DataDogLogger:DD_Trace"],
                Name = configuration["GeneralLogs:DataDogLogger:Name"]
            };
        }

        public void LogEvent(string logItem)
        {
            _logger.LogInformation("This log came from DataDogLogger: " + logItem);
        }

        public void LogException(string logItem)
        {
            _logger.LogError("This log came from DataDogLogger: " + logItem);
        }

        public void LogRequest(string logItem)
        {
            _logger.LogWarning("This log came from DataDogLogger: " + logItem);
        }
    }
}
