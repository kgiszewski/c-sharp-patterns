namespace AbstractFactory
{
    //an interface (or abstract class) is used to allow us to not commit to a particular concrete class until we decided in our factory
    public interface IProduct
    {
        void MyMethod();
    }
}
