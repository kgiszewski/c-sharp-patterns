using System;

namespace Observer
{
    public class BubbleObserver
    {
        public BubbleObserver(ICanBeObserved observableThing)
        {
            //let's register our event handler
            if (observableThing != null)
            {
                observableThing.OnSomethingAmazingJustHappened += _observableThing_OnSomethingAmazingJustHappened;
            }
        }

        private void _observableThing_OnSomethingAmazingJustHappened(object sender, SomethingAmazingEventArgs e)
        {
            Console.WriteLine($"I don't care about Unicorns, but I noticed that something amazing happened and there was a bubble factor of: {e.BubbleFactor}!");
        }
    }
}
