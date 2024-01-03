using Trader.Models.Configuration;

namespace Trader.Pattern.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class PatternDescriptionAttribute : Attribute
{
    /// <summary>
    /// Unique pattern name
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Current pattern direction type
    /// </summary>
    public ServicesEnumeration ItemType { get; set; }
    
    /// <summary>
    /// Base exchange provider
    /// </summary>
    public Type ParentExchange { get; set; }

    public PatternDescriptionAttribute(string name, ServicesEnumeration itemType, Type exchangeProvider)
    {
        Name = name;
        ItemType = itemType;
        ParentExchange = exchangeProvider;
    }
}