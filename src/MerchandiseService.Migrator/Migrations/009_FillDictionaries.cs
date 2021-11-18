using FluentMigrator;

namespace MerchandiseService.Migrator.Migrations
{
    [Migration(4)]
    public class FillDictionaries:ForwardOnlyMigration
    {
        public override void Up()
        {
            Execute.Sql(@"
                INSERT INTO merch_pack_type (id, name)
                VALUES 
                    (1, 'WelcomePack'),
                    (2, 'StarterPack'),
                    (3, 'ConferenceListenerPack'),
                    (4, 'ConferenceSpeakerPack'),
                    (5, 'VeteranPack')
                ON CONFLICT DO NOTHING
            ");
            
            Execute.Sql(@"
                INSERT INTO status (id, name)
                VALUES 
                    (1, 'Cancelled'),
                    (2, 'InProgress'),
                    (3, 'Successed')                    
                ON CONFLICT DO NOTHING
            ");
        }
    }
}