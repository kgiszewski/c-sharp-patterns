namespace PoorMansDependencyInjection
{
    class BetterFoo : IFoo
    {
        private readonly IBar _bar;

        public BetterFoo()
            : this(new Bar())
        {
        }

        public BetterFoo(IBar bar)
        {
            _bar = bar;
        }

        public void Blah()
        {
            //I'm using bar, but I can swap it out easily without this line of code caring
            _bar.DoSomething();
        }
    }
}
