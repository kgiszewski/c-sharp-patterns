using System;
using Delegate.Model;

namespace Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            //nothing special here
            var noDelegate = new NoDelegate();
            noDelegate.DoMagicalThings();

            //pass in a function that has one arg and no return type (void)
            var delegateOne = new ClassThatTakesDelegateOne();
            delegateOne.DoMagicalThings(aFunctionWeCanRunFromDelegateOne);

            //you can also tighten it up with a lambda to do it inline
            delegateOne.DoMagicalThings(someBool =>
            {
                //this is a delegate function inline
                if (someBool)
                {
                    //only the Program class has to know about Foo
                    new Foo().DoSomething();
                }
            });

            //what if you want to pass an arg and get a return type?
            var delegateTwo = new ClassThatTakesDelegateTwo();
            delegateTwo.DoMagicalThings(aFunctionWeCanRunFromDelegateTwo);

            //just like Action, we can use a lambda as well
            delegateTwo.DoMagicalThings(someBool =>
            {
                //this is a delegate function inline
                if (someBool)
                {
                    //only the Program class has to know about Foo
                    new Foo().DoSomething();

                    return 1;
                }

                return 0;
            });

            //finally we have the original delegate from early C# that works just like delegate one or two based on the delegate at the top
            //of the ClassThatTakesDelegateThree
            var delegateThree = new ClassThatTakesDelegateThree();
            delegateThree.DoMagicalThings(aFunctionWeCanRunFromDelegateTwo);
        }

        //this is a delegate function
        private static int aFunctionWeCanRunFromDelegateTwo(bool someBool)
        {
            if (someBool)
            {
                //only the Program class has to know about Foo
                new Foo().DoSomething();

                return 1;
            }

            return 0;
        }

        //this is a delegate function
        private static void aFunctionWeCanRunFromDelegateOne(bool someBool)
        {
            if (someBool)
            {
                //only the Program class has to know about Foo
                new Foo().DoSomething();
            }
        }
    }
}
