# Net5 + Multilayers + Docker Images

Basic example using Net5 and Docker (Generate docker images and run locally)

## Dockerfile
```bash

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
```

## Docker Build Image

```bash
docker build -f AppApi/Dockerfile -t api_image .
```

## Docker Run Image locally

- api_container = Define el nuevo nombre del container
- api_image = Se especifica que el contendor usara la imagen llamada "api_image" generada previamente
- 5000:80 = El puerto donde corre la aplicación desde el contenedor es el "80" pero para exponerlo en nuestra PC usara el "5000" (Esto puede cambiar segun su especificación

```bash
docker run -d -p 5000:80 — name api_container api_image
```