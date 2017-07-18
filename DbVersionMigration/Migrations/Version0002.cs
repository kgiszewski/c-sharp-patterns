namespace DbVersionMigration.Migrations
{
    //another simple migration
    [Migration(2)]
    public class Version0002 : IMigration
    { 
        public void Up()
        {
            //put your sql stuff here in a transaction
        }

        public void Down()
        {
            //put your sql stuff here in a transaction
        }
    }
}