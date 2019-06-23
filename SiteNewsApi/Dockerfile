FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["SiteNewsApi/SiteNewsApi.csproj", "SiteNewsApi/"]
RUN dotnet restore "SiteNewsApi/SiteNewsApi.csproj"
COPY . .
WORKDIR "/src/SiteNewsApi"
RUN dotnet build "SiteNewsApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SiteNewsApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SiteNewsApi.dll"]