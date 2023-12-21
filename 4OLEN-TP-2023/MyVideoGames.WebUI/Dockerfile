#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

ENV ASPNETCORE_ENVIRONMENT Development

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MyVideoGames.WebUI/MyVideoGames.WebUI.csproj", "MyVideoGames.WebUI/"]
COPY ["MyVideoGames.Console.DataProvider/MyVideoGames.Console.DataProvider.csproj", "MyVideoGames.Console.DataProvider/"]
COPY ["MyVideoGames.DataContext/MyVideoGames.DataContext.csproj", "MyVideoGames.DataContext/"]
COPY ["MyVideoGames.Model/MyVideoGames.Model.csproj", "MyVideoGames.Model/"]
RUN dotnet restore "./MyVideoGames.WebUI/./MyVideoGames.WebUI.csproj"
COPY . .
WORKDIR "/src/MyVideoGames.WebUI"
RUN dotnet build "./MyVideoGames.WebUI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MyVideoGames.WebUI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyVideoGames.WebUI.dll"]