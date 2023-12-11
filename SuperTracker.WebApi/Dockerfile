# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the entire solution and restore dependencies
COPY . .

# Restore and publish the application
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Stage 2: Create the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy the published output from the build stage
COPY --from=build /app/out .

# Expose the port

# Set the entry point
ENTRYPOINT ["dotnet", "SuperTracker.WebApi.dll", "--urls", "http://*:5000"]
