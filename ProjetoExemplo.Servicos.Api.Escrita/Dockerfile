#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ProjetoExemplo.Servicos.Api/ProjetoExemplo.Servicos.Api.csproj", "ProjetoExemplo.Servicos.Api/"]
RUN dotnet restore "ProjetoExemplo.Servicos.Api/ProjetoExemplo.Servicos.Api.csproj"
COPY . .
WORKDIR "/src/ProjetoExemplo.Servicos.Api"
RUN dotnet build "ProjetoExemplo.Servicos.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjetoExemplo.Servicos.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjetoExemplo.Servicos.Api.dll"]