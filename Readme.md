Angular Csharp Docker Project
========================

L'application "Angular Csharp Docker Project" est une application servant de à s'exercer sur les technologies citées dans le titre de l'application (Gestion de produit, de type de produit et d'utilisateur)

Récupération (GIT)
------------

```bash
$ git clone https://github.com/osscoco/AngularCsharpDocker.git
```

Ajouter de la connectionString -> "./Csharp/ManagePassProtectIIA.API/appsettings.json" :
------------

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;User id=root;Password=123456;Database=appdb;Persistsecurityinfo=True"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

Créer à la main la base de données "appdb" dans PhpMyAdmin
------------

Executer les commandes suivantes en ce placant dans un terminal :
------------

```bash
$ cd ./Csharp/ManagePassProtectIIA.Persistance
```
```bash
$ dotnet tool install --global dotnet-ef
```
```bash
$ dotnet ef migrations add InitCreateTables
```
```bash
$ dotnet ef database update
```
```bash
$ cd ./Csharp/ManagePassProtectIIA.API
```
```bash
$ dotnet run
```

Tester L'API (Swagger) sur la route : http://localhost:5159/swagger/index.html
------------

Manipuler la base de données sur PhpMyAdmin (après avoir effectué docker compose up à la racine du projet) : http://localhost:8080
------------