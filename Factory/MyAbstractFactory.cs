using System.Configuration;

namespace AbstractFactory
{
    public class MyAbstractFactory
    {
        //an abstract factory only needs one method that returns an abstraction
        public static IProduct Create()
        {
            //as long as it returns an 'IProduct', the client application doesn't care which concrete class is returned.
            return new ProductTwo();
        }

        //however to make it more useful, a creation method could react to a condition
        public static IProduct CreateBasedOnConfig()
        {
            var setting = ConfigurationManager.AppSettings["ProductType"];

            switch(setting)
            {
                case "1":
                    return new ProductOne();

                case "2":
                    return new ProductTwo();

                case "3":
                    return new ProductThree();

                default:
                    return new ProductTwo();
            }
        }
    }
}
