using FluentMigrator;

namespace MerchandiseService.Migrator.Migrations
{
    [Migration(1)]
    public class Status : Migration
    {
        public override void Up()
        {
            Create
                .Table("status")
                .WithColumn("id").AsInt32().PrimaryKey()
                .WithColumn("name").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("clothing_sizes");
        }
    }
}