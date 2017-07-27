using PetaPoco;

namespace UnitOfWork.DAL
{
    //NOTE: this class is a wrapper for PetaPoco transactions
    public class PetaPocoUnitOfWork : IUnitOfWork
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

        public IDatabase Database => _database;

        public void Commit()
        {
            _petaTransaction.Complete();
        }
    }
}