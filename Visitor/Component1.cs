using System;

namespace Visitor
{
    public class Component1 : ISaySomething, IVisitable
    {
        public void SaySomething(string message)
        {
            Console.WriteLine($"Hello from {GetType().Name}, a visitor wants me to say: {message}!");
        }

        public void HandleVisitor(IVisitFoo visitor)
        {
            //this exposes the public methods of this class to the visitor
            visitor.Visit(this);
        }
    }
}
