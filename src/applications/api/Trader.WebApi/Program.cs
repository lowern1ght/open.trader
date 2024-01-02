using Trader.Constants.General;
using Trader.Exchange.Service.Dependency;
using Trader.General.DI.Common;
using Trader.WebApi.DI.Identity;
using Trader.Storage.Account.Extensions;
using Trader.Storage.Inventory.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddTraderSwagger();
builder.Services.AddTraderCors();
builder.Services.AddTraderRouting();
builder.Services.AddTraderAntiforgery();

#region DbContexts

builder.Services.AddInventoryDbContext(builder.Configuration);
builder.Services.AddIdentityTraderDbContext(builder.Configuration);

#endregion

builder.AddS3Settings();
builder.AddTraderIdentity();
builder.AddTraderServicesConfig();

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
    application.UseHttpsRedirection();
    application.UseHsts();
}

application.UseTraderDefault();

application.UseRouting();

application.UseCors(CorsPolicies.AllowAll);

application.UseAuthentication();
application.UseAuthorization();

application.MapControllers();

application.Run();