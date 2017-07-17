namespace DbVersionMigration
{
    public interface IMigrationManager
    {
        //just a single method
        void HandleMigrations(int currentDbVersion, int targetVersion);
    }
}
