using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Trader.Constants;

namespace Trader.Extensions.Application;

public static class WebApplicationBuilderExtensions
{
    /// <summary>
    ///     Add routing and configuration this to Trader.Applications
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <returns></returns>
    public static IServiceCollection AddTraderRouting(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddRouting();

        serviceCollection.Configure<RouteOptions>(options =>
        {
            options.LowercaseUrls = true;
            options.LowercaseQueryStrings = true;
        });

        return serviceCollection;
    }

    /// <summary>
    ///     Add antiforgery and configuration this to Trader.Applications
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <returns></returns>
    public static IServiceCollection AddTraderAntiforgery(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAntiforgery();

        serviceCollection.Configure<AntiforgeryOptions>(options =>
        {
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
            options.Cookie.Expiration = TimeSpan.FromDays(30);
            options.Cookie.SameSite = SameSiteMode.Strict;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            options.Cookie.Name = Cookie.AntiforgeryCookieName;
        });

        return serviceCollection;
    }

    /// <summary>
    ///     Add trader cors policies to service collection
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <returns></returns>
    public static IServiceCollection AddTraderCors(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddCors(options =>
        {
            options.AddPolicy(CorsPolicies.AllowAll, builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowAnyOrigin();
            });
        });

        return serviceCollection;
    }

    #region Swagger

    /// <summary>
    ///     Add swagger to web application if env is "Development"
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static WebApplicationBuilder AddTraderSwagger(this WebApplicationBuilder builder)
    {
        if (builder.Environment.IsDevelopment())
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }

        return builder;
    }

    /// <summary>
    ///     Use swagger in web application if env is "Development"
    /// </summary>
    /// <param name="application"></param>
    /// <returns></returns>
    public static WebApplication UseTraderSwagger(this WebApplication application)
    {
        if (application.Environment.IsDevelopment())
        {
            application.UseSwagger();
            application.UseSwaggerUI();
        }

        return application;
    }

    /// <summary>
    ///     use required services to all Trader.Applications
    /// </summary>
    /// <param name="application"></param>
    /// <returns></returns>
    public static WebApplication UseTraderDefault(this WebApplication application)
    {
        application.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
        });

        return application;
    }

    #endregion

    #region Configuration
    
    private static readonly string IdentityConfigName = "identity";
    
    /// <summary>
    /// Add identity(.Environment).json config file
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static WebApplicationBuilder AddIdentityConfig(this WebApplicationBuilder builder)
    {
        var path = IdentityConfigName + (builder.Environment.IsDevelopment() ? ".Development" : String.Empty) + ".json";
        builder.Configuration.AddJsonFile(Path.Combine("Configs", path), false, true);
        
        return builder;
    }

    #endregion
}