FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app

EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/applications/api/OpenTrader.WebApi/OpenTrader.WebApi.csproj", "src/applications/api/OpenTrader.WebApi/"]
COPY ["src/infrastructures/libraries/OpenTrader.Asp.Extensions/OpenTrader.Asp.Extensions.csproj", "src/infrastructures/libraries/OpenTrader.Asp.Extensions/"]
COPY ["src/infrastructures/models/OpenTrader.Constants/OpenTrader.Constants.csproj", "src/infrastructures/models/OpenTrader.Constants/"]
COPY ["src/infrastructures/services/OpenTrader.Exchange.Service/OpenTrader.Exchange.Service.csproj", "src/infrastructures/services/OpenTrader.Exchange.Service/"]
COPY ["src/storages/OpenTrader.Storage.Account/OpenTrader.Storage.Account.csproj", "src/storages/OpenTrader.Storage.Account/"]
COPY ["src/infrastructures/services/OpenTrader.Identity.Service/OpenTrader.Identity.Service.csproj", "src/infrastructures/services/OpenTrader.Identity.Service/"]
COPY ["src/infrastructures/libraries/OpenTrader.Logger/OpenTrader.Logger.csproj", "src/infrastructures/libraries/OpenTrader.Logger/"]
RUN dotnet restore "src/applications/api/OpenTrader.WebApi/OpenTrader.WebApi.csproj"
COPY . .
WORKDIR "/src/src/applications/api/OpenTrader.WebApi"
RUN dotnet build "OpenTrader.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "OpenTrader.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OpenTrader.WebApi.dll"]
