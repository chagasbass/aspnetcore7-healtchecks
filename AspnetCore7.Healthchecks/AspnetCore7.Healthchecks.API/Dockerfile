#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AspnetCore7.Healthchecks.API/AspnetCore7.Healthchecks.API.csproj", "AspnetCore7.Healthchecks.API/"]
RUN dotnet restore "AspnetCore7.Healthchecks.API/AspnetCore7.Healthchecks.API.csproj"
COPY . .
WORKDIR "/src/AspnetCore7.Healthchecks.API"
RUN dotnet build "AspnetCore7.Healthchecks.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AspnetCore7.Healthchecks.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AspnetCore7.Healthchecks.API.dll"]