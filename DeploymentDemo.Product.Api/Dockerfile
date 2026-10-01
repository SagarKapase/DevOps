# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY ["DeploymentDemo.Product.Api.csproj", "./"]

RUN dotnet restore "DeploymentDemo.Product.Api.csproj"

COPY . .

RUN dotnet publish "DeploymentDemo.Product.Api.csproj" \
    -c Release \
    -o /app/publish \
    --no-restore

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "DeploymentDemo.Product.Api.dll"]