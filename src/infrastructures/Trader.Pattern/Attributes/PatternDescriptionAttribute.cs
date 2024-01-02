namespace Trader.Pattern.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
public class PatternDescriptionAttribute : Attribute
{
    public required string Name { get; init; }
    public required string Description { get; init; }
}