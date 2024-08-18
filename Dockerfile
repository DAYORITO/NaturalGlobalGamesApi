# Utilizar la imagen base de .NET SDK para compilar y publicar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar los archivos de proyecto y restaurar las dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar el resto de los archivos y construir la aplicación
COPY . ./
RUN dotnet publish -c Release -o /out

# Utilizar la imagen base de ASP.NET para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out .

# Establecer la variable de entorno para que ASP.NET sepa qué puerto utilizar
ENV ASPNETCORE_URLS=http://+:80

# Exponer el puerto en el contenedor
EXPOSE 80

# Comando para iniciar la aplicación
ENTRYPOINT ["dotnet", "GamepageAPI.dll"]
