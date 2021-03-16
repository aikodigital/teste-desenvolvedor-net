FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["TesteDesenvolvedor.API/TesteDesenvolvedor.API.csproj", "TesteDesenvolvedor.API/"]
COPY ["TesteDesenvolvedor.Services/TesteDesenvolvedor.Services.csproj", "TesteDesenvolvedor.Services/"]
COPY ["TesteDesenvolvedor.Domain/TesteDesenvolvedor.Domain.csproj", "TesteDesenvolvedor.Domain/"]
COPY ["TesteDesenvolvedor.Repository/TesteDesenvolvedor.Repository.csproj", "TesteDesenvolvedor.Repository/"]
RUN dotnet restore "TesteDesenvolvedor.API/TesteDesenvolvedor.API.csproj"
COPY . .
WORKDIR "/src/TesteDesenvolvedor.API"
RUN dotnet build "TesteDesenvolvedor.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TesteDesenvolvedor.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TesteDesenvolvedor.API.dll"]
