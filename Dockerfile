FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FHS.Api/FHS.Api.csproj", "FHS.Api/"]
COPY ["FHS.Data/FHS.Data.csproj", "FHS.Data/"]
COPY ["FHS.Domain/FHS.Domain.csproj", "FHS.Domain/"]
COPY ["FHS.Interfaces/FHS.Interfaces.csproj", "FHS.Interfaces/"]
COPY ["FHS.Mapper/FHS.Mapper.csproj", "FHS.Mapper/"]
COPY ["FHS.Resources/FHS.Resources.csproj", "FHS.Resources/"]
COPY ["FHS.Services/FHS.Services.csproj", "FHS.Services/"]
COPY ["FHS.Utilities/FHS.Utilities.csproj", "FHS.Utilities/"]
RUN dotnet restore "FHS.Api/FHS.Api.csproj"

COPY . .

WORKDIR "/src/FHS.Api"
RUN dotnet build "FHS.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish 
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "FHS.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app 
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "FHS.Api.dll" ]