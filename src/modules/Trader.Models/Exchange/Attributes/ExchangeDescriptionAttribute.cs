namespace Trader.Models.Exchange.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class ExchangeDescriptionAttribute : Attribute
{
    public required string Name { get; set; }
    public required string BaseUrl { get; set; }
    public required string DisplayName { get; set; }
    public required string ResourceName { get; set; }
}