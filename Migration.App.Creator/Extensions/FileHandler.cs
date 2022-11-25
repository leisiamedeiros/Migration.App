using System.Reflection;
using System.Text.RegularExpressions;

namespace Migration.App.Creator.Extensions
{
    public static class FileHandler
    {
        private static readonly string ApplicationDirectory = Directory.GetParent(Environment.CurrentDirectory).FullName;
        private static readonly string Version = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
        private static readonly string DestinationApplicationName = Environment.CurrentDirectory.Replace(ApplicationDirectory, "").Replace(@"/", "").Replace(@"\", "");

        public static void CreateMigrationClassFile(string fileName)
        {
            try
            {
                fileName = RemoveSpecialCharacters(fileName);

                var migrationPath = Path.Combine(ApplicationDirectory, DestinationApplicationName, "Migrations", "Deploys");
                Console.WriteLine($"Creating file...");

                if (!Directory.Exists(migrationPath))
                {
                    Directory.CreateDirectory(migrationPath);
                }

                var filePath = Path.Combine(migrationPath, $"{Version}_{fileName}.cs");
                var content = GetTemplateContent(fileName);

                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, content);
                    Console.WriteLine($"File was created in: {filePath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static string GetTemplateContent(string fileName)
        {
            var content = ReadFromResource("Migration.App.Creator.Templates.MigrationClass");
            content = content
                .Replace("$version", Version)
                .Replace("$className", fileName)
            ;

            return content;
        }

        private static string ReadFromResource(string resourceName)
        {
            var thisAssembly = Assembly.GetExecutingAssembly();
            using var stream = thisAssembly.GetManifestResourceStream(resourceName);
            using var reader = new StreamReader(stream);

            return reader.ReadToEnd();
        }

        private static string RemoveSpecialCharacters(string name)
        {
            var pattern = @"[^0-9a-zA-Z]+";
            return Regex.Replace(name, pattern, "");
        }
    }
}
