#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Compugraf.Api/Compugraf.Api.csproj", "src/Compugraf.Api/"]
COPY ["Compugraf.Dominio/Compugraf.Dominio.csproj", "src/Compugraf.Dominio/"]
COPY ["Compugraf.Dados/Compugraf.Dados.csproj", "src/Compugraf.Dados/"]
COPY ["Compugraf.IoC/Compugraf.IoC.csproj", "src/Compugraf.IoC/"]
RUN dotnet restore "src/Compugraf.Api/Compugraf.Api.csproj"
COPY . .
WORKDIR "/src/Compugraf.Api"
RUN dotnet build "Compugraf.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Compugraf.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Compugraf.Api.dll"]