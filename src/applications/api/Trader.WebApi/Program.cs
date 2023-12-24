using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Trader.Constants;
using Trader.Extensions.Application;
using Trader.Extensions.Logging;
using Trader.Extensions.Others;
using Trader.Storage.Account;
using Trader.Storage.Account.Extensions;
using Trader.Storage.Account.Models;
using Trader.Storage.Inventory.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddTraderLogger();
builder.AddTraderSwagger();
builder.Services.AddTraderCors();
builder.Services.AddTraderRouting();
builder.Services.AddTraderAntiforgery();

#region DbContexts

builder.Services.AddInventoryDbContext(builder.Configuration);
builder.Services.AddIdentityTraderDbContext(builder.Configuration);

#endregion

builder.AddS3Settings();
builder.AddTraderServicesConfig();

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<IdentityTraderDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 5;
    options.Password.RequireDigit = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
});

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddJwtBearer();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = Cookie.Identity;
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SameSite = SameSiteMode.Strict;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.LoginPath = "/identity/login";
    options.LogoutPath = "/identity/logout";
});

#region Services

builder.Services.AddExchangeService();

#endregion

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

application.UseAuthentication();
application.UseAuthorization();

application.UseCors(CorsPolicies.AllowAll);

application.MapDefaultControllerRoute()
    .RequireAuthorization();

application.Run();