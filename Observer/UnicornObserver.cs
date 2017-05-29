using System;

namespace Observer
{
    public class UnicornObserver
    {
        public UnicornObserver(ICanBeObserved observableThing)
        {
            //let's register our event handler
            if (observableThing != null)
            {
                observableThing.OnSomethingAmazingJustHappened += ObservableThing_OnSomethingAmazingJustHappened;
            }
        }

        private void ObservableThing_OnSomethingAmazingJustHappened(object sender, SomethingAmazingEventArgs e)
        {
            Console.WriteLine($"I don't care about Bubbles, but I noticed that something amazing happened and there were {e.NumberOfUnicornsDancing} unicorns dancing!");
        }
    }
}
