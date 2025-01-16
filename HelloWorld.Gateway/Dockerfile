# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copia a solução e os arquivos do projeto
COPY HelloWorld.API.sln ./
COPY HelloWorld.Gateway/HelloWorld.Gateway.csproj HelloWorld.Gateway/
RUN dotnet restore

# Copia o restante dos arquivos do projeto
COPY HelloWorld.Gateway/ ./HelloWorld.Gateway/
WORKDIR /app/HelloWorld.Gateway
RUN dotnet publish -c Release -o out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/HelloWorld.Gateway/out .
ENTRYPOINT ["dotnet", "HelloWorld.Gateway.dll"]