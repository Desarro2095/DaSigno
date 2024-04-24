# Commands

# Create Image
# docker build -f path dockerfile -t nameImage:nameVersion

# Create Container V.1
# docker run -it --rm -d -p 5000:5000 -p 5001:5001 -e ASPNETCORE_HTTP_PORT=https://+:5001 -e ASPNETCORE_URLS=http://+:5000 --name nameContainer nameImage:nameVersion

# Create Container V.2(Swagger)
# docker run -it --rm -d -p 5000:5000 -p 5001:5001 -e ASPNETCORE_ENVIRONMENT=Development -e ASPNETCORE_HTTP_PORT=https://+:5001 -e ASPNETCORE_URLS=http://+:5000 --name nameContainer nameImage:nameVersion


#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5002
EXPOSE 5003

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DaSigno/DaSigno.csproj", "DaSigno/"]
COPY ["DaSigno.BM/DaSigno.BM.csproj", "DaSigno.BM/"]
COPY ["DaSigno.DA/DaSigno.DA.csproj", "DaSigno.DA/"]
COPY ["DaSigno.DT/DaSigno.DT.csproj", "DaSigno.DT/"]
COPY ["DaSigno.SP/DaSigno.SP.csproj", "DaSigno.SP/"]
RUN dotnet restore "./DaSigno/DaSigno.csproj"
COPY . .
WORKDIR "/src/DaSigno"
RUN dotnet build "./DaSigno.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DaSigno.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DaSigno.dll"]