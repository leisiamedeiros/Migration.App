FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Migration.App.Creator/Migration.App.Creator.csproj", "Migration.App.Creator/"]
RUN dotnet restore "Migration.App.Creator/Migration.App.Creator.csproj"
COPY . .
WORKDIR "/src/Migration.App.Creator"
RUN dotnet build "Migration.App.Creator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Migration.App.Creator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Migration.App.Creator.dll"]