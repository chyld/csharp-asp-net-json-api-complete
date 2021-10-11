#
# to create a docker image
# docker build -t todo:latest .
#

# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
# creates a directory and moves to it
WORKDIR /source
# copy all our files to the /source directory
COPY . .
# download all packages and tools the app uses
RUN dotnet restore
# change directory to the main project
WORKDIR /source/web
# creates a release build and move those to the /app directory
RUN dotnet publish -c release -o /app --no-restore

# in this step we use the aspnet image, not the sdk
# we only keep the /app directory, which is copied over from the previous layer
# https://hub.docker.com/_/microsoft-dotnet-aspnet
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "web.dll"]
