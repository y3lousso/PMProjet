# Projet Portfolio

Le projet portfolio a pour but de mettre en avant le profil de chacun lors de la recherche d'emploi.
Grace � un espace administrateur, l'utilisateur va pouvoir ajouter facilement du contenu.

# Technologies utilis�es

H�bergement : Cloud Azure
Stockage des donn�es : SQL Server Database (Azure)
Gestion de la base de donn�es : Entity Framework (Code first)

Framework de d�veloppement : ASP.NET Core MVC 2.0

# Comment utiliser le projet.

Pour essayer : [http://portfoliotemplate.azurewebsites.net/] (http://portfoliotemplate.azurewebsites.net/).

Pour cr�er le votre :

T�l�charger le code source via master.
Sous Visual Studio 2017, connecter vous � une base de donn�es SQL Server. (N�cessite un compte Azure -> Payant)
Changer la "connectionString" dans le fichier" "appsettings.json" par celle disponible sur votre portail Azure.
Configurer la base de donn�es (Code First), depuis le gestionnaire de package, appliquer les commandes "AddMigration start" puis "Update-Database".
Publier l'application sur Azure.

Il ne vous reste plus qu'� compl�ter votre contenu !

