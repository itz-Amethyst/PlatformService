#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PlatformService/PlatformService.csproj", "PlatformService/"]
COPY ["PlatformManagement.Infrastructure.Configuration/PlatformManagement.Infrastructure.Configuration.csproj", "PlatformManagement.Infrastructure.Configuration/"]
COPY ["PlatformManagement.Infrastructure.EFCore/PlatformManagement.Infrastructure.EFCore.csproj", "PlatformManagement.Infrastructure.EFCore/"]
COPY ["PlatformManagement.Domain/PlatformManagement.Domain.csproj", "PlatformManagement.Domain/"]
COPY ["0_Framework/0_Framework.csproj", "0_Framework/"]
COPY ["PlatformManagement.Application.Contracts/PlatformManagement.Application.Contracts.csproj", "PlatformManagement.Application.Contracts/"]
RUN dotnet restore "PlatformService/PlatformService.csproj"
COPY . .
WORKDIR "/src/PlatformService"
RUN dotnet build "PlatformService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PlatformService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PlatformService.dll"]