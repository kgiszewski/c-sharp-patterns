using System;

namespace Visitor
{
    public class Component3 : ISaySomething
    {
        public void SaySomething(string message)
        {
            Console.WriteLine($"Hello from {GetType().Name}, a visitor wants me to say: {message}!");
        }
    }
}
