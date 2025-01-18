# Use the official .NET SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build

# Set the working directory
WORKDIR /app

# Install the dotnet-ef CLI tool globally
RUN dotnet tool install --global dotnet-ef

# Ensure the global tools directory is added to PATH
ENV PATH="$PATH:/root/.dotnet/tools"

# Copy csproj and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the remaining source code and build
COPY . ./
RUN dotnet publish -c Release -o out

# Use the official ASP.NET Core runtime image for running the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS runtime
WORKDIR /app

# Copy the build output from the build stage
COPY --from=build /app/out ./

# Expose port 80
EXPOSE 80

# Define the entry point
ENTRYPOINT ["dotnet", "Games.dll"]
