namespace DbVersionMigration
{
    //define what each migration should do
    //you may want to do upgrades only
    public interface IMigration
    {
        void Up();
        void Down();
    }
}
