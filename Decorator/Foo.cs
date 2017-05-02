using System;

namespace Decorator
{
    //imagine this class contains highly secretive source code and is closed from prying eyes!
    class Foo : IDoSomething
    {
        public string DoSomething()
        {
            return "I just did something!";
        }
    }
}
