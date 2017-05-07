using System;

namespace Visitor
{
    //Bar's whole purpose in life is to gain a reference to an IFoo and a Component1
    //it can either do nothing with each or do something with each
    public class Bar : IVisitFoo
    {
        public void Visit(IFoo foo)
        {
            Console.WriteLine($"Let's visit the IFoo!, and make component 2 and 3 say something!");
            foo.Component2.SaySomething("Hi there!");
            foo.Component3.SaySomething("What's your name?");
        }

        public void Visit(Component1 component1)
        {
            Console.WriteLine($"Let's visit the Component1 and make it say something!");
            component1.SaySomething("Howdy!");
        }
    }
}
