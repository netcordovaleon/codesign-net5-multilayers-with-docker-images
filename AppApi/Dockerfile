FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app 
#
# copy csproj and restore as distinct layers
COPY *.sln .
COPY AppApi/*.csproj ./AppApi/
COPY Api.Entity/*.csproj ./Api.Entity/
COPY Api.Business/*.csproj ./Api.Business/
#
RUN dotnet restore 
#
# copy everything else and build app
COPY AppApi/. ./AppApi/
COPY Api.Entity/. ./Api.Entity/
COPY Api.Business/. ./Api.Business/ 
#
WORKDIR /app/AppApi
RUN dotnet publish -c Release -o out 
#
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app 
#
COPY --from=build /app/AppApi/out ./
ENTRYPOINT ["dotnet", "AppApi.dll"]