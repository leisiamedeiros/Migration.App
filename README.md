# Migration.App

The main objective of this application is for you to be able to run your database migrations automatically using the endpoint `migrations\execute` and see wich migrations was applied using the `migrations` endpoint.

The [FluentMigrator](https://fluentmigrator.github.io/articles/quickstart.html#creating-your-first-migration) classes needs to be inside `\Migration.App.Infrastructure\Migrations\Deploys` folder, we have an example in this folder that runs against a scritp that is inside `\Migration.App.Infrastructure\Migrations\Scripts\` folder.

Bellow a preview of the main functionalities;

![previw](docs/migrationApp.gif)

Enjoy!
