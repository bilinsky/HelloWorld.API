# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copia a solução e os arquivos do projeto
COPY HelloWorld.API.sln ./
COPY HelloWorld.API/HelloWorld.API.csproj HelloWorld.API/
RUN dotnet restore

# Copia o restante dos arquivos do projeto
COPY HelloWorld.API/ ./HelloWorld.API/
WORKDIR /app/HelloWorld.API
RUN dotnet publish -c Release -o out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/HelloWorld.API/out .
ENTRYPOINT ["dotnet", "HelloWorld.API.dll"]