# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiamos el csproj y restauramos dependencias
COPY Api.Rest.Net8.API.csproj ./
RUN dotnet restore ./Api.Rest.Net8.API.csproj

# Copiamos todo el código
COPY . .
RUN dotnet publish ./Api.Rest.Net8.API.csproj -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Escuchar en todas las interfaces
ENV ASPNETCORE_URLS=http://+:80
ENV DOTNET_ENVIRONMENT=Development

EXPOSE 80

ENTRYPOINT ["dotnet", "ApiRest.Net8.API.dll"]