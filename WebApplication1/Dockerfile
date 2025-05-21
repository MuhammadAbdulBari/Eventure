# Use the official .NET SDK image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 10000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Replace with your actual project file name
COPY ["YourProjectName.csproj", "./"]
RUN dotnet restore "./YourProjectName.csproj"

COPY . .
RUN dotnet publish "./YourProjectName.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "YourProjectName.dll"]
