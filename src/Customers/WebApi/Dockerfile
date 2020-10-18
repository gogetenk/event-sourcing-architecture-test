#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Customers/YtDeveloppement.EventSourcing.Microservices.Customers.WebApi/YtDeveloppement.EventSourcing.Microservices.Customers.WebApi.csproj", "src/Customers/YtDeveloppement.EventSourcing.Microservices.Customers.WebApi/"]
RUN dotnet restore "src/Customers/YtDeveloppement.EventSourcing.Microservices.Customers.WebApi/YtDeveloppement.EventSourcing.Microservices.Customers.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Customers/YtDeveloppement.EventSourcing.Microservices.Customers.WebApi"
RUN dotnet build "YtDeveloppement.EventSourcing.Microservices.Customers.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YtDeveloppement.EventSourcing.Microservices.Customers.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YtDeveloppement.EventSourcing.Microservices.Customers.WebApi.dll"]