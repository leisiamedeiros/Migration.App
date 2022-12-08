# Migration.App

The main objective of this application is for you to be able to run your database migrations automatically 
using the endpoint `api/migrations/execute` and see wich migrations was applied using the `api/migrations` endpoint.

![image](https://user-images.githubusercontent.com/10652534/206548270-769cfe5c-ed1d-46d2-9686-ebbde31c4b93.png)

## Start using
Clone this project, and create your migration classes inside the Migration.App.Infrastructure project. 

The [FluentMigrator](https://fluentmigrator.github.io/articles/quickstart.html#creating-your-first-migration) classes needs to be 
inside `\Migration.App.Infrastructure\Migrations\Deploys` folder, we have an example in this folder that runs against a scritp that is inside `\Migration.App.Infrastructure\Migrations\Scripts\` folder.

Bellow a preview of the main functionalities;

![previw](docs/migrationApp.gif)

Enjoy!
