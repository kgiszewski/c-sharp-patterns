using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            //for this example we are creating two bad guys that will appear in a video game
            //each bad guy normally moves side to side, but for bad guys named 'Dave', then get to move up and down.

            //this example is also using a factory to create our bad guys
            //inside the factory you'll see that each bad guy is created and a movement strategy is selected

            //the strategy pattern is encapsulating a behavior in a call class through a concrete implementation of an abstract interface or class

            //fred will move side to side
            var fred = BadGuyFactory.Create("Fred");

            fred.MovementStrategy.Move();

            //dave will move up and down
            var dave = BadGuyFactory.Create("Dave");

            dave.MovementStrategy.Move();

            Console.ReadKey();
        }
    }
}
