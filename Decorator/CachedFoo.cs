namespace Decorator
{
    class CachedFoo : IDoSomething
    {
        private readonly IDoSomething _nonCachedFoo;
        private string _whatIdid;

        public CachedFoo(IDoSomething nonCachedFoo)
        {
            _nonCachedFoo = nonCachedFoo;
        }

        public string DoSomething()
        {
            //if i don't have the stored item, go get it from the class I don't have the source
            if (string.IsNullOrEmpty(_whatIdid))
            {
                _whatIdid = _nonCachedFoo.DoSomething();
            }

            return _whatIdid;
        }
    }
}
