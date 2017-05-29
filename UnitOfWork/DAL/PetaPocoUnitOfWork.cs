using System;
using PetaPoco;

namespace DAL
{
    //NOTE: this class is a wrapper for PetaPoco transactions
    public class PetaPocoUnitOfWork : IDisposable
    {
        private readonly Transaction _petaTransaction;
        private readonly Database _database;
        public static string ConnectionString = "foo";

        public PetaPocoUnitOfWork(string connectionString = "")
        {
            if (!string.IsNullOrEmpty(connectionString))
            {
                _database = new Database(connectionString);
            }
            else
            {
                _database = new Database(ConnectionString);
            }

            _petaTransaction = new Transaction(_database);
        }

        public void Dispose()
        {
            _petaTransaction.Dispose();
        }

        public Database Database
        {
            get { return _database; }
        }

        public void Commit()
        {
            _petaTransaction.Complete();
        }
    }
}