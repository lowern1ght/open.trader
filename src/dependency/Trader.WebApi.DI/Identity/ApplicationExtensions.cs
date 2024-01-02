using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Trader.Extensions.Configuration;
using Trader.Identity.Service;
using Trader.Identity.Service.Interfaces;
using Trader.Storage.Account;
using Trader.Storage.Account.Models;
using Trader.WebApi.DI.Others;
using SameSiteMode = Microsoft.AspNetCore.Http.SameSiteMode;

namespace Trader.WebApi.DI.Identity;

public static class ApplicationExtensions
{
        /// <summary>
    /// Add default AuthenticationOptions to this application
    /// </summary>
    /// <param name="collection"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    private static void AddTraderAuthentication(this IServiceCollection collection, IConfiguration configuration)
    {
        collection.AddIdentity<TraderUser, IdentityRole>()
            .AddEntityFrameworkStores<IdentityTraderDbContext>()
            .AddDefaultTokenProviders();

        var identityConfig = configuration.GetIdentityConfig();
        
        collection.AddHttpContextAccessor();
        collection.AddSingleton(identityConfig); //Add IdentityConfig to accesses context
        collection.AddTransient<IIdentityService<TraderUser>, IdentityService>();
        
        collection.Configure<CookiePolicyOptions>(options =>
        {
            // This lambda determines whether user consent for non-essential cookies is needed for a given request. 
            options.CheckConsentNeeded = _ => true;
            options.MinimumSameSitePolicy = SameSiteMode.None;
        });
        
        collection.AddAuthentication(options =>
            {
                options.DefaultScheme = Constants.General.Identity.Scheme.TraderIdentity;
                options.DefaultChallengeScheme = Constants.General.Identity.Scheme.TraderIdentity;
                options.DefaultAuthenticateScheme = Constants.General.Identity.Scheme.TraderIdentity;
                options.DefaultForbidScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.Cookie.IdentityCookie();
                options.ExpireTimeSpan = TimeSpan.FromDays(31);

                options.LoginPath = Constants.General.Identity.Path.LoginUrl;
                options.LogoutPath = Constants.General.Identity.Path.LogoutUrl;

                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return Task.CompletedTask;
                };
            })
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(identityConfig.Key))
                };
            })
            .AddPolicyScheme(Constants.General.Identity.Scheme.TraderIdentity, Constants.General.Identity.Scheme.TraderIdentity, options =>
            {
                options.ForwardDefaultSelector = context =>
                {
                    var authorization = context.Request.Headers[HeaderNames.Authorization];
                    
                    if (!string.IsNullOrEmpty(authorization) && authorization.ToString().StartsWith($"{JwtBearerDefaults.AuthenticationScheme} "))
                        return JwtBearerDefaults.AuthenticationScheme;

                    // otherwise always check for cookie auth
                    return CookieAuthenticationDefaults.AuthenticationScheme;
                };
            });
    }

    /// <summary>
    ///     Add default Authorization to this application
    /// </summary>
    /// <param name="collection"></param>
    private static void AddTraderAuthorization(this IServiceCollection collection)
    {
        collection.AddAuthorization(options =>
        {
            options.InvokeHandlersAfterFailure = false;
            
            options.DefaultPolicy = new AuthorizationPolicyBuilder(CookieAuthenticationDefaults.AuthenticationScheme, JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .RequireAssertion(context => context.User.Identity is { IsAuthenticated: true })
                .Build();
        });
    }
    
    /// <summary>
    /// Add to web application builder default Trader Identity
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static WebApplicationBuilder AddTraderIdentity(this WebApplicationBuilder builder)
    {
        builder.Services.AddTraderAuthentication(builder.Configuration);
        builder.Services.AddTraderAuthorization();
        
        return builder;
    }
}