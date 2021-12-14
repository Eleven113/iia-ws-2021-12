# DOTNET 6 SDK
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# Répertoire de travail => /app
WORKDIR /app

# Copie du fichier projet et restauration des dépendances (NuGet & packages dotnet)
COPY *.csproj ./
RUN dotnet restore

# Copie des autres fichiers, et build de l'application
COPY . .
RUN dotnet publish -c Release -o out

# DOTNET 6 ASPNET
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

# Copie des fichiers compilés vers le répertoire de travail
COPY --from=build-env /app/out .

# Exécuter l'application (laisse les ports 5000 & 5001 par défaut)
# CMD dotnet dotnet-server-rest.dll

# Exécuter l'application sur Heroku (Heroku nous donne un port à utiliser dans la variable $PORT)
CMD dotnet dotnet-server-rest.dll --urls=http://*:$PORT