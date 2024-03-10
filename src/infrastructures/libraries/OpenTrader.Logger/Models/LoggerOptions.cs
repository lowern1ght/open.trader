using Serilog.Events;

namespace OpenTrader.Logger.Models;

public class LoggerOptions(string connectionString, string minimalLevel)
{
    public string MinimalLevel { get; init; } = minimalLevel is null or { Length: 0 } 
        ? nameof(LogEventLevel.Information) 
        : minimalLevel;
    
    public string ConnectionString { get; init; } = connectionString;
}