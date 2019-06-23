FROM mcr.microsoft.com/dotnet/core/runtime:2.2-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["RabbitMqConsumer/RabbitMqConsumer.csproj", "RabbitMqConsumer/"]
COPY ["SiteNewsApi/SiteNewsApi.csproj", "SiteNewsApi/"]
RUN dotnet restore "RabbitMqConsumer/RabbitMqConsumer.csproj"
COPY . .
WORKDIR "/src/RabbitMqConsumer"
RUN dotnet build "RabbitMqConsumer.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "RabbitMqConsumer.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "RabbitMqConsumer.dll"]
