using System;

namespace Observer
{
    //NOTE: the inheritance of EventArgs
    public class SomethingAmazingEventArgs : EventArgs
    {
        public int NumberOfUnicornsDancing { get; set; }
        public int BubbleFactor { get; set; }

        //create a constructor with anything you want any observers to know about this amazing event
        public SomethingAmazingEventArgs(int numberOfUnicornsDancing, int bubbleFactor)
        {
            NumberOfUnicornsDancing = numberOfUnicornsDancing;
            BubbleFactor = bubbleFactor;
        }
    }
}
