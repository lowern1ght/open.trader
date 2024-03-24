using Microsoft.AspNetCore.Http;
using OpenTrader.Constants.General;

namespace OpenTrader.Identity.Service.Extensions;

public static class CookieBuilderExtensions
{
    #region CookieSettings

    /// <summary>
    /// Setup default settings trader identity to CookieBuilder
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static void IdentityCookie(this CookieBuilder builder)
    {
        builder.HttpOnly = true;
        builder.Name = Cookie.Identity;
        builder.SameSite = SameSiteMode.Strict;
        builder.SecurePolicy = CookieSecurePolicy.Always;
    }
    
    #endregion
}