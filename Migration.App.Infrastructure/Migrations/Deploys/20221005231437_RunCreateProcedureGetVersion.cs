using FluentMigrator;

namespace Migration.App.Infrastructure.Migrations.Deploys
{
    [Migration(20221005231437)]
    public class V20221005231437_RunCreateProcedureGetVersion : FluentMigrator.Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("usp_get_migrations_version.sql");
        }

        public override void Down()
        { }
    }
}