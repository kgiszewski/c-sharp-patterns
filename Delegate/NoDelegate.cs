using Delegate.Model;

namespace Delegate
{
    //this is a normal class that uses Foo to do something
    //there is nothing wrong with this code but you should know that this creates a tightly coupled dependency on Foo
    //this class knows about Foo. If Foo goes away, this class needs updated
    class NoDelegate
    {
        public void DoMagicalThings()
        {
            new Foo().DoSomething();
        }
    }
}
