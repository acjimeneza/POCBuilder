namespace pocBuilder;

public class ConfigureLoggers
{
    public readonly List<ILoggerTest> ConfigLogs;

    public ConfigureLoggers(IConfiguration configuration, ILogger logger)
    {
        // Use the reflection pattern to create classes based on its names http://software-pattern.org/Reflection
        // This code was based on this: https://stackoverflow.com/questions/223952/create-an-instance-of-a-class-from-a-string
        List<ILoggerTest> configLogs = new List<ILoggerTest>();
        foreach (var item in configuration.GetSection("GeneralLogs").GetChildren())
        {
            Type? type = Type.GetType("pocBuilder." + item.Key);
            if (type != null)
            {
                configLogs.Add(Activator.CreateInstance(type,
                                                        configuration,
                                                        logger) as ILoggerTest);
            }
            else
            {
                foreach (var assemblies in AppDomain.CurrentDomain.GetAssemblies())
                {
                    type = assemblies.GetType("pocBuilder." + item.Key);
                    if (type != null)
                    {
                        configLogs.Add(Activator.CreateInstance(type,
                                                                configuration,
                                                                logger) as ILoggerTest);
                        break;
                    }
                }
            }
        }
        ConfigLogs = configLogs;
    }
}
