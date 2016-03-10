using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MySingleton.Instance.PropertyOne); //hello world

            Console.WriteLine(MySingleton.Instance.PropertyOne); //hello world

            MySingleton.Instance.Clear(); //will require a re-initialization on the next usage

            Console.WriteLine(MySingleton.Instance.PropertyOne); //hello world
        }
    }
}
