namespace Migration.App.Creator.Extensions
{
    public static class FileHandler
    {
        private static readonly string ApplicationDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
        private static readonly string Version = DateTime.UtcNow.ToString("yyyyMMddHHmmss");

        public static void CreateMigrationClassFile(string fileName)
        {
            var migrationPath = Path.Combine(ApplicationDirectory, "Migration.App.Infrastructure", "Migrations", "Deploys");

            if (!Directory.Exists(migrationPath))
            {
                Directory.CreateDirectory(migrationPath);
            }

            var filePath = Path.Combine(migrationPath, $"{Version}_{fileName.Replace(" ", "")}.cs");
            var content = GetTemplateContent(fileName);

            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, content);
            }
        }

        private static string GetTemplateContent(string fileName)
        {
            var templatePath = Path.Combine(ApplicationDirectory, "Migration.App.Creator", "Templates", "MigrationClass.txt");

            var content = File.ReadAllText(templatePath);
            content = content
                .Replace("$version", Version)
                .Replace("$className", fileName)
            ;

            return content;
        }
    }
}
