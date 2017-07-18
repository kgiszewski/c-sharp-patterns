namespace DbVersionMigration.Migrations
{
    //another simple migration
    [Migration(3)]
    public class Version0003 : IMigration
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