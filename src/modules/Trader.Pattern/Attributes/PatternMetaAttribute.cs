using Trader.Constants.Configuration;

namespace Trader.Pattern.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class PatternMetaAttribute : Attribute
{
    public required string Name { get; init; }
    public required Type ProviderType { get; init; }
    public required Sections ServicesEnumeration { get; init; }
}