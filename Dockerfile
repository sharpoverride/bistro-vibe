FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy solution and project files
COPY CulinaryVault.sln .
COPY CulinaryVault/CulinaryVault.csproj CulinaryVault/
COPY CulinaryVault.Client/CulinaryVault.Client.csproj CulinaryVault.Client/
COPY CulinaryVault.Shared/CulinaryVault.Shared.csproj CulinaryVault.Shared/
COPY RecipeImporter/RecipeImporter.csproj RecipeImporter/
COPY CulinaryVault.Tests/CulinaryVault.Tests.csproj CulinaryVault.Tests/

# Restore dependencies
RUN dotnet restore

# Copy source code
COPY . .

# Build
WORKDIR /src/CulinaryVault
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

# Create directories for data and uploads
RUN mkdir -p /app/data /app/wwwroot/uploads

# Copy published app
COPY --from=publish /app/publish .

# Set environment variables
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ConnectionStrings__DefaultConnection="Data Source=/app/data/culinaryvault.db"

ENTRYPOINT ["dotnet", "CulinaryVault.dll"]
