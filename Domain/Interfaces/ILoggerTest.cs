namespace pocBuilder
{
    public interface ILoggerTest
    {
        void LogEvent(string logItem);

        void LogException(string logItem);

        void LogRequest(string logItem);
    }
}