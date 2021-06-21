FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env

WORKDIR /app

#Exibir a versão do .NET
RUN dotnet --version

# Copiar csproj e restaurar dependencias
ADD src/Backend/ ./Backend
ADD src/Frontend/ ./Frontend
COPY src/SGM.sln ./
RUN dotnet restore

# Build da aplicacao
RUN dotnet publish Backend/SGM.WebApi/SGM.WebApi.csproj -c Release -o out

# Build da imagem
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "SGM.WebApi.dll"]