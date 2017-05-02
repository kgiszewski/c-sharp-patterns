namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            //if a model is public, we could just 'new' a product
            ProductOne myNewProduct = new ProductOne();
            myNewProduct.MyMethod();

            //but if we need to use a new product model (ProductTwo), we'll have to change all instances where 'ProductOne' is used.
            //This may not be a problem if you control all of the code, but what if your code is used by a third-party?
            //If that happens, you'd have to ask them to replace all references to 'ProductOne' and substitute 'ProductTwo' in their application and then recompile.
            //This is not ideal, we'd really like our client to not have to do anything with their code.

            //If you use an interface and a factory, your client wouldn't have to change any of their code because the client delegates the creation of
            //the product to the factory. Therefore as long as the factory returns an 'IProduct', the fact that it's returning 'ProductTwo' or 'ProductThree' matters not to
            //the client application.

            //this returns ProductTwo but could just as well return ProductThree and no changes would be needed to the code below.
            IProduct myFactoryProduct = MyAbstractFactory.Create();
            myFactoryProduct.MyMethod();

            //we can make this even sexier if we want some sort of condition to dictate what the factory should return
        }
    }
}
