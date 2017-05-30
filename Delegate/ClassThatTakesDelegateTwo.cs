using System;

namespace Delegate
{
    //this class doesn't know anything about the Foo class
    //it won't care if Foo goes away, never existed at all or what planet it was born on
    class ClassThatTakesDelegateTwo
    {
        //we can pass in a function to be run, this uses 'Func' which has both a return type and an arg list
        public void DoMagicalThings(Func<bool, int> aFunctionWeCanRun)
        {
            //based on the signature of the Func, we are passing a bool to the function and expecting an int to be returned
            int result = aFunctionWeCanRun(true);
        }
    }
}
