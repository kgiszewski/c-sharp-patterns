using System;

namespace Delegate
{
    //this class doesn't know anything about the Foo class
    //it won't care if Foo goes away, never existed at all or what planet it was born on
    class ClassThatTakesDelegateOne
    {
        //we can pass in a function to be run, this uses 'Action' which has no return type and no args
        public void DoMagicalThings(Action aFunctionWeCanRun)
        {
            aFunctionWeCanRun();
        }

        //we can pass in a function to be run, this uses 'Action' which has no return type but takes an arg (bool in this case)
        //you can have more than one passed in arg
        public void DoMagicalThings(Action<bool> aFunctionWeCanRun)
        {
            aFunctionWeCanRun(true);
        }
    }
}
