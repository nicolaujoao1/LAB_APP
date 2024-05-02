#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
# Define a imagem base
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8085

# Define a imagem para build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copia o arquivo de projeto e restaura dependências
COPY ["LAB_APP.API/LAB_APP.API.csproj", "LAB_APP.API/"]
COPY ["LAB_APP.Application/LAB_APP.Application.csproj", "LAB_APP.Application/"]
COPY ["LAB_APP.Data/LAB_APP.Data.csproj", "LAB_APP.Data/"]
COPY ["LAB_APP.Domain/LAB_APP.Domain.csproj", "LAB_APP.Domain/"]
COPY ["LAB_APP.IoC/LAB_APP.IoC.csproj", "LAB_APP.IoC/"]
RUN dotnet restore "LAB_APP.API/LAB_APP.API.csproj"

# Copia todo o código e constrói a aplicação
COPY . .
WORKDIR "/src/LAB_APP.API"
RUN dotnet build "LAB_APP.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LAB_APP.API.csproj" -c Release -o /app/publish

# Define a imagem final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LAB_APP.API.dll"]
