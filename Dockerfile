# Imagem para build
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

EXPOSE 80
EXPOSE 443

# Prevent 'Warning: apt-key output should not be parsed (stdout is not a terminal)'
ENV APT_KEY_DONT_WARN_ON_DANGEROUS_USAGE=1

# Intalando dependências do Frontend
RUN apt-get update -yq 
RUN apt-get install curl gnupg -yq 
RUN curl -sL https://deb.nodesource.com/setup_14.x | bash -
RUN apt-get install -y nodejs
RUN apt-get install -y build-essential
RUN npm install -g @angular/cli

# Copiar arquivos do projeto e restaurar dependências
COPY src/ ./
RUN dotnet restore --no-cache

# Build e Publicação da aplicação
RUN dotnet build SGM.Apresentacao/SGM.Apresentacao.csproj -c Release -o out
RUN dotnet publish SGM.Apresentacao/SGM.Apresentacao.csproj -c Release -o out --no-cache

#----------------------------------

# Imagem para deploy
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app

COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "SGM.Apresentacao.dll"]