# ---- Stage 1: build ----
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish Healthcare.API/Healthcare.API.csproj -c Release -o /app/publish

# ---- Stage 2: run ----
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "Healthcare.API.dll"]