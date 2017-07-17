using System;

namespace DbVersionMigration.Migrations
{
    //a simple migration
    public class Version0001 : IMigration
    {
        //we need to id the version
        //in a team env you might run a unit test to ensure these are unique (i.e. not have two version 1 migrations)
        public int DbVersion => 1;

        //run you custom sql here in a transaction
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