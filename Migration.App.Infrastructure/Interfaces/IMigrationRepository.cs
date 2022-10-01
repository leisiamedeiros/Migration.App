namespace Migration.App.Infrastructure.Interfaces
{
    public interface IMigrationRepository
    {
        Task<string> GetMigrationsAsync();
    }
}
