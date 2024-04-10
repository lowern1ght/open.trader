using Serilog.Events;

namespace OpenTrader.Logger.Models;

public record LoggerOptions
{
    public string? ConnectionString { get; init; } = string.Empty;
 
    public string MinimalLevel { get; init; } = nameof(LogEventLevel.Information);
}
