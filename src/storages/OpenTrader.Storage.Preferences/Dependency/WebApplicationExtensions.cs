using Microsoft.AspNetCore.Builder;

namespace OpenTrader.Storage.Preferences.Dependency;

public static class WebApplicationExtensions
{
    /// <summary>
    /// Add
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static WebApplicationBuilder AddPreferencesDbContext(this WebApplicationBuilder builder)
    {
        throw new NotImplementedException();
    }
}