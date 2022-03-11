FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Feetur.Management/Feetur.Management.csproj", "Feetur.Management/"]
RUN dotnet restore "Feetur.Management/Feetur.Management.csproj"
COPY . .
WORKDIR "/src/Feetur.Management"
RUN dotnet build "Feetur.Management.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Feetur.Management.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Feetur.Management.dll"]
