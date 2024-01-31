using Trader.Configuration.Models;

namespace Trader.Pattern.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class PatternMetaAttribute : Attribute
{
    public required string Name { get; init; }
    public required long ProviderId { get; init; }
    public required Sections Sections { get; init; }
}