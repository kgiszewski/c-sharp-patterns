namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            //this class is observable
            var unicornDancer = new UnicornDancer();

            //these two classes will do the observing
            new BubbleObserver(unicornDancer);
            new UnicornObserver(unicornDancer);

            //You could create an observer to send these events to Slack. Only the SlackObserver would need to know about Slack.

            /*
             * You may have a ton of other code in between the observer registrations and the actual execution of the observed class
             */

            //unicorns will dance, bubbles will be produced and the observers will get a chance to do something with the event arguments broadcast
            unicornDancer.DoSomethingAmazing();

            //NOTE: order of the observer execution is driven by the order by which the observers are registered.
            //However it is considered bad form to rely on this order.

            //we can do more amazing stuff and the observers will still be listening
            unicornDancer.DoSomethingAmazing();
        }
    }
}
