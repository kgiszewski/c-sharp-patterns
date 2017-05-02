namespace PoorMansDependencyInjection
{
    public class Foo : IFoo
    {
        public void Blah()
        {
            //this will be near impossible to swap out
            var bar = new Bar();
        }
    }
}
