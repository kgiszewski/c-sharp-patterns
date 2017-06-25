using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            //for this example we are creating two henchmen and bad guys that will appear in a video game
            //each henchmen\bad guy normally moves side to side, but for henchmen\bad guys named 'Dave', they get to move up and down.

            //henchmen do not use a strategy pattern
            var daveHenchman = new Henchman
            {
                Name = "Dave"
            };

            var fredHenchman = new Henchman
            {
                Name = "Fred"
            };

            //we have to do a more explicit move for our henchmen
            _move(daveHenchman);
            _move(fredHenchman);

            //bad guys do use a strategy pattern
            //this example is also using a factory to create our bad guys
            //inside the factory you'll see that each bad guy is created and a movement strategy is selected

            //the strategy pattern is encapsulating a behavior in a call class through a concrete implementation of an abstract interface or class

            //the 'how' to move is encapsulated in to discrete classes

            //dave will move up and down
            var daveBadGuy = BadGuyFactory.Create("Dave");

            daveBadGuy.MovementStrategy.Move();

            //fred will move side to side
            var fredBadGuy = BadGuyFactory.Create("Fred");

            fredBadGuy.MovementStrategy.Move();

            Console.ReadKey();
        }

        //this tangles up both up and down and side to side movement
        //the strategy pattern helps us make a class per movement type
        //the details of the movement are not encapsulated here
        //this will lead to a large class with a bunch of logic conditionals
        private static void _move(Henchman henchman)
        {
            if (henchman.Name == "Dave")
            {
                Console.WriteLine("Moving Up and down!");
            }
            else
            {
                Console.WriteLine("Moving side to side!");
            }
        }
    }
}
