using System;

namespace DbVersionMigration.Migrations
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MigrationAttribute : Attribute
    {
        public int Version { get; set; }

        public MigrationAttribute(int version)
        {
            Version = version;
        }
    }
}
