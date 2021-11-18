using FluentMigrator;

namespace MerchandiseService.Migrator.Migrations
{
    [Migration(3)]
    public class RequestMerch: Migration {
        public override void Up()
        {
            Create
                .Table("request_merch")
                .WithColumn("id").AsInt32().PrimaryKey()
                .WithColumn("merch_pack_type").AsInt32().NotNullable()
                .WithColumn("status_id").AsInt32().NotNullable()
                .WithColumn("employee_id").AsInt32().NotNullable()
                .WithColumn("quantity").AsInt32()
                .WithColumn("request_date_time").AsDateTime();
        }

        public override void Down()
        {
            Delete.Table("request_merch");
        }
    }
}