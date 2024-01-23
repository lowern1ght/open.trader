using System.Reflection;
using Trader.Pattern.Interfaces;
using Trader.Pattern.Attributes;
using Trader.Pattern.Models.Common;

namespace Trader.Pattern.Utilities;

public static class PatternMeta
{
    public static IEnumerable<PatternMetaDescription> GetDescriptionFromAssembly()
    {
        var descriptions = new List<PatternMetaDescription>();

        foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
        {
            if (type.IsClass && 
                type.IsAssignableTo(typeof(IPattern<>)) && 
                type.GetCustomAttribute<PatternMetaAttribute>() is {} metaAttribute)
            {
                descriptions.Add(new ()
                {
                    PatternType = type,
                    MetaAttribute = metaAttribute
                });
            }
        }
        
        return descriptions;
    }
}