#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Product/Product.Command/Command.API/Command.API.csproj", "Services/Product/Product.Command/Command.API/"]
COPY ["Services/Product/Product.Command/Command.Infrastructure/Command.Infrastructure.csproj", "Services/Product/Product.Command/Command.Infrastructure/"]
COPY ["Services/Product/Product.Command/Command.Core/Core.Application/Core.Application.csproj", "Services/Product/Product.Command/Command.Core/Core.Application/"]
COPY ["Services/Product/Product.Command/Command.Core/Core.Domain/Core.Domain.csproj", "Services/Product/Product.Command/Command.Core/Core.Domain/"]
RUN dotnet restore "./Services/Product/Product.Command/Command.API/Command.API.csproj"
COPY . .
WORKDIR "/src/Services/Product/Product.Command/Command.API"
RUN dotnet build "./Command.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Command.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Command.API.dll"]