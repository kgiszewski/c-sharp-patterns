using System;
using System.Collections.Generic;
using System.Linq;
using DbVersionMigration.Migrations;

namespace DbVersionMigration
{
    public class MigrationManager : IMigrationManager
    {
        private readonly Dictionary<string, int> _migrationLookup = new Dictionary<string, int>();

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
                .ToList();
            //.Select(t => (IMigration)Activator.CreateInstance(t));

            _migrationLookup.Clear();
            _initLookup(migrations);

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

        private void _upgrade(IEnumerable<Type> migrations, int currentDbVersion, int targetVersion)
        {
            //only run the migrations from a version forward
            var migrationsToExecute = migrations
                .Where(x => _migrationLookup[x.Name] > currentDbVersion && _migrationLookup[x.Name] <= targetVersion)
                .OrderBy(x => _migrationLookup[x.Name]);

            foreach (var migration in migrationsToExecute)
            {
                var migrationInstance = (IMigration)Activator.CreateInstance(migration);

                Console.WriteLine($"Upgrading to v{_migrationLookup[migration.Name]}...");

                migrationInstance.Up();
            }
        }

        private void _downgrade(IEnumerable<Type> migrations, int currentDbVersion, int targetVersion)
        {
            //only run the migrations for a version backwards
            var migrationsToExecute = migrations
                .Where(x => _migrationLookup[x.Name] < currentDbVersion && _migrationLookup[x.Name] >= targetVersion)
                .OrderByDescending(x => _migrationLookup[x.Name]);

            foreach (var migration in migrationsToExecute)
            {
                var migrationInstance = (IMigration)Activator.CreateInstance(migration);

                Console.WriteLine($"Downgrading to v{_migrationLookup[migration.Name]}...");

                migrationInstance.Down();
            }
        }

        private void _initLookup(IEnumerable<Type> types)
        {
            foreach (var type in types)
            {
                if (_migrationLookup.ContainsKey(type.Name))
                {
                    throw new Exception($"Looks like you have multiple types with the same name {type.Name}!");
                }

                var version = _getMigrationVersion(type);

                if (version == null)
                {
                    throw new Exception($"Looks like you have multiple types with the same name {type.FullName}!");
                }

                if (_migrationLookup.ContainsValue(version.Value))
                {
                    throw new Exception($"Looks like you have multiple types with the same version: {version}!");
                }

                _migrationLookup.Add(type.Name, version.Value);
            }
        }

        private int? _getMigrationVersion(Type type)
        {
            int? version = null;

            var attributes = type.GetCustomAttributes(false);

            foreach (var attribute in attributes)
            {
                var migrationAttribute = attribute as MigrationAttribute;

                if (migrationAttribute != null)
                {
                    version = migrationAttribute.Version;
                }
            }

            return version;
        }
    }
}
