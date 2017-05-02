namespace PoorMansDependencyInjection
{
    class BestFoo : IFoo
    {
        private readonly IBar _bar;

        public BestFoo()
            : this(new Bar())
        {
        }

        public BestFoo(IBar bar)
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
