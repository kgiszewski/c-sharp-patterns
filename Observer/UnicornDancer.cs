using System;

namespace Observer
{
    public class UnicornDancer : ICanBeObserved
    {
        private static readonly Random Rand = new Random();

        public event SomethingAmazingJustHappenedHandler OnSomethingAmazingJustHappened;
        public void DoSomethingAmazing()
        {
            Console.WriteLine("Doing something amazing with Unicorns in here, we should broadcast this out!");

            //NOTE: we're using the `?` in case of no observers
            //we can pass things to the event args and they will get send to all observers
            OnSomethingAmazingJustHappened?.Invoke(this, new SomethingAmazingEventArgs(Rand.Next(100), Rand.Next(10000)));
        }
    }
}
