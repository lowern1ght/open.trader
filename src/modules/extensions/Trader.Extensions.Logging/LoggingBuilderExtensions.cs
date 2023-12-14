using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using TextExtensions;

namespace Trader.Extensions.Logging;

public static class LoggingBuilderExtensions
{
    private const string PostgresConnectionStringName = "LoggerConnection";

    private static readonly string TableName =
        Assembly.GetEntryAssembly()?.GetName().FullName.ToSnakeCase() ?? "log-common";

    /// <summary>
    ///     Add to someone Trader.Application logging on postgres, file, console
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static WebApplicationBuilder AddTraderLogger(this WebApplicationBuilder builder)
    {
        var serilog = new LoggerConfiguration()
            .MinimumLevel.Is(builder.Environment.IsDevelopment()
                ? LogEventLevel.Debug
                : LogEventLevel.Information)
            .WriteTo.Console()
            .WriteTo.PostgreSQL(
                builder.Configuration.GetConnectionString(PostgresConnectionStringName),
                TableName, levelSwitch: new LoggingLevelSwitch())
            .CreateLogger();

        builder.Logging.ClearProviders()
            .AddSerilog(serilog);

        return builder;
    }
}