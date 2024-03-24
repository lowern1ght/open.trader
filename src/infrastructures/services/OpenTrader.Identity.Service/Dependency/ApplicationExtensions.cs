using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using OpenTrader.Identity.Service.Extensions;
using OpenTrader.Identity.Service.Helpers;
using OpenTrader.Identity.Service.Interfaces;
using OpenTrader.Storage.Account;
using OpenTrader.Storage.Account.Models;
using SameSiteMode = Microsoft.AspNetCore.Http.SameSiteMode;

namespace OpenTrader.Identity.Service.Dependency;

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
            options.HttpOnly = HttpOnlyPolicy.Always;
            options.Secure = CookieSecurePolicy.Always;
            options.MinimumSameSitePolicy = SameSiteMode.Strict;
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
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
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
                    
                    return SchemeSelect.IsJwtAuthorization(authorization.ToString()) 
                        ? JwtBearerDefaults.AuthenticationScheme 
                        : CookieAuthenticationDefaults.AuthenticationScheme;
                };
            });

        collection.ConfigureApplicationCookie(options =>
        {
            options.Cookie.IdentityCookie();
        });
    }

    /// <summary>
    /// Add default Authorization to this application
    /// </summary>
    /// <param name="collection"></param>
    private static void AddTraderAuthorization(this IServiceCollection collection)
    {
        collection.AddAuthorization(options =>
        {
            options.InvokeHandlersAfterFailure = false;
            
            options.DefaultPolicy = new AuthorizationPolicyBuilder(CookieAuthenticationDefaults.AuthenticationScheme)
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