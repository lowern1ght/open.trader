FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/applications/services/Trader.IdentityServer/Trader.IdentityServer.csproj", "src/applications/services/Trader.IdentityServer/"]
COPY ["src/modules/extensions/STBL.General/STBL.General.csproj", "src/modules/extensions/STBL.General/"]
COPY ["src/modules/extensions/STBL.Logging/STBL.Logging.csproj", "src/modules/extensions/STBL.Logging/"]
COPY ["src/storages/Trader.Storage.Account/Trader.Storage.Account.csproj", "src/storages/Trader.Storage.Account/"]
COPY ["src/modules/Trader.Models/Trader.Models.csproj", "src/modules/Trader.Models/"]
RUN dotnet restore "src/applications/services/Trader.IdentityServer/Trader.IdentityServer.csproj"
COPY . .
WORKDIR "/src/src/applications/services/Trader.IdentityServer"
RUN dotnet build "Trader.IdentityServer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Trader.IdentityServer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Trader.IdentityServer.dll"]
