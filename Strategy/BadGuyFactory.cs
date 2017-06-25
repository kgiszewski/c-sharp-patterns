using Strategy.MovementStrategies;

namespace Strategy
{
    public static class BadGuyFactory
    {
        public static IBadGuy Create(string name)
        {
            //default for guys like Fred
            IMovementStrategy movementStrategy = new SideToSideStrategy();

            //Dave is special, so let's assign him up and down
            if (name == "Dave")
            {
                movementStrategy = new UpAndDownStrategy();
            }

            //let's construct our bad guys now that our movement strategy has been selected
            return new BadGuy
            {
                Name = name,
                MovementStrategy = movementStrategy
            };
        }
    }
}
