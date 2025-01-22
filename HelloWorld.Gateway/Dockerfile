FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 7777

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "HelloWorld.Gateway/HelloWorld.Gateway.csproj"
RUN dotnet build "HelloWorld.Gateway/HelloWorld.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HelloWorld.Gateway/HelloWorld.Gateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HelloWorld.Gateway.dll"]
