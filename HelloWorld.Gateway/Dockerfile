# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar o arquivo de projeto diretamente
COPY HelloWorld.Gateway/HelloWorld.Gateway.fsproj ./HelloWorld.Gateway/

# Restaurar dependências
RUN dotnet restore ./HelloWorld.Gateway/HelloWorld.Gateway.fsproj

# Copiar o restante dos arquivos do projeto
COPY HelloWorld.Gateway/ ./HelloWorld.Gateway/

# Publicar o projeto Gateway
WORKDIR /app/HelloWorld.Gateway
RUN dotnet publish -c Release -o out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/HelloWorld.Gateway/out .
ENTRYPOINT ["dotnet", "HelloWorld.Gateway.dll"]
