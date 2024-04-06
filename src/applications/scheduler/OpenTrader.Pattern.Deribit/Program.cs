using System.Reflection;
using OpenTrader.Constants.General;
using OpenTrader.Logger.Dependency;
using OpenTrader.Dependency.WebApplication;
using OpenTrader.Pattern.Core.Dependency.LibraryExtensions;
using OpenTrader.Pattern.Core.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddTraderSwagger();
builder.AddOpenTraderLogger();
builder.Services.AddTraderCors();
builder.Services.AddTraderRouting();
builder.Services.AddForwarderHeaders();

builder.Services.AddTraderMassTransit(builder.Configuration);

var application = builder.Build();

application.UseForwardedHeaders();

application.UseTraderSwagger();

application.UseRouting();
application.UseCors(CorsPolicies.AllowAll);

application.MapControllers();

application.Run();