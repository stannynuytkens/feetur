FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Feetur.Api/Feetur.Api.csproj", "Feetur.Api/"]
RUN dotnet restore "Feetur.Api/Feetur.Api.csproj"
COPY . .
WORKDIR "/src/Feetur.Api"
RUN dotnet build "Feetur.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Feetur.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Feetur.Api.dll"]
