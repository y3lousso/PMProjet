# Projet Portfolio

Le projet portfolio a pour but de mettre en avant le profil de chacun lors de la recherche d'emploi.
Grace à un espace administrateur, l'utilisateur va pouvoir ajouter facilement du contenu.

# Auteurs
  - **LOUSSOUARN Yannick**
  - **FAGET Thomas**

# Technologies utilisées

- Hébergement : Cloud Azure
- Stockage des données : SQL Server Database (Azure)
- Gestion de la base de données : Entity Framework (Code first)
- Framework de développement : ASP.NET Core MVC 2.0

# Comment utiliser le projet

1. Pour essayer cliquer [ici](http://portfoliotemplate.azurewebsites.net/).

2. Pour créer le votre :

  - Télécharger le code source via master.
  - Sous Visual Studio 2017, connecter vous à une base de données SQL Server. (Nécessite un compte Azure -> Payant)
  - Changer la "connectionString" dans le fichier" "appsettings.json" par celle disponible sur votre portail Azure.
  - Configurer la base de données (Code First), depuis le gestionnaire de package, appliquer les commandes "AddMigration start" puis "Update-Database".
  - Publier l'application sur Azure.

Il ne vous reste plus qu'à compléter votre contenu !

# Mode d'emploi

## Première connexion

Lors de votre première connexion dans l'espace admin, utilisez l'identifiant *admin* et le mot de passe *admin*. Vous devriez remplacer ce mot de passe par le votre.

Pour cela allez dans l'onglet *User* de l'espace admin et cliquer sur *Change* à coté de votre mot de passe.

Ensuite modifier vos informations personnelles en clickant sur *modify* dans *User*. Pensez aussi à verifier votre adresse mail, c'est celle qui est utilisé pour pouvoir récupérer votre mot de passe si vous l'avez perdu !

## Ajouter du contenu

Vous pouvez maintenant ajouter du contenu dans la section *Projets* ou *Education*, en cliquant sur *Add*.
Pour modifier un Projet ou une Education, cliquez sur *Modify* en face de l'item à modifier.
Enfin cliquez sur *delete* pour effacer un Projet ou une Education.

Vous pouvez aussi ajouter des images à chaque Projet, avec un nom et une description. Pour cela choisissez un projet (avec *Modify*) et aller dans l'onglet *Slide*.
Vous pouvez alors ajouter, modifier, ou supprimer une slide pour ce projet, comme précedemment.

