namespace Trader.Pattern.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class ExchangeProviderAttribute : Attribute
{
    public required string Name { get; set; }
    
    public required string DisplayName { get; set; }
    
    public required string ResourceName { get; set; }
}