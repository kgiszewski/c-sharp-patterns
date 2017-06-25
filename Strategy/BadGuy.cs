using Strategy.MovementStrategies;

namespace Strategy
{
    public class BadGuy : IBadGuy
    {
        //this is our bad guy
        public string Name { get; set; }
        public IMovementStrategy MovementStrategy { get; set; }
    }
}
