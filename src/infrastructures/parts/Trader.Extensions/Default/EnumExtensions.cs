using TextExtensions;

namespace Trader.Extensions.Default;

public static class EnumExtensions
{
    /// <summary>
    /// Covert enum name to kebab case
    /// </summary>
    /// <param name="enum"></param>
    /// <returns></returns>
    public static string ToKebabCase(this Enum @enum)
    {
        return @enum.ToString().ToKebabCase();
    }
    
    /// <summary>
    /// Covert enum name to snake case
    /// </summary>
    /// <param name="enum"></param>
    /// <returns></returns>
    public static string ToSnakeCase(this Enum @enum)
    {
        return @enum.ToString().ToSnakeCase();
    }
    
    /// <summary>
    /// Covert enum name to lower case
    /// </summary>
    /// <param name="enum"></param>
    /// <returns></returns>
    public static string ToLowerCase(this Enum @enum)
    {
        return @enum.ToString().ToLower();
    }
}