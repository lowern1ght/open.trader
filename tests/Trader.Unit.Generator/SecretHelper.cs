using IdentityModel;

namespace Trader.Unit.Generator;

/// <summary>
/// Helper generator secret client token
/// </summary>
public static class SecretHelper
{
    public static string GenerateSha256()
    {
        return Guid.NewGuid().ToString().ToSha256();
    }

    public static string GenerateSha512()
    {
        return Guid.NewGuid().ToString().ToSha512();
    }
}