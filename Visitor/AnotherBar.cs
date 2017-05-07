using System;

namespace Visitor
{
    public class AnotherBar : IVisitFoo
    {
        public void Visit(IFoo foo)
        {
            //I can't do anything with component 1 here, but 2 and 3 are public so I could use those
            Console.WriteLine("I'm visiting foo and could do something with it if I chose to.");
        }

        public void Visit(Component1 component1)
        {
            //this is a way to control access to a private var if I wanted to
            Console.WriteLine("I'm visiting component1 and could do something with it if I chose to.");
        }
    }
}
