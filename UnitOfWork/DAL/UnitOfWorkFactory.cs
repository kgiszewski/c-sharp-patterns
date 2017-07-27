namespace UnitOfWork.DAL
{
    public class UnitOfWorkFactory
    {
        //having this setter her allows the unit tests to get a mocked uow if it wants or a DB bound one for integration\normal ops
        public static UnitOfWorkType UnitOfWorkType { get; set; } = UnitOfWorkType.Database;
        public static IUnitOfWork Get(string connectionString = "")
        {
            if (UnitOfWorkType == UnitOfWorkType.Mock)
            {
                //using a singleton here so that the mocking fw is happy that we've got the same instance
                return MockUnitOfWork.Instance;
            }

            return new PetaPocoUnitOfWork(connectionString);
        }
    }

    public enum UnitOfWorkType
    {
        Database = 1,
        Mock
    }
}
