using FluentMigrator;

namespace Migration.App.Infrastructure.Migrations.Deploys
{
    [Migration(20220430121800)]
    public class AddTesteTable : FluentMigrator.Migration
    {
        public override void Down()
        { }

        public override void Up()
        {
            Create.Table("Teste")
                 .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                 .WithColumn("Text").AsString();
        }
    }
}
