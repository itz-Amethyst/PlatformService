#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CommandsService/CommandsService.csproj", "CommandsService/"]
RUN dotnet restore "CommandsService/CommandsService.csproj"
COPY . .
WORKDIR "/src/CommandsService"
RUN dotnet build "CommandsService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CommandsService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CommandsService.dll"]