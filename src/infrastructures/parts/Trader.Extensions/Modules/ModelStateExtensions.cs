using System.Text.Json;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Trader.Extensions.Modules;

public static class ModelStateExtensions
{
    /// <summary>
    ///     Get errors and serialize to string
    /// </summary>
    /// <param name="stateDictionary"></param>
    /// <returns></returns>
    public static string ToData(this ModelStateDictionary stateDictionary)
    {
        var errorCollections = stateDictionary.Values
            .Select(entry => entry.Errors)
            .ToArray();

        return JsonSerializer.Serialize(errorCollections);
    }
}