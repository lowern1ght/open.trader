using System.Reflection;
using Trader.Models.Exchange.Attributes;
using Trader.Models.Exchange.Interfaces;

namespace Trader.Helpers.Exchange;

public static class ExchangeHelper
{
    /// <summary>
    /// Get attribute from classes implementations "IExchangeDescription"
    /// </summary>
    /// <param name="assemblyType"></param>
    /// <returns></returns>
    public static IEnumerable<ExchangeDescriptionAttribute> GetExchangesDescription(Type? assemblyType = null)
    {
        var descriptions = new List<ExchangeDescriptionAttribute>();

        var assembly = assemblyType is null 
            ? Assembly.GetAssembly(typeof(ExchangeDescriptionAttribute)) 
            : Assembly.GetAssembly(assemblyType);

        if (assembly is null)
        {
            throw new InvalidOperationException($"{nameof(assemblyType)} is null");
        }
        
        foreach (var type in assembly.GetTypes())
        {
            if (type.IsAssignableTo(typeof(IExchangeDescription)) && 
                type.GetCustomAttribute<ExchangeDescriptionAttribute>() is {} descriptionAttribute)
            {
                descriptions.Add(descriptionAttribute);
            }
        }

        return descriptions;
    }
}