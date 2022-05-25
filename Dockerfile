FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Validador.API/Validador.API.csproj", "Validador.API/"]
RUN dotnet restore "Validador.API/Validador.API.csproj"
COPY . .
WORKDIR "/src/Validador.API"
RUN dotnet build "Validador.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Validador.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet Validador.API.dll