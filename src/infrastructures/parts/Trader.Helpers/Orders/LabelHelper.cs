using DEDrake;

namespace Trader.Helpers.Orders;

public static class LabelHelper
{
    /// <summary>
    /// Generate label by max symbol
    /// </summary>
    /// <param name="max"></param>
    /// <returns></returns>
    public static string GenerateOrderLabel(int max = 64)
    {
        var result = ShortGuid.NewGuid().ToString();

        if (result.Length > max)
        {
            return result[..max];
        }

        while (result.Length < max)
        {
            result += ShortGuid.NewGuid().ToString();
        }

        return result[..max];
    }
}