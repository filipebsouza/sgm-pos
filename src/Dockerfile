FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Prevent 'Warning: apt-key output should not be parsed (stdout is not a terminal)'
ENV APT_KEY_DONT_WARN_ON_DANGEROUS_USAGE=1

# Copiar arquivos do Frontend
ADD src/Frontend/ ./Frontend

# Intalando dependências do Frontend
RUN apt-get update -yq 
RUN apt-get install curl gnupg -yq 
RUN curl -sL https://deb.nodesource.com/setup_14.x | bash -
RUN apt-get install -y nodejs
RUN apt-get install -y build-essential
RUN npm install -g @angular/cli

# Copiar arquivos do Backend e restaurar dependências
ADD src/Backend/ ./Backend
COPY src/SGM.sln ./
RUN dotnet restore

# Build e Publicação da aplicação
RUN dotnet build Backend/SGM.WebApi/SGM.WebApi.csproj -c Release -o out
RUN dotnet publish Backend/SGM.WebApi/SGM.WebApi.csproj -c Release -o out

# Build da imagem
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "SGM.WebApi.dll"]