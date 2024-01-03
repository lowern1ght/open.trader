using System.Reflection;
using Trader.Pattern.Attributes;
using Trader.Pattern.Interfaces;

namespace Trader.Helpers.Exchange;

public static class AssemblyPatternHelper
{
    /// <summary>
    /// Get from assembly pattern
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<KeyValuePair<PatternDescriptionAttribute, Type>> GetDescriptionAttributes()
    {
        var (assembly, descriptions) = (Assembly.GetExecutingAssembly(), 
            new List<KeyValuePair<PatternDescriptionAttribute, Type>>());

        foreach (var type in assembly.GetTypes())
        {
            if (type.IsClass && 
                type.IsAssignableTo(typeof(IPattern<>)) && 
                type.GetCustomAttribute<PatternDescriptionAttribute>() is {} descriptionAttribute)
            {
                descriptions.Add(new (descriptionAttribute, type));
            }
        }

        return descriptions;
    }
}