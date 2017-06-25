using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            //many times we should use a thread safe implementation
            Console.WriteLine(ThreadSafeSingleton.Instance.PropertyOne); //hello world

            Console.WriteLine(ThreadSafeSingleton.Instance.PropertyOne); //hello world

            ThreadSafeSingleton.Instance.Clear(); //will require a re-initialization on the next usage

            Console.WriteLine(ThreadSafeSingleton.Instance.PropertyOne); //hello world

            //we can also use a non-thread safe singleton if you need to but you'll wanna understand when this is ok
            NonThreadSafeSingleton.Instance.PropertyOne = "Foo";

            Console.WriteLine(NonThreadSafeSingleton.Instance.PropertyOne);

            Console.ReadKey();
        }
    }
}
