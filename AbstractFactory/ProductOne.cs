using System;

namespace AbstractFactory
{
    //a generic model that implements IProduct
    public class ProductOne : IProduct
    {
        public void MyMethod()
        {
            Console.WriteLine("Invoking method from product 1!");
        }
    }
}
