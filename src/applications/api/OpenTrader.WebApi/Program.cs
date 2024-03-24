using OpenTrader.Storage.Account.Extensions;
using OpenTrader.Exchange.Service.Dependency;
using OpenTrader.Asp.Extensions.Configuration;
using OpenTrader.Asp.Extensions.WebApplication;
using OpenTrader.Constants.General;
using OpenTrader.Identity.Service.Dependency;
using OpenTrader.Logger.Dependency;

var builder = WebApplication.CreateBuilder(args);

builder.AddOpenTraderLogger();

builder.AddTraderSwagger();
builder.Services.AddTraderCors();
builder.Services.AddTraderRouting();
builder.Services.AddTraderAntiforgery();
builder.Services.AddForwarderHeaders();

#region DbContexts

builder.Services.AddIdentityTraderDbContext(builder.Configuration);

#endregion

builder.AddS3Settings();
builder.AddTraderIdentity();

//Todo: fix auth cookie, dont change cookie or dont auth successes 

#region Services

builder.Services.AddExchangeServices();

#endregion

var application = builder.Build();

application.UseTraderSwagger();

if (application.Environment.IsDevelopment())
{
    application.UseDeveloperExceptionPage();
}
else
{
    application.UseHsts();
}

application.UseForwardedHeaders();

application.UseRouting();

application.UseCors(CorsPolicies.AllowAll);

application.UseAuthentication();
application.UseAuthorization();

application.MapControllers();

application.Run();