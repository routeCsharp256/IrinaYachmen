using FluentMigrator;

namespace MerchandiseService.Migrator.Migrations
{
    [Migration(2)]
    public class MerchPackType: Migration {
        public override void Up()
        {
            Create
                .Table("merch_pack_type")
                .WithColumn("id").AsInt32().PrimaryKey()
                .WithColumn("name").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("merch_pack_type");
        }
    }
}