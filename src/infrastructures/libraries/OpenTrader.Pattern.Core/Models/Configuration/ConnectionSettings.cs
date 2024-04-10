using OpenTrader.Pattern.Core.Models.Presets;

namespace OpenTrader.Pattern.Core.Models.Configuration;

/// <summary> Connection settings to broker <see cref="RabbitMQ.Client"/> </summary>
public record ConnectionSettings
{
    /// <summary>
    /// Port to create connection
    /// </summary>
    public ushort Port { get; init; } = RabbitMqDefault.Port;
    
    /// <summary>
    /// Host in connection
    /// </summary>
    public string Host { get; init; } = RabbitMqDefault.Host;
    
    /// <summary>
    /// VirtualPath in connection
    /// </summary>
    /// <example>
    ///     Default: "/"
    /// </example>
    public string VirtualPath { get; } = RabbitMqDefault.VirtualPath;
}