using Mapster;
using Microsoft.AspNetCore.Identity;
using Trader.Constants;
using Trader.Extensions.Application;
using Trader.Extensions.Identity.Configuration;
using Trader.Extensions.Logging;
using Trader.Storage.Account;
using Trader.Storage.Account.Extensions;
using Trader.Storage.Account.Models;

var builder = WebApplication.CreateBuilder(args);

builder.AddTraderLogger();

builder.Services.AddTraderCors();
builder.Services.AddControllers();
builder.Services.AddTraderRouting();
builder.Services.AddResponseCaching();
builder.Services.AddTraderAntiforgery();

builder.AddIdentityConfig();

#region IdentityServer

builder.Services.AddIdentityTraderDbContext(builder.Configuration);

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<IdentityTraderDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 5;
    options.Password.RequireDigit = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SameSite = SameSiteMode.Strict;
    options.Cookie.Name = Cookie.IdentityCookieName;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

var identityConfig = builder.Configuration.IdentityConfig();

builder.Services.AddIdentityServer()
    .AddInMemoryCaching()
    .AddDeveloperSigningCredential()
    .AddAspNetIdentity<User>()
    .AddTestUsers(identityConfig.TestClient)
    .AddInMemoryClients(identityConfig.Clients)
    .AddInMemoryApiScopes(identityConfig.ApiScopes)
    .AddInMemoryApiResources(identityConfig.ApiResources)
    .AddInMemoryIdentityResources(identityConfig.IdentityResources);
    
builder.Services.AddMapster();

#endregion

builder.AddTraderSwagger();

var application = builder.Build();

application.UseTraderSwagger();

if (application.Environment.IsDevelopment())
{
    application.UseDeveloperExceptionPage();
}
else
{
    application.UseHttpsRedirection();
    application.UseHsts();
}

application.UseTraderDefault();

application.UseStaticFiles();
application.UseResponseCaching();
application.UseRouting();

application.UseIdentityServer();
application.UseAuthorization();

application.UseCors(CorsPolicies.AllowAll);

application.MapDefaultControllerRoute();

application.Run();