
using Migration.App.Creator.Extensions;

var fileName = args.Length > 0 ? args[0] : null;

if (string.IsNullOrWhiteSpace(fileName))
{
    Console.WriteLine("\nPlease, provide the file name");
    Console.WriteLine("\nUsage:");
    Console.WriteLine("mcreator MigrationFileName\n");
    return;
}

FileHandler.CreateMigrationClassFile(fileName);