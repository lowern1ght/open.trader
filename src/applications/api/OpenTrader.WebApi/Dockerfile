FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/applications/api/Trader.WebApi/Trader.WebApi.csproj", "src/applications/api/Trader.WebApi/"]
COPY ["src/modules/extensions/Trader.Extensions.Logging/Trader.Extensions.Logging.csproj", "src/modules/extensions/Trader.Extensions.Logging/"]
COPY ["src/modules/extensions/Trader.Extensions.Identity/Trader.Extensions.Identity.csproj", "src/modules/extensions/Trader.Extensions.Identity/"]
COPY ["src/modules/Trader.Constants/Trader.Constants.csproj", "src/modules/Trader.Constants/"]
COPY ["src/modules/extensions/Trader.Extensions/Trader.Extensions.csproj", "src/modules/extensions/Trader.Extensions/"]
COPY ["src/modules/Trader.Models/Trader.Models.csproj", "src/modules/Trader.Models/"]
COPY ["src/storages/Trader.Storage.Account/Trader.Storage.Account.csproj", "src/storages/Trader.Storage.Account/"]
RUN dotnet restore "src/applications/api/Trader.WebApi/Trader.WebApi.csproj"
COPY . .
WORKDIR "/src/src/applications/api/Trader.WebApi"
RUN dotnet build "Trader.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Trader.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Trader.WebApi.dll"]
