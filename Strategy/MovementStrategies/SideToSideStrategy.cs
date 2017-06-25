using System;

namespace Strategy.MovementStrategies
{
    //a concrete movement strategy
    public class SideToSideStrategy : IMovementStrategy
    {
        //in an actual game, you can implement the details of how to move side to side
        public void Move()
        {
            Console.WriteLine("I'm moving side to side!");
        }
    }
}
