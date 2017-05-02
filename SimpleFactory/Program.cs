namespace SimpleFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            //traditionally objects are created with the 'new' operator
            var foo = new Bar();

            //over time if you change the constructor, you'll have to hunt\peck all over to update the signature in many places

            //a simple factory simply is a method that return an instance of an object thus allowing one place to make any changes
            foo = Create();
        }

        static Bar Create()
        {
            return new Bar();
        }
    }
}
