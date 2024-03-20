#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Product/Product.Query/Query.API/Query.API.csproj", "Services/Product/Product.Query/Query.API/"]
COPY ["Services/Product/Product.Query/Query.Infrastructure/Query.Infrastructure.csproj", "Services/Product/Product.Query/Query.Infrastructure/"]
COPY ["Services/Product/Product.Query/Query.Core/Core.Application/Core.Application.csproj", "Services/Product/Product.Query/Query.Core/Core.Application/"]
COPY ["Services/Product/Product.Query/Query.Core/Query.Domain/Core.Domain.csproj", "Services/Product/Product.Query/Query.Core/Query.Domain/"]
RUN dotnet restore "./Services/Product/Product.Query/Query.API/Query.API.csproj"
COPY . .
WORKDIR "/src/Services/Product/Product.Query/Query.API"
RUN dotnet build "./Query.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Query.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Query.API.dll"]