namespace Factory
{
    public class MyFactory
    {
        //a factory only needs one method
        public static IProduct Create()
        {
            //as long as it returns an 'IProduct', the client application doesn't care which concrete class is returned.
            return new ProductTwo();
        }
    }
}
