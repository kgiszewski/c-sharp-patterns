using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            //the decorator pattern is used to augment an existing implementation without creating overriding behavior in the traditional sense

            //if we have class foo we might use it simply like so:
            var foo = new Foo();

            foo.DoSomething();

            //however eventually we may want to add caching to this class method
            //we could update the class to support it directly, but what happens if we DON'T have the code access?
            //we could use the decorator pattern to simply augment it
            //for this part, assume that class Foo is in another assembly and locked away as closed source

            //this is most elegant when the class you want to augment implements an interface. In our case Foo impl IDoSomething.
            //using this pattern with an abstraction allows your new class to work like the old class with augmentation

            var cachedFoo = new CachedFoo(foo);
            Console.WriteLine(cachedFoo.DoSomething()); //will invoke the inner IDoSomething (Foo class)
            Console.WriteLine(cachedFoo.DoSomething()); //this will output the cached value the second time
        }
    }
}
