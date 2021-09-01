FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine3.11 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine3.11 AS build
WORKDIR /src
COPY ["take.Facades/take.Facades.csproj", "take.Facades/"]
COPY ["take.Models/take.Models.csproj", "take.Models/"]
COPY ["take.Services/take.Services.csproj", "take.Services/"]
COPY ["take/take.csproj", "take/"]

RUN dotnet restore "take/take.csproj"
COPY . .
WORKDIR "/src/take"
RUN dotnet build "take.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "take.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "take.dll"]