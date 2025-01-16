# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar o arquivo de projeto diretamente
COPY HelloWorld.API/HelloWorld.API.csproj ./HelloWorld.API/

# Restaurar dependências
RUN dotnet restore ./HelloWorld.API/HelloWorld.API.csproj

# Copiar o restante dos arquivos do projeto
COPY HelloWorld.API/ ./HelloWorld.API/

# Publicar o projeto diretamente usando o arquivo .csproj
WORKDIR /app/HelloWorld.API
RUN dotnet publish ./HelloWorld.API.csproj -c Release -o out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/HelloWorld.API/out .
ENTRYPOINT ["dotnet", "HelloWorld.API.dll"]
