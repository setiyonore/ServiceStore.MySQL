FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ENV ASPNETCORE_URLS http://*:44319
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 44319
WORKDIR /src
EXPOSE 80
EXPOSE 443

# copy csproj and restore as distinct layers
COPY *.sln .
COPY ["ServiceStore.MySQL/*.csproj", "./ServiceStore.MySQL/"]
RUN dotnet restore

# copy everything else and build app
# COPY ServiceStore.MySQL/. ./ServiceStore/
COPY ["ServiceStore.MySQL/.", "./ServiceStore.MySQL/"]
WORKDIR ./ServiceStore.MySQL
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /src
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "ServiceStore.MySQL.dll"]