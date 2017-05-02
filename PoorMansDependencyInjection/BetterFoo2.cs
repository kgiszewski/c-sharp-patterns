namespace PoorMansDependencyInjection
{
    class BetterFoo2 : IFoo
    {
        private IBar _bar;

        public IBar Bar
        {
            //if I don't have a IBar impl, use a default one
            get { return _bar ?? (_bar = new Bar()); }

            set { _bar = value; }
        }

        public void Blah()
        {
            _bar.DoSomething();
        }
    }
}
