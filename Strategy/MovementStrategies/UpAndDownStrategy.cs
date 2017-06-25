using System;

namespace Strategy.MovementStrategies
{
    //a concrete movement strategy
    public class UpAndDownStrategy : IMovementStrategy
    {
        //in an actual game, you can implement the details of how to move up and down
        public void Move()
        {
            Console.WriteLine("I'm moving up and down.");
        }
    }
}
