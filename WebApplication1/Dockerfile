# Use the official .NET SDK image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 10000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Replace with your actual project file name
COPY ["YourProjectName.csproj", "./"]
RUN dotnet restore "./WebApplication1.csproj"

COPY . .
RUN dotnet publish "./WebApplication1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "WebApplication1.dll"]
