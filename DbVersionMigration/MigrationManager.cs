using System;
using System.Collections.Generic;
using System.Linq;

namespace DbVersionMigration
{
    public class MigrationManager : IMigrationManager
    {
        public void HandleMigrations(int currentDbVersion, int targetVersion)
        {
            //if we don't need to upgrade, let's get out of here
            if (currentDbVersion == targetVersion)
            {   
                return;
            }
            
            //grab all of the migrations via reflection
            var migrationType = typeof(IMigration);
            var migrations = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => migrationType.IsAssignableFrom(p) && !p.IsInterface)
                .Select(t => (IMigration)Activator.CreateInstance(t));

            try
            {
                //decide if we're upgrading or downgrading
                if (currentDbVersion > targetVersion)
                {
                    _downgrade(migrations, currentDbVersion, targetVersion);
                }
                else
                {
                    _upgrade(migrations, currentDbVersion, targetVersion);
                }
            }
            catch (Exception ex)
            {
                //log it
            }
        }

        private void _upgrade(IEnumerable<IMigration> migrations, int currentDbVersion, int targetVersion)
        {
            //only run the migrations from a version forward
            var migrationsToExecute = migrations
                .Where(x => x.DbVersion > currentDbVersion && x.DbVersion <= targetVersion)
                .OrderBy(x => x.DbVersion);

            foreach (var migration in migrationsToExecute)
            {
                migration.Up();
            }
        }

        private void _downgrade(IEnumerable<IMigration> migrations, int currentDbVersion, int targetVersion)
        {
            //only run the migrations for a version backwards
            var migrationsToExecute = migrations
                .Where(x => x.DbVersion < currentDbVersion && x.DbVersion >= targetVersion)
                .OrderByDescending(x => x.DbVersion);

            foreach (var migration in migrationsToExecute)
            {
                migration.Down();
            }
        }
    }
}
