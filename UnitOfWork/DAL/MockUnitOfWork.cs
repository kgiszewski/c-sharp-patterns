using PetaPoco;

namespace UnitOfWork.DAL
{
    //class does nothing with a DB and is used for testing
    public class MockUnitOfWork : IUnitOfWork
    {
        private MockUnitOfWork()
        {

        }

        private static IUnitOfWork _uow;
        public static IUnitOfWork Instance => _uow ?? (_uow = new MockUnitOfWork());

        public void Dispose()
        {

        }

        public void Commit()
        {

        }

        public IDatabase Database { get; }
    }
}
