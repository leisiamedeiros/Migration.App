# Migration.App

The main objective of this application is for you to be able to run your database migrations automatically 
using the endpoint `api/migrations/execute` and see wich migrations was applied using the `api/migrations` endpoint.

![image](https://user-images.githubusercontent.com/10652534/206548270-769cfe5c-ed1d-46d2-9686-ebbde31c4b93.png)

## Start using
Clone this project, and create your migration classes inside the Migration.App.Infrastructure project. 

You can use the [MCreator.Tool](https://www.nuget.org/packages/MCreator.Tool) to create the migration class files. You can see the source code
for this project here [Migration.App.Creator](https://github.com/leisiamedeiros/Migration.App.Creator)

```bash
dotnet tool install --global MCreator.Tool --version 1.0.0
```

The [FluentMigrator](https://fluentmigrator.github.io/articles/quickstart.html#creating-your-first-migration) classes needs to be 
inside `\Migration.App.Infrastructure\Migrations\Deploys` folder, we have an example in this folder that runs against a scritp that is inside `\Migration.App.Infrastructure\Migrations\Scripts\` folder.

Bellow a preview of the main functionalities;

![previw](docs/migrationApp.gif)

Enjoy!
