using System;

namespace DbVersionMigration
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * The idea here is to only modify the DB via a migration. 
             * 
             * In this way you can easily keep track of what state a DB schema should be in.
             * 
             * You can also run this against the dev, prod, staging DB's to ensure they are all a particular version.
             */

            //you'll want to store the 'current DB version' somewhere
            //this could be the web config, or a DB table
            var currentDbVersion = 0;

            //we'll use our manager to do the dirty work
            //you can run this on startup or you can run this explicitly
            var migrationManager = new MigrationManager();

            //simply use integers for versioning
            //here we're going from v0 to v1
            migrationManager.HandleMigrations(currentDbVersion, 1);
            currentDbVersion = 1;

            //here we go from v1 to v2
            migrationManager.HandleMigrations(currentDbVersion, 2);
            currentDbVersion = 2;

            //let's go back to v1
            //be careful if you choose to allow for downgrades as you could drop a table
            //you might just want to 'go forward' with upgrades only
            //maybe leave table drops as a manual process
            migrationManager.HandleMigrations(currentDbVersion, 1);
            currentDbVersion = 1;

            //let's go all the way up
            migrationManager.HandleMigrations(currentDbVersion, 3);
            currentDbVersion = 3;

            //all the way down
            migrationManager.HandleMigrations(currentDbVersion, 0);
            currentDbVersion = 0;


            Console.ReadKey();
        }
    }
}
