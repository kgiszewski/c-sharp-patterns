using Strategy.MovementStrategies;

namespace Strategy
{
    //our bad guys abstracted
    public interface IBadGuy
    {
        string Name { get; set; }
        IMovementStrategy MovementStrategy { get; set; }
    }
}
