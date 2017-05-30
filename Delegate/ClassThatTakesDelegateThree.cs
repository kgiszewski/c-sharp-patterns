namespace Delegate
{
    //you can even name a delegate (old school way :) )
    delegate int OldSchoolNamedDelegate(bool someBool);

    class ClassThatTakesDelegateThree
    {
        //some like it named as such
        public void DoMagicalThings(OldSchoolNamedDelegate aFunctionWeCanRun)
        {
            //based on the signature of the Func, we are passing a bool to the function and expecting an int to be returned
            int result = aFunctionWeCanRun(true);
        }
    }
}
