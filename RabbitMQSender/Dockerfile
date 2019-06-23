FROM mcr.microsoft.com/dotnet/core/runtime:2.2-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["RabbitMQSender/RabbitMQSender.csproj", "RabbitMQSender/"]
COPY ["SeleniumWebDriver/SeleniumWebDriver.csproj", "SeleniumWebDriver/"]
COPY ["SiteNewsApi/SiteNewsApi.csproj", "SiteNewsApi/"]
RUN dotnet restore "RabbitMQSender/RabbitMQSender.csproj"
COPY . .
WORKDIR "/src/RabbitMQSender"
RUN dotnet build "RabbitMQSender.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "RabbitMQSender.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "RabbitMQSender.dll"]