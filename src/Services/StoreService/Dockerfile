FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Services/StoreService/StoreService.csproj", "src/Services/StoreService/"]
RUN dotnet restore "src/Services/StoreService/StoreService.csproj"
COPY . .
WORKDIR "/src/src/Services/StoreService"
RUN dotnet build "StoreService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StoreService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StoreService.dll"]
