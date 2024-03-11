using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;

namespace OpenTrader.Logger.Dependency;

public static class WebApplicationExtensions
{
    public static WebApplicationBuilder AddOpenTraderLogger(this WebApplicationBuilder builder, bool withDatabase = false)
    {
        return withDatabase ? AddOpenTraderLoggerWithDatabase(builder) : AddOpenTraderLoggerWitOutDatabase(builder);
    }

    private static WebApplicationBuilder AddOpenTraderLoggerWithDatabase(this WebApplicationBuilder builder)
    {
        if (builder.Configuration.LoggerOptions() is not {} loggerOptions)
            throw new InvalidOperationException($"{nameof(loggerOptions)} is null");
        
        var logger = new LoggerConfiguration()
            .MinimumLevel.Is(Enum.Parse<LogEventLevel>(loggerOptions.MinimalLevel))
            .DefaultConfiguration()
            .Enrich.WithEnvironment(builder.Environment.EnvironmentName)
            .WriteTo.Console(theme: SystemConsoleTheme.Colored)
            .WriteTo.PostgreSQL(
                loggerOptions.ConnectionString, 
                tableName: Assembly.GetExecutingAssembly().GetName().Name)
            .CreateLogger();
        
        builder.Logging.ClearProviders()
            .AddSerilog(logger);

        return builder;
    }
    
    private static WebApplicationBuilder AddOpenTraderLoggerWitOutDatabase(this WebApplicationBuilder builder)
    {
        if (builder.Configuration.LoggerOptions() is not {} loggerOptions)
            throw new InvalidOperationException($"{nameof(loggerOptions)} is null");
        
        var logger = new LoggerConfiguration()
            .MinimumLevel.Is(Enum.Parse<LogEventLevel>(loggerOptions.MinimalLevel))
            .DefaultConfiguration()
            .Enrich.WithEnvironment(builder.Environment.EnvironmentName)
            .WriteTo.Console(theme: SystemConsoleTheme.Colored)
            .CreateLogger();
        
        builder.Logging.ClearProviders()
            .AddSerilog(logger);

        return builder;
    }

    private static LoggerConfiguration DefaultConfiguration(this LoggerConfiguration configuration)
    {
        return configuration
            .Enrich.WithMemoryUsage()
            .Enrich.WithProcessId()
            .Enrich.WithProcessName()
            .Enrich.WithThreadId()
            .Enrich.WithThreadName();
    }
}