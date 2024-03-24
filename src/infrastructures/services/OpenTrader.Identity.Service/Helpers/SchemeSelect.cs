using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace OpenTrader.Identity.Service.Helpers;

public static class SchemeSelect
{
    public static bool IsJwtAuthorization(string authorization)
    {
        return !string.IsNullOrEmpty(authorization) &&
               authorization.StartsWith($"{JwtBearerDefaults.AuthenticationScheme} ") &&
               authorization.Replace(" ", "")
                   .Replace($"{JwtBearerDefaults.AuthenticationScheme}", "") != string.Empty;
    }
}