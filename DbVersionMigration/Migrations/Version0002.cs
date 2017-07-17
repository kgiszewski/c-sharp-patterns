using System;

namespace DbVersionMigration.Migrations
{
    //another simple migration
    public class Version0002 : IMigration
    {
        public int DbVersion => 2;

        public void Up()
        {
            //put your sql stuff here in a transaction
            Console.WriteLine($"Upgrading to v{DbVersion}!");
        }

        public void Down()
        {
            //put your sql stuff here in a transaction
            Console.WriteLine($"Downgrading to v{DbVersion}!");
        }
    }
}